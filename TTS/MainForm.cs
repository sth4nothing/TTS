using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sth4nothing.TTS.Properties;

namespace Sth4nothing.TTS
{
    public partial class MainForm : Form
    {
        private static readonly ILog logger = LogManager.GetLogger("TTS");
        private const string voice = "Cortana - Chinese(Simplified)";
        private readonly Size formSize = new Size(441, 337);

        private SpeechSynthesizer ssynth;
        private bool fetchByHotkey;

        private List<string> texts = new List<string>();
        private int index;
        private int fetchId;

        private readonly HashSet<char> sep = new HashSet<char>{
            //'.',
            '?', '!',
            '。', '？', '！',
            '\n'
        };

        public MainForm()
        {
            hotKeys = new Dictionary<int, Tuple<KeyModifiers, Keys, Action>>()
            {
                {1, Tuple.Create(KeyModifiers.None, Keys.MediaPlayPause, new Action(PlayPause)) },
                {2,  Tuple.Create(KeyModifiers.None, Keys.MediaNextTrack, new Action(Next))},
                {3,  Tuple.Create(KeyModifiers.None, Keys.MediaPreviousTrack, new Action(Previous))},
                {4,  Tuple.Create(KeyModifiers.Control, Keys.M, new Action(ShowHide))},
            };
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(novelTxt.Text)
                && !string.IsNullOrWhiteSpace(novelTxt.Text))
            {
                logger.Debug("play");
                ResetSynth();
                playBtn.Enabled = false;

                new Thread(ParseText).Start(); 
            }
        }

        private void ParseText()
        {
            try
            {
                texts.Clear();
                for (int i = 0, j = 0; i < novelTxt.Text.Length; i++)
                {
                    if (sep.Contains(novelTxt.Text[i]) || i == novelTxt.Text.Length - 1)
                    {
                        if (i - j > 1)
                        {
                            texts.Add(novelTxt.Text.Substring(j, i + 1 - j));
                        }
                        j = i + 1;
                    }
                }

                index = 0;
                logger.Debug("count: " + texts.Count);
                ssynth.SpeakAsync(texts[index++]);
            }
            catch (Exception) { }
            finally
            {
                Invoke(new Action(() => 
                {
                    playBtn.Enabled = true;
                    pauseBtn.Text = "Pause";
                }));
            }
        }

        private void ResetSynth()
        {
            ssynth?.SpeakAsyncCancelAll();
            ssynth?.Dispose();
            ssynth = new SpeechSynthesizer();
            ssynth.SelectVoice(voice);
            ssynth.Rate = speedBar.Value;

            ssynth.SpeakCompleted += Ssynth_SpeakCompleted;
            ssynth.SpeakStarted += Ssynth_SpeakStarted;
        }

        private void Ssynth_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            logger.Debug("index:" + (index - 1));
            logger.Debug(texts[index - 1]);
        }

        private void Ssynth_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            if (index < texts.Count)
                ssynth.SpeakAsync(texts[index++]);
            else
                ssynth = null;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            logger.Debug("pause/resume");
            switch (ssynth?.State)
            {
                case SynthesizerState.Ready:
                    break;
                case SynthesizerState.Speaking:
                    ssynth.Pause();
                    pauseBtn.Text = "Resume";
                    break;
                case SynthesizerState.Paused:
                    ssynth.Resume();
                    pauseBtn.Text = "Pause";
                    break;
                default:
                    break;
            }
        }

        private void FetchData()
        {
            var server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var ar = server.BeginConnect(new IPEndPoint(IPAddress.Loopback, 6666), ConnectCallback, server);
            Thread.Sleep(5000);
            if (!ar.IsCompleted)
            {
                server.Close();
                nxtChapBtn.Enabled = true;
            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            var server = ar.AsyncState as Socket;
            try
            {
                server.EndConnect(ar);
            }
            catch (SocketException e)
            {
                logger.Error("连接失败", e);
                return;
            }

            try
            {
                server.Send(Encoding.Unicode.GetBytes($"#{fetchId}"));
            }
            catch (SocketException e)
            {
                logger.Error("无法发送请求", e);
                return;
            }

            var stateObj = new StateObject()
            {
                workSocket = server,
            };
            server.BeginReceive(stateObj.buffer, 0, 1024, SocketFlags.None, ReceiveCallback, stateObj);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            var stateObj = ar.AsyncState as StateObject;
            var server = stateObj.workSocket;

            var size = 0;
            try
            {
                size = server.EndReceive(ar);
            }
            catch (Exception e)
            {
                logger.Error("cannot fetch data", e);
                return;
            }

            if (size > 0)
            {
                stateObj.sb.Append(Encoding.Unicode.GetString(stateObj.buffer, 0, size));
                server.BeginReceive(stateObj.buffer, 0, 1024, SocketFlags.None, ReceiveCallback, stateObj);
            }
            else
            {
                if (stateObj.sb.Length > 0)
                {
                    var text = stateObj.sb.ToString();
                    logger.Debug("received: " + text.Length);
                    Invoke(new Action(() => 
                    {
                        novelTxt.Text = text;
                        if (fetchByHotkey)
                        {
                            fetchByHotkey = false;
                            playBtn.PerformClick();
                        }
                    }));
                }
                
                server.Close();
                fetchId = -1;
            }
        }


        private void NxtChapBtn_Click(object sender, EventArgs e)
        {
            if (fetchId < 0)
            {
                fetchId = 2;
                logger.Debug("fetch next");
                new Thread(FetchData).Start(); 
            }
        }
        private void CurChapBtn_Click(object sender, EventArgs e)
        {
            if (fetchId < 0)
            {
                fetchId = 1;
                logger.Debug("fetch current");
                new Thread(FetchData).Start();
            }
        }

        private void PreChapBtn_Click(object sender, EventArgs e)
        {
            if (fetchId < 0)
            {
                fetchId = 0;
                logger.Debug("fetch previours");
                new Thread(FetchData).Start();
            }
        }

        private void PreSentBtn_Click(object sender, EventArgs e)
        {
            logger.Debug("previous sentence");
            ResetSynth();

            if (index > 1)
                ssynth.SpeakAsync(texts[--index - 1]);
            else if (index == 1)
                ssynth.SpeakAsync(texts[index - 1]);
            logger.Debug($"index: {index}; text: {texts[index - 1]}");
        }

        private void NxtSentBtn_Click(object sender, EventArgs e)
        {
            logger.Debug("next sentence");
            ResetSynth();

            if (index < texts.Count)
                ssynth.SpeakAsync(texts[index++]);
            else if (index == texts.Count)
                ssynth.SpeakAsync(texts[index - 1]);
            logger.Debug($"index: {index}; text: {texts[index - 1]}");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (var synth = new SpeechSynthesizer())
            {
                if (synth.GetInstalledVoices().All(v => v.VoiceInfo.Name != voice))
                {
                    MessageBox.Show(
                        "当前系统未配置Cortana引擎，请接下来用管理员权限进行配置",
                        "未找到Cortana引擎",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);


                    var p = new ProcessStartInfo()
                    {
                        FileName = "powershell.exe",
                        Verb = "RunAs",
                        Arguments =
                            $"-NoProfile -NonInteractive -Command \"Set-ExecutionPolicy Unrestricted; cd '{Application.StartupPath}'; .\\ActivateCortana.ps1;\""
                    };
                    try
                    {
                        Process.Start(p)?.WaitForExit();
                        MessageBox.Show(Resources.CortanaConfigurationSuccessContentText, Resources.CortanaConfigurationSucessTitleText, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(Application.ExecutablePath);
                    }
                    catch (Win32Exception)
                    {
                        MessageBox.Show(Resources.CortanaConfigurationFailContentText, Resources.CortanaConfigurationFailTitleText, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Environment.Exit(0);
                }
            }

            fetchId = -1;
        }

        private void SpeedBar_Scroll(object sender, EventArgs e)
        {
            if (ssynth!= null)
                ssynth.Rate = speedBar.Value;
        }

        private const int WM_HOTKEY = 0x312; //窗口消息：热键
        private const int WM_CREATE = 0x1; //窗口消息：创建
        private const int WM_DESTROY = 0x2; //窗口消息：销毁

        private const int HotKey1 = 1; //热键ID（自定义）
        private const int HotKey2 = 2;
        private const int HotKey3 = 3;
        private const int HotKey4 = 4;
        private readonly Dictionary<int, Tuple<KeyModifiers, Keys, Action>> hotKeys;

        private DateTime pre = DateTime.MinValue;

        private void PlayPause()
        {
            logger.Debug("hotkey1 - activate");
            if (ssynth == null || (ssynth?.State == SynthesizerState.Ready && index == texts.Count))
            {
                playBtn.PerformClick();
            }
            else
            {
                pauseBtn.PerformClick();
            }
        }
        private void Next()
        {
            if (fetchId < 0 && !fetchByHotkey)
            {
                var now = DateTime.Now;
                if ((now - pre) >= TimeSpan.FromSeconds(1))
                {
                    logger.Debug("hotkey2 - activate");
                    pre = now;
                    fetchByHotkey = true;
                    nxtChapBtn.PerformClick();
                }
                else
                {
                    logger.Debug("hotkey2 - ignore");
                }
            }
        }
        private void Previous()
        {
            if (fetchId < 0 && !fetchByHotkey)
            {
                var now = DateTime.Now;
                if ((now - pre) >= TimeSpan.FromSeconds(1))
                {
                    logger.Debug("hotkey3 - activate");
                    pre = now;
                    fetchByHotkey = true;
                    preChapBtn.PerformClick();
                }
                else
                {
                    logger.Debug("hotkey3 - ignore");
                }
            }
        }
        private void ShowHide()
        {
            if (this.Visible)
            {
                this.Hide();
            }
            else
            {
                this.Show();
                this.Activate();
            }
        }
        protected override void WndProc(ref Message msg)
        {
            switch (msg.Msg)
            {
                case WM_HOTKEY:
                    if (hotKeys.ContainsKey(msg.WParam.ToInt32()))
                    {
                        hotKeys[msg.WParam.ToInt32()].Item3?.Invoke();
                    }
                    else
                    {
                        logger.Warn("Unknown hotkey: " + msg.WParam.ToInt32());
                    }
                    break;
                case WM_CREATE: //窗口消息：创建
                    foreach (var item in hotKeys)
                    {
                        Hotkey.RegisterHotKey(Handle, item.Key, item.Value.Item1, item.Value.Item2);
                    }
                    logger.Debug("register hotkey");
                    break;
                case WM_DESTROY: //窗口消息：销毁
                    foreach (var item in hotKeys)
                    {
                        Hotkey.UnregisterHotKey(Handle, item.Key);
                    }
                    logger.Debug("unregister hotkey");
                    break;
                default:
                    break;
            }
            base.WndProc(ref msg);
        }

        private void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            switch (e.AssociatedControl.Name)
            {
                case "trackBar1":
                    e.Graphics.DrawString($"播放速度\n{speedBar.Value}∈[-10,10]", e.Font, new SolidBrush(Color.Black), new PointF(2, 2));
                    break;
                default:
                    e.DrawText();
                    break;
            }
        }

        private void ToolTip_Popup(object sender, PopupEventArgs e)
        {
            if (e.AssociatedControl == speedBar)
            {
                e.ToolTipSize = new Size(72, 34);
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            ShowHide();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

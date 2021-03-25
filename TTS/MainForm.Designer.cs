using System.Drawing;

namespace Sth4nothing.TTS
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            toolTip?.Dispose();
            ssynth?.SpeakAsyncCancelAll();
            ssynth?.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.novelTxt = new System.Windows.Forms.TextBox();
            this.playBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.nxtChapBtn = new System.Windows.Forms.Button();
            this.preSentBtn = new System.Windows.Forms.Button();
            this.nxtSentBtn = new System.Windows.Forms.Button();
            this.curChapBtn = new System.Windows.Forms.Button();
            this.preChapBtn = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // novelTxt
            // 
            this.novelTxt.AcceptsReturn = true;
            this.novelTxt.AcceptsTab = true;
            this.novelTxt.Dock = System.Windows.Forms.DockStyle.Top;
            this.novelTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.novelTxt.ImeMode = System.Windows.Forms.ImeMode.On;
            this.novelTxt.Location = new System.Drawing.Point(0, 0);
            this.novelTxt.Margin = new System.Windows.Forms.Padding(2);
            this.novelTxt.Multiline = true;
            this.novelTxt.Name = "novelTxt";
            this.novelTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.novelTxt.Size = new System.Drawing.Size(425, 212);
            this.novelTxt.TabIndex = 0;
            // 
            // playBtn
            // 
            this.playBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playBtn.Location = new System.Drawing.Point(103, 225);
            this.playBtn.Margin = new System.Windows.Forms.Padding(2);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(70, 26);
            this.playBtn.TabIndex = 1;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseBtn.Location = new System.Drawing.Point(11, 225);
            this.pauseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(72, 26);
            this.pauseBtn.TabIndex = 2;
            this.pauseBtn.Text = "Pause";
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.Button2_Click);
            // 
            // nxtChapBtn
            // 
            this.nxtChapBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nxtChapBtn.Location = new System.Drawing.Point(58, 261);
            this.nxtChapBtn.Margin = new System.Windows.Forms.Padding(2);
            this.nxtChapBtn.Name = "nxtChapBtn";
            this.nxtChapBtn.Size = new System.Drawing.Size(23, 26);
            this.nxtChapBtn.TabIndex = 4;
            this.nxtChapBtn.Text = ">";
            this.toolTip.SetToolTip(this.nxtChapBtn, "下一章");
            this.nxtChapBtn.UseVisualStyleBackColor = true;
            this.nxtChapBtn.Click += new System.EventHandler(this.NxtChapBtn_Click);
            // 
            // preSentBtn
            // 
            this.preSentBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preSentBtn.Location = new System.Drawing.Point(103, 261);
            this.preSentBtn.Margin = new System.Windows.Forms.Padding(2);
            this.preSentBtn.Name = "preSentBtn";
            this.preSentBtn.Size = new System.Drawing.Size(34, 26);
            this.preSentBtn.TabIndex = 5;
            this.preSentBtn.Text = "←";
            this.toolTip.SetToolTip(this.preSentBtn, "上一句");
            this.preSentBtn.UseVisualStyleBackColor = true;
            this.preSentBtn.Click += new System.EventHandler(this.PreSentBtn_Click);
            // 
            // nxtSentBtn
            // 
            this.nxtSentBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nxtSentBtn.Location = new System.Drawing.Point(139, 261);
            this.nxtSentBtn.Margin = new System.Windows.Forms.Padding(2);
            this.nxtSentBtn.Name = "nxtSentBtn";
            this.nxtSentBtn.Size = new System.Drawing.Size(34, 26);
            this.nxtSentBtn.TabIndex = 6;
            this.nxtSentBtn.Text = "→";
            this.toolTip.SetToolTip(this.nxtSentBtn, "下一句");
            this.nxtSentBtn.UseVisualStyleBackColor = true;
            this.nxtSentBtn.Click += new System.EventHandler(this.NxtSentBtn_Click);
            // 
            // curChapBtn
            // 
            this.curChapBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curChapBtn.Location = new System.Drawing.Point(35, 261);
            this.curChapBtn.Margin = new System.Windows.Forms.Padding(2);
            this.curChapBtn.Name = "curChapBtn";
            this.curChapBtn.Size = new System.Drawing.Size(23, 26);
            this.curChapBtn.TabIndex = 8;
            this.curChapBtn.Text = "|";
            this.toolTip.SetToolTip(this.curChapBtn, "这一章");
            this.curChapBtn.UseVisualStyleBackColor = true;
            this.curChapBtn.Click += new System.EventHandler(this.CurChapBtn_Click);
            // 
            // preChapBtn
            // 
            this.preChapBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preChapBtn.Location = new System.Drawing.Point(12, 261);
            this.preChapBtn.Margin = new System.Windows.Forms.Padding(2);
            this.preChapBtn.Name = "preChapBtn";
            this.preChapBtn.Size = new System.Drawing.Size(23, 26);
            this.preChapBtn.TabIndex = 9;
            this.preChapBtn.Text = "<";
            this.toolTip.SetToolTip(this.preChapBtn, "上一章");
            this.preChapBtn.UseVisualStyleBackColor = true;
            this.preChapBtn.Click += new System.EventHandler(this.PreChapBtn_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 200;
            this.toolTip.OwnerDraw = true;
            this.toolTip.ReshowDelay = 10;
            this.toolTip.ShowAlways = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.ToolTip_Draw);
            this.toolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.ToolTip_Popup);
            // 
            // speedBar
            // 
            this.speedBar.LargeChange = 4;
            this.speedBar.Location = new System.Drawing.Point(180, 241);
            this.speedBar.Minimum = -10;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(233, 45);
            this.speedBar.TabIndex = 7;
            this.speedBar.TickFrequency = 2;
            this.toolTip.SetToolTip(this.speedBar, "播放速度");
            this.speedBar.Scroll += new System.EventHandler(this.SpeedBar_Scroll);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "TTS";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(117, 26);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.退出ToolStripMenuItem.Text = "退出(&X)";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 298);
            this.Controls.Add(this.novelTxt);
            this.Controls.Add(this.preChapBtn);
            this.Controls.Add(this.curChapBtn);
            this.Controls.Add(this.nxtSentBtn);
            this.Controls.Add(this.preSentBtn);
            this.Controls.Add(this.nxtChapBtn);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.speedBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Text 2 Speech";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox novelTxt;
        internal System.Windows.Forms.Button playBtn;
        internal System.Windows.Forms.Button pauseBtn;
        internal System.Windows.Forms.Button nxtChapBtn;
        internal System.Windows.Forms.Button preSentBtn;
        internal System.Windows.Forms.Button nxtSentBtn;
        internal System.Windows.Forms.Button curChapBtn;
        internal System.Windows.Forms.Button preChapBtn;
        internal System.Windows.Forms.ToolTip toolTip;
        internal System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
    }
}
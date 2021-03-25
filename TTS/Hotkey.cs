using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sth4nothing.TTS
{
    /// <summary>
    /// Key Modifiers
    /// </summary>
    [Flags]
    internal enum KeyModifiers
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        // Either WINDOWS key was held down. These keys are labeled with the Windows logo.
        // Keyboard shortcuts that involve the WINDOWS key are reserved for use by the 
        // operating system.
        Windows = 8
    }
    /// <summary>
    /// 管理热键
    /// </summary>
    internal static class Hotkey
    {
        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="id">热键id</param>
        /// <param name="fsModifiers">key modifiers</param>
        /// <param name="vk">热键</param>
        /// <returns>注册是否成功</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        /// <summary>
        /// 取消热键
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="id">热键id</param>
        /// <returns>取消是否成功</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}

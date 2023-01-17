using System.Runtime.InteropServices;

namespace lab_os_4
{
    public class Imports
    {
        public enum Messages : uint
        {
            WM_REQUEST = 0x002,
            WM_GRANTED = 0x004,
            WM_WAIT = 0x008,
            WM_FINISHED = 0x016,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            public IntPtr hwnd;
            public Messages message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public Point pt;
            public uint lPrivate;
        }

        [DllImport("user32.dll")]
        public static extern bool PostThreadMessage([In] uint idThread, [In] uint Msg, [In] IntPtr wParam, [In] IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern bool PeekMessage([Out] out MSG lpMsg, [In, Optional] IntPtr hWnd, [In] uint wMsgFilterMin, [In] uint wMsgFilterMax, [In] uint wRemoveMsg);

        [DllImport("Kernel32.dll")]
        public static extern uint GetCurrentThreadId();
    }
}
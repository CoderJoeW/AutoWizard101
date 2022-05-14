using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMaelstrom
{
    internal static class WinAPI
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint cButtons, UIntPtr dwExtraInfo);

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        public const uint MOUSEEVENTF_LEFTUP = 0x04;
        public const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const uint MOUSEEVENTF_RIGHTUP = 0x10;

        public static void click(Point point)
        {
            Cursor.Position = point;
            Thread.Sleep(75);
            mouse_event(MOUSEEVENTF_LEFTDOWN, point.X, point.Y, 0, UIntPtr.Zero);
            mouse_event(MOUSEEVENTF_LEFTUP, point.X, point.Y, 0, UIntPtr.Zero);
        }

        public static void mDown(int x, int y)
        {
            Cursor.Position = new Point(x, y);
            Thread.Sleep(75);
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, UIntPtr.Zero);
        }

        public static void mDragTo(int x, int y)
        {
            Cursor.Position = new Point(x, y);
            Thread.Sleep(150);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, UIntPtr.Zero);
        }
    }
}

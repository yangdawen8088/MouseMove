using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;

namespace MouseMove
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = DateTime.UtcNow;
            while (true)
            {
                MouseMoves();
                if (DateTime.UtcNow > dateTime.AddMinutes(60)) break;
            }
        }
        [DllImport("user32.dll")]
        static extern void mouse_event(int flags, int dX, int dY);
        const int MOUSEEVENTF_MOVE = 0x1;
        public static void MouseMoves()
        {
            Random random = new Random();
            switch (random.Next(1, 5))
            {
                case 1: mouse_event(MOUSEEVENTF_MOVE, 0, -1); break;
                case 2: mouse_event(MOUSEEVENTF_MOVE, 0, 1); break;
                case 3: mouse_event(MOUSEEVENTF_MOVE, -1, 0); break;
                case 4: mouse_event(MOUSEEVENTF_MOVE, 1, 0); break;
            }
            Thread.Sleep(1);
        }
    }
}

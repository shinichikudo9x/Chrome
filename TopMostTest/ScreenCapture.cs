using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chrome
{
    public class ScreenCapture
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        public static Image CaptureDesktop()
        {
            return CaptureWindow(GetDesktopWindow());
        }

        public static Bitmap CaptureActiveWindow(int xBegin, int yBegin, int xEnd, int yEnd)
        {
            return CaptureWindow(GetForegroundWindow(),xBegin,yBegin,xEnd,yEnd);
        }

        public static Bitmap CaptureWindow(IntPtr handle, int xBegin, int yBegin, int xEnd, int yEnd)
        {
            try
            {
                if (xBegin > xEnd) swap(ref xBegin, ref xEnd);
                if (yBegin > yEnd) swap(ref yBegin, ref yEnd);
                var bounds = new Rectangle(xBegin, yBegin, xEnd - xBegin, yEnd - yBegin);
                var result = new Bitmap(bounds.Width, bounds.Height);

                using (var graphics = Graphics.FromImage(result))
                {
                    graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }

                return result;
            } catch(Exception ex)
            {
                return null;
            }
            
        }
        public static Bitmap CaptureWindow(IntPtr handle)
        {
            var rect = new Rect();
            GetWindowRect(handle, ref rect);
            var bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            var result = new Bitmap(bounds.Width, bounds.Height);

            using (var graphics = Graphics.FromImage(result))
            {
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }

            return result;
        }
        public static void saveImage(string path, int xBegin, int yBegin, int xEnd, int yEnd)
        {
            if(xEnd>xBegin && yEnd > yBegin)
            {
                var image = ScreenCapture.CaptureActiveWindow(xBegin, yBegin, xEnd, yEnd);
                image.Save(path + ".jpg", ImageFormat.Jpeg);
            }
        }
        public static void saveImage(string path)
        {
            var image = ScreenCapture.CaptureDesktop();
            image.Save(path + ".jpg", ImageFormat.Jpeg);
        }
        private static void swap(ref int begin, ref int end)
        {
            int temp = begin;
            begin = end;
            end = temp;
        }
    }
    
}

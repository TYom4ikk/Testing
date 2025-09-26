using System;

namespace RoomCalculatingLibrary
{
    public class Room
    {
        private ulong id;
        private double length;
        private double width;
        private double height;
        private ushort windowCount;
        private Window window;

        public ulong Id
        {
            get { return id; }
            set { id = value; }
        }
        public double Length
        {
            get { return length; }
            set { length = value; }
        }
        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        public ushort WindowCount
        {
            get { return windowCount; }
            set { windowCount = value; }
        }
        public Window Window
        {
            get { return window; }
            set { window = value; }
        }


        public Room(ulong id, double length, double width, double height,
            ushort windowCount, Window window)
        {
            if (length < 0 || width < 0 || height < 0 || windowCount < 0)
            {
                throw new Exception();
            }
            Id = id;
            Length = length;
            Width = width;
            Height = height;
            WindowCount = windowCount;
            Window = window;
        }

        public Room(ulong id, double length, double width, double height,
          ushort windowCount)
        {
            if(length < 0 || width < 0 || height < 0 || windowCount < 0)
            {
                throw new Exception();
            }
            Id = id;
            Length = length;
            Width = width;
            Height = height;
            WindowCount = windowCount;
        }

        public string GetInfo()
        {
            string result = $"[{id}] x:{length} y:{height} z:{width}";
            if (window != null)
            {
                result += $"\nwindow ({windowCount}) - {window.Width}:{window.Height}";
            }
            Console.WriteLine(result);

            return result;
        }


        public double OptimalRollSize()
        {
            double windowsSqare = 0;
            if (window != null)
            {
                windowsSqare = (window.Height * window.Width) * windowCount;
            }
            var totalWallSqare = (((Length * Height) + (Width * Height)) * 2)
                - (windowsSqare * windowCount);

            return totalWallSqare;
        }

        public double Repair(Wallpaper wallpaper)
        {
            double windowsSqare = 0;
            if (window != null)
            {
                windowsSqare = (window.Height * window.Width) * windowCount;
            }
            var totalWallSqare = (((Length * Height) + (Width * Height)) * 2)
                - (windowsSqare * windowCount);

            double result = Math.Ceiling(totalWallSqare / (wallpaper.Width * wallpaper.Length));

            return result;
        }
    }
}

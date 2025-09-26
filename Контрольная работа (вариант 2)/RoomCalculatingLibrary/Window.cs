using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomCalculatingLibrary
{
    public class Window
    {
        private double height;
        private double width;

        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public Window(double height, double width)
        {
            Height = height;
            Width = width;
        }
    }
}

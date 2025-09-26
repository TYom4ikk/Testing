using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomCalculatingLibrary
{
    public class Wallpaper
    {
        private ulong id;
        private double length;
        private double width;
        private ulong price;

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
        public ulong Price
        {
            get { return price; }
            set { price = value; }
        }

        public Wallpaper(ulong id, double length, double width, ulong price)
        {
            Id = id;
            Length = length;
            Width = width;
            Price = price;
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoomCalculatingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoomCalculatingLibraryTest
{
    [TestClass]
    public class RoomTest
    {
        [TestMethod]
        public void RoomRepairTest1()
        {
            Window window =  new Window(170, 200);
            Wallpaper wallpaper = new Wallpaper(1, 1000, 200, 150000);
            Room room = new Room(1, 500, 400, 250, 1, window);
            Assert.AreEqual(room.Repair(wallpaper), 3);
        }

        [TestMethod]
        public void RoomRepairTest2()
        {
            Wallpaper wallpaper = new Wallpaper(1, 1500, 200, 150000);
            Room room = new Room(1, 500, 400, 250, 0);
            Assert.AreEqual(room.Repair(wallpaper), 2);
        }

        [TestMethod]
        public void RoomRepairTest3()
        {
            Window window = new Window(0, 200);
            Wallpaper wallpaper = new Wallpaper(1, 1500, 200, 150000);
            Room room = new Room(1, 500, 400, 250, 1, window);
            Assert.AreEqual(room.Repair(wallpaper), 2);
        }

        [TestMethod]
        public void RoomRepairTest4and5()
        {
            Assert.ThrowsException<System.Exception>(() => new Room(1, 500, -400, 250, 0));
        }

        [TestMethod]
        public void RoomRepairTest6()
        {
            List<Room> rooms = new List<Room> {
                new Room(1, 500, 400, 250, 1, new Window(0, 200)),
                new Room(1, 500, 400, 250, 1, new Window(0, 200)),
                new Room(1, 500, 400, 250, 1, new Window(0, 200)),
                new Room(1, 500, 400, 250, 1, new Window(0, 200)),
            };
            Assert.AreEqual(rooms.Count, 4);
        }

        [TestMethod]
        public void RoomRepairTest7()
        {
            List<Room> rooms = new List<Room> {
                new Room(1, 500, 400, 250, 1, new Window(0, 200)),
                new Room(2, 500, 400, 250, 1, new Window(0, 200)),
                new Room(3, 500, 400, 250, 1, new Window(0, 200)),
                new Room(4, 500, 400, 250, 1, new Window(0, 200)),
            };
            var searchingRoom = rooms.Where(room => room.Id == 1).First();
            string[] info = searchingRoom.GetInfo().Split();
            int roomCounter = 0;
            foreach(var item in info)
            {
                if (item.Contains("x"))
                {
                    roomCounter++;
                }
            }
            Assert.AreEqual(roomCounter, 1);
        }

        [TestMethod]
        public void RoomRepairTest8()
        {
            Window window = new Window(0, 200);
            Room room = new Room(1, 500, 400, 250, 1, window);
            room.Height = 500;
            Assert.AreEqual(room.Height, 500);
        }

        [TestMethod]
        public void RoomRepairTest9()
        {
            int index = 2;
            List<Room> rooms = new List<Room> {
                new Room(1, 500, 400, 250, 1, new Window(0, 200)),
                new Room(2, 500, 400, 250, 1, new Window(0, 200)),
                new Room(3, 500, 400, 250, 1, new Window(0, 200)),
                new Room(4, 500, 400, 250, 1, new Window(0, 200)),
            };
            var deleteRoom = rooms.Where(room => int.Parse(room.Id.ToString()) == index).First();
            rooms.Remove(deleteRoom);
            bool roomExists = false;
            foreach(var room in rooms)
            {
                if(int.Parse(room.Id.ToString()) == index)
                {
                    roomExists = true; break;
                }
            }
            Assert.AreEqual(roomExists, false);
        }

        [TestMethod]
        public void RoomRepairTest10()
        {
            Window window = new Window(0, 200);
            Room room = new Room(1, 500, 400, 250, 1, window);
            double value = 450000;
            Assert.AreEqual(room.OptimalRollSize(), value);
        }
    }
}

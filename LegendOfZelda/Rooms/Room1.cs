using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading;

namespace LegendOfZelda.Rooms
{
    class Room1
    {
        private CSVReader csvReader;
        public Room1()
        {
            csvReader = new CSVReader("Room1.txt");
        }

    }
}

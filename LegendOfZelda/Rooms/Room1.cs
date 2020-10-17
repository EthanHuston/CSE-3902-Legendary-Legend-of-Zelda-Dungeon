using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading;

namespace LegendOfZelda.Rooms
{
    class Room1
    {
        private CVSReader cvsReader;
        public Room1()
        {
            cvsReader = new CVSReader("Room1.txt");
        }

    }
}

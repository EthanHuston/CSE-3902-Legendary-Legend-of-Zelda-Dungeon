using LegendOfZelda.GameplayLogic;
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
        ItemSpawner allObjects;
        public Room1()
        {
            csvReader = new CSVReader("Room1.txt");
            allObjects = csvReader.allObjects;
        }

        public void Draw()
        {
            allObjects.DrawAll();
        }

        public void Update()
        {
            allObjects.UpdateAll();
        }

    }
}

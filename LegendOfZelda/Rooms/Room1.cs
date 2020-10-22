using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Rooms
{
    public class Room1
    {
        private CSVReader csvReader;
        private ISpawnableManager allObjects;

        public Room1(SpriteBatch spriteBatch)
        {
            csvReader = new CSVReader(spriteBatch, "Room1.txt");
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

        public ISpawnableManager GetSpawnableManager()
        {
            return allObjects;
        }
    }
}

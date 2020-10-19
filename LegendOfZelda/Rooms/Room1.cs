namespace LegendOfZelda.Rooms
{
    class Room1
    {
        private CSVReader csvReader;
        IItemSpawner allObjects;
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

    }
}

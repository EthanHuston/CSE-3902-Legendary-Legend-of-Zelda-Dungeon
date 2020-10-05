  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class Sprint2
    {
        public int itemX = 20;
        public int itemY = 20;
        public int enemyNPCX = 500;
        public int enemyNPCY = 200;
        public int itemListCount = 0;
        public int ieX = 20;
        public int ieY = 600;
        public Game1 game;

        private LinkedList<IBlock> listOfBlocks;

        public Sprint2(Game1 game)
        {
            this.game = game;
            AddBlocksToList();
        }

        private void AddBlocksToList()
        {
            listOfBlocks = new LinkedList<IBlock>();
            listOfBlocks.AddLast(new BombedOpening(game.SpriteBatch));
            listOfBlocks.AddLast(new BrickTile(game.SpriteBatch));
            listOfBlocks.AddLast(new Fire(game.SpriteBatch));
            listOfBlocks.AddLast(new LadderTile(game.SpriteBatch));
            listOfBlocks.AddLast(new LockedDoor(game.SpriteBatch));
            listOfBlocks.AddLast(new OpenDoor(game.SpriteBatch));
            listOfBlocks.AddLast(new ShutDoor(game.SpriteBatch));
            listOfBlocks.AddLast(new Square(game.SpriteBatch));
            listOfBlocks.AddLast(new Stairs(game.SpriteBatch));
            listOfBlocks.AddLast(new Statues(game.SpriteBatch));
            listOfBlocks.AddLast(new Walls(game.SpriteBatch, ConstantsSprint2.WallSpawnLocationX, ConstantsSprint2.WallSpawnLocationY));
        }
    }
}

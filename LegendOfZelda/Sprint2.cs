using LegendOfZelda.Enemies;
using LegendOfZelda.Item;
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
        private LinkedList<IEnemy> listOfEnemies;
        private LinkedList<IItem> listOfItems;

        public Sprint2(Game1 game)
        {
            this.game = game;
            listOfBlocks = new LinkedList<IBlock>();
            AddBlocksToList();

            listOfEnemies = new LinkedList<IEnemy>();
            AddEnemiesToList();

            listOfItems = new LinkedList<IItem>();
            AddItemsToList();
        }

        private void AddBlocksToList()
        {
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

        private void AddEnemiesToList()
        {
            listOfEnemies.AddLast(new Aquamentus(game.SpriteBatch));
            listOfEnemies.AddLast(new Bat(game.SpriteBatch));
            listOfEnemies.AddLast(new Goriya(game.SpriteBatch));
            listOfEnemies.AddLast(new Hand(game.SpriteBatch));
            listOfEnemies.AddLast(new Jelly(game.SpriteBatch));
            listOfEnemies.AddLast(new Merchant(game.SpriteBatch));
            listOfEnemies.AddLast(new OldMan(game.SpriteBatch));
            listOfEnemies.AddLast(new Skeleton(game.SpriteBatch));
            listOfEnemies.AddLast(new SpikeTrap(game.SpriteBatch));
        }

        private void AddItemsToList()
        {
            listOfItems.AddLast(new Arrow(game.SpriteBatch));
            listOfItems.AddLast(new Bomb(game.SpriteBatch));
            listOfItems.AddLast(new Boomerang(game.SpriteBatch));
            listOfItems.AddLast(new Bow(game.SpriteBatch));
            listOfItems.AddLast(new Clock(game.SpriteBatch));
            listOfItems.AddLast(new Compass(game.SpriteBatch));
            listOfItems.AddLast(new Fairy(game.SpriteBatch));
            listOfItems.AddLast(new Heart(game.SpriteBatch));
            listOfItems.AddLast(new HeartContainer(game.SpriteBatch));
            listOfItems.AddLast(new Key(game.SpriteBatch));
            listOfItems.AddLast(new Map(game.SpriteBatch));
            listOfItems.AddLast(new Rupee(game.SpriteBatch));
            listOfItems.AddLast(new Triforce(game.SpriteBatch));
        }
    }
}

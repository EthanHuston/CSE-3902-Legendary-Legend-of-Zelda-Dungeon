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
        private Game1 game;
        private List<IBlock> listOfBlocks;
        private List<IEnemy> listOfEnemies;
        private List<IItem> listOfItems;
        private int enemyIndex = 0;
        private int itemIndex = 0;
        private int blockIndex = 0;
        public IBlock currentBlock;
        public IEnemy currentEnemy;
        public IItem currentItem;

        public Sprint2(Game1 game)
        {
            this.game = game;
            listOfBlocks = new List<IBlock>();
            AddBlocksToList();

            listOfEnemies = new List<IEnemy>();
            AddEnemiesToList();

            listOfItems = new List<IItem>();
            AddItemsToList();

            currentItem = listOfItems[0];
            currentBlock = listOfBlocks[0];
            currentEnemy = listOfEnemies[0];
        }

        private void AddBlocksToList()
        {
            listOfBlocks.Add(new BombedOpening(game.SpriteBatch));
            listOfBlocks.Add(new BrickTile(game.SpriteBatch));
            listOfBlocks.Add(new Fire(game.SpriteBatch));
            listOfBlocks.Add(new LadderTile(game.SpriteBatch));
            listOfBlocks.Add(new LockedDoor(game.SpriteBatch));
            listOfBlocks.Add(new OpenDoor(game.SpriteBatch));
            listOfBlocks.Add(new ShutDoor(game.SpriteBatch));
            listOfBlocks.Add(new Square(game.SpriteBatch));
            listOfBlocks.Add(new Stairs(game.SpriteBatch));
            listOfBlocks.Add(new Statues(game.SpriteBatch));
            listOfBlocks.Add(new Walls(game.SpriteBatch, ConstantsSprint2.WallSpawnLocationX, ConstantsSprint2.WallSpawnLocationY));
        }

        private void AddEnemiesToList()
        {
            listOfEnemies.Add(new Aquamentus(game.SpriteBatch));
            listOfEnemies.Add(new Bat(game.SpriteBatch));
            listOfEnemies.Add(new Goriya(game.SpriteBatch));
            listOfEnemies.Add(new Hand(game.SpriteBatch));
            listOfEnemies.Add(new Jelly(game.SpriteBatch));
            listOfEnemies.Add(new Merchant(game.SpriteBatch));
            listOfEnemies.Add(new OldMan(game.SpriteBatch));
            listOfEnemies.Add(new Skeleton(game.SpriteBatch));
            listOfEnemies.Add(new SpikeTrap(game.SpriteBatch));
        }

        private void AddItemsToList()
        {
            listOfItems.Add(new Arrow(game.SpriteBatch));
            listOfItems.Add(new Bomb(game.SpriteBatch));
            listOfItems.Add(new Boomerang(game.SpriteBatch));
            listOfItems.Add(new Bow(game.SpriteBatch));
            listOfItems.Add(new Clock(game.SpriteBatch));
            listOfItems.Add(new Compass(game.SpriteBatch));
            listOfItems.Add(new Fairy(game.SpriteBatch));
            listOfItems.Add(new Heart(game.SpriteBatch));
            listOfItems.Add(new HeartContainer(game.SpriteBatch));
            listOfItems.Add(new Key(game.SpriteBatch));
            listOfItems.Add(new Map(game.SpriteBatch));
            listOfItems.Add(new Rupee(game.SpriteBatch));
            listOfItems.Add(new Triforce(game.SpriteBatch));
        }

        public void NextItem()
        {
            itemIndex++;
            if(itemIndex == 13)
            {
                itemIndex = 0;
            }
            currentItem = listOfItems[itemIndex];
        }
        public void PreviousItem()
        {
            itemIndex--;
            if(itemIndex == -1)
            {
                itemIndex = 12;
            }
            currentItem = listOfItems[itemIndex];
        }
        public void NextEnemy()
        {
            enemyIndex++;
            if(enemyIndex == 9)
            {
                enemyIndex = 0;
            }
            currentEnemy = listOfEnemies[enemyIndex];
        }
        public void PreviousEnemy()
        {
            enemyIndex--;
            if(enemyIndex == -1)
            {
                enemyIndex = 8;
            }
            currentEnemy = listOfEnemies[enemyIndex];
        }
        public void NextBlock()
        {
            blockIndex++;
            if (blockIndex == 11)
            {
                blockIndex = 0;
            }
            currentBlock = listOfBlocks[blockIndex];
        }
        public void PreviousBlock()
        {
            blockIndex--;
            if (blockIndex == -1)
            {
                blockIndex = 10;
            }
            currentBlock = listOfBlocks[blockIndex];
        }
    }
}

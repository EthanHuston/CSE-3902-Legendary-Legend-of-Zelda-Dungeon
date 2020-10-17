using LegendOfZelda.Enemies;
using LegendOfZelda.InteractiveEnvironment;
using LegendOfZelda.Interface;
using LegendOfZelda.Item;
using LegendOfZelda.NonInteractiveEnvironment;
using System.Collections.Generic;

namespace LegendOfZelda.Sprint2
{
    public class Sprint2Game
    {
        private Game1 game;
        private List<IBlock> listOfBlocks;
        private List<INpc> listOfEnemies;
        private List<IItem> listOfItems;
        private int enemyIndex = 0;
        private int itemIndex = 0;
        private int blockIndex = 0;
        public IBlock currentBlock;
        public INpc currentEnemy;
        public IItem currentItem;

        public Sprint2Game(Game1 game)
        {
            this.game = game;
            listOfBlocks = new List<IBlock>();
            AddBlocksToList();

            listOfEnemies = new List<INpc>();
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
            listOfItems.Add(new ArrowItem(game.SpriteBatch));
            listOfItems.Add(new BombItem(game.SpriteBatch));
            listOfItems.Add(new BoomerangItem(game.SpriteBatch));
            listOfItems.Add(new BowItem(game.SpriteBatch));
            listOfItems.Add(new ClockItem(game.SpriteBatch));
            listOfItems.Add(new CompassItem(game.SpriteBatch));
            listOfItems.Add(new FairyItem(game.SpriteBatch));
            listOfItems.Add(new HeartItem(game.SpriteBatch));
            listOfItems.Add(new HeartContainer(game.SpriteBatch));
            listOfItems.Add(new KeyItem(game.SpriteBatch));
            listOfItems.Add(new MapItem(game.SpriteBatch));
            listOfItems.Add(new RupeeItem(game.SpriteBatch));
            listOfItems.Add(new TriforceItem(game.SpriteBatch));
        }

        public void NextItem()
        {
            itemIndex++;
            if (itemIndex == 13)
            {
                itemIndex = 0;
            }
            currentItem = listOfItems[itemIndex];
        }
        public void PreviousItem()
        {
            itemIndex--;
            if (itemIndex == -1)
            {
                itemIndex = 12;
            }
            currentItem = listOfItems[itemIndex];
        }
        public void NextEnemy()
        {
            enemyIndex++;
            if (enemyIndex == 9)
            {
                enemyIndex = 0;
            }
            currentEnemy.ResetPosition();
            currentEnemy = listOfEnemies[enemyIndex];
        }
        public void PreviousEnemy()
        {
            enemyIndex--;
            if (enemyIndex == -1)
            {
                enemyIndex = 8;
            }
            currentEnemy.ResetPosition();
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

        public void Update()
        {
            currentEnemy.Update();
            currentBlock.Update();
        }
        public void Draw()
        {
            currentItem.itemAction();
            currentEnemy.Draw();
            currentBlock.Draw();
        }
    }
}

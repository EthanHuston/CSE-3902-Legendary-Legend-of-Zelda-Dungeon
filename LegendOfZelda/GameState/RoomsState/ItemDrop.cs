using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.GameState.RoomsState
{
    internal class ItemDrop : IItemDropper
    {
        private const int rupeeDrop = 150, bombDrop = 300, heartDrop = 350, clockDrop = 380, fairyDrop = 390, maxDrop = 401;
        private readonly Random rand = RoomConstants.RandomGenerator;
        private readonly ISpawnableManager spawnableManager;

        public ItemDrop(ISpawnableManager spawnableManager)
        {
            this.spawnableManager = spawnableManager;
        }

        public void DropItem(Point position)
        {
            int dropItem = rand.Next(0, maxDrop);

            if (dropItem >= 0 && dropItem <= rupeeDrop)
            {
                //Drop nothing
            }
            else if (dropItem > rupeeDrop && dropItem <= bombDrop)
            {
                spawnableManager.Spawn(new RupeeItem(spawnableManager.Game.SpriteBatch, position));
            }
            else if (dropItem > bombDrop && dropItem <= heartDrop)
            {
                //Drop a bomb
                spawnableManager.Spawn(new BombItem(spawnableManager.Game.SpriteBatch, position));
            }
            else if (dropItem > heartDrop && dropItem <= clockDrop)
            {
                //Drop a heart
                spawnableManager.Spawn(new HeartItem(spawnableManager.Game.SpriteBatch, position));
            }
            else if (dropItem > clockDrop && dropItem <= fairyDrop)
            {
                //Drop a Clock
                spawnableManager.Spawn(new ClockItem(spawnableManager.Game.SpriteBatch, position));
            }
            else
            {
                spawnableManager.Spawn(new FairyItem(spawnableManager.Game.SpriteBatch, position));
                //Drop a Fairy
            }
            spawnableManager.Spawn(new ClockItem(spawnableManager.Game.SpriteBatch, position));
        }
    }
}

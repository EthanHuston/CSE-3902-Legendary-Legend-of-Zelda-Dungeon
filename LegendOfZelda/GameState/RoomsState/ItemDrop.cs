using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.GameState.RoomsState
{
    class ItemDrop
    {
        private Random rand = RoomConstants.RandomGenerator;
        private ISpawnableManager spawnableManager;
        private LinkPlayer player;

        public ItemDrop(ISpawnableManager spawnableManager)
        {
            this.spawnableManager = spawnableManager;
            player = (LinkPlayer)spawnableManager.GetPlayer(0);
        }
        public void DropItem(Point position)
        {
            /*int dropItem = rand.Next(0, 401);

            if (dropItem >= 0 && dropItem <= 150)
            {
                //Drop nothing
            }
            else if (dropItem > 150 && dropItem <= 300)
            {
                spawnableManager.Spawn(new RupeeItem(player.Game.SpriteBatch, position));
            }
            else if (dropItem > 300 && dropItem <= 350)
            {
                //Drop a bomb
                spawnableManager.Spawn(new BombItem(player.Game.SpriteBatch, position));
            }
            else if (dropItem > 350 && dropItem <= 380)
            {
                //Drop a heart
                spawnableManager.Spawn(new HeartItem(player.Game.SpriteBatch, position));
            }
            else if (dropItem > 380 && dropItem <= 390)
            {
                //Drop a Clock
                spawnableManager.Spawn(new ClockItem(player.Game.SpriteBatch, position));
            }
            else
            {
                spawnableManager.Spawn(new FairyItem(player.Game.SpriteBatch, position));
                //Drop a Fairy
            }*/
            spawnableManager.Spawn(new FairyItem(player.Game.SpriteBatch, position));
        }
    }
}

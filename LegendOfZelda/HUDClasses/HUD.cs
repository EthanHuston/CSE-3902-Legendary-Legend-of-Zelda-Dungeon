using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.Pause;
using LegendOfZelda.HUDClasses.Sprite;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Rooms;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.HUDClasses
{
    internal class HUD
    {
        List<IPlayer> players;
        ISprite hudSprite;
        Point position = new Point(HUDConstants.hudx, HUDConstants.hudy);

        public HUD(List<IPlayer> players)
        {
            this.players = players;
            hudSprite = HUDSpriteFactory.Instance.CreateHUDSprite();
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            hudSprite.Draw(spriteBatch, position);
        }
    }
}

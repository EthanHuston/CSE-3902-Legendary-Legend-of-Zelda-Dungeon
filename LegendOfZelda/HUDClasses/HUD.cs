using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState;
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
        HUDNumber levelNum;
        ISprite minimapSprite;
        bool displayMinimap;

        public HUD(List<IPlayer> players)
        {
            this.players = players;
            hudSprite = HUDSpriteFactory.Instance.CreateHUDSprite();
            minimapSprite = HUDSpriteFactory.Instance.CreateMiniMapSprite();
            levelNum = new HUDNumber(1);
            displayMinimap = false;
        }

        public void Update()
        {
            if (players[0].GetQuantityInInventory(LinkConstants.ItemType.Map) != 0)
                displayMinimap = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            hudSprite.Draw(spriteBatch, position);
            levelNum.Draw(spriteBatch, GameStateConstants.LevelNumberLocation);
            if (displayMinimap)
                minimapSprite.Draw(spriteBatch, GameStateConstants.MinimapLocation);
        }
    }
}

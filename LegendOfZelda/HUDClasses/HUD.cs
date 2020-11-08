using LegendOfZelda.GameState;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.HUDClasses
{
    internal class HUD : ISpawnable
    {
        private SpriteBatch spriteBatch;
        private List<IPlayer> players;
        private HeartManager heartManager;
        private NumberManager numberManager;
        private ISprite hudSprite;
        
        private HUDNumber levelNum;
        private ISprite minimapSprite;
        private bool displayMinimap;
        private LinkConstants.ItemType primaryItem;
        LinkConstants.ItemType secondaryItem;

        private bool safeToDespawn = false;
        
        private Point position;
        public Point Position { get => position; set => position = new Point(value.X, value.Y); }

        public HUD(SpriteBatch spriteBatch, List<IPlayer> players)
        {
            this.spriteBatch = spriteBatch;
            this.players = players;
            heartManager = new HeartManager((LinkPlayer)players[0]);
            numberManager = new NumberManager((LinkPlayer)players[0]);
            primaryItem = players[0].PrimaryItem;
            secondaryItem = players[0].SecondaryItem;
            hudSprite = HUDSpriteFactory.Instance.CreateHUDSprite();
            minimapSprite = HUDSpriteFactory.Instance.CreateMiniMapSprite();
            levelNum = new HUDNumber(1);
            displayMinimap = false;
            Position = new Point(HUDConstants.hudx, HUDConstants.hudy);
        }

        public void Update()
        {
            if (players[0].GetQuantityInInventory(LinkConstants.ItemType.Map) != 0)
                displayMinimap = true;
            numberManager.Update();
            heartManager.Update();
        }

        public void Draw()
        {
            hudSprite.Draw(spriteBatch, position);
            levelNum.Draw(spriteBatch, Position + HUDConstants.LevelNumberLocation);
            if (displayMinimap)
                minimapSprite.Draw(spriteBatch, Position + HUDConstants.MinimapLocation);
            numberManager.Draw(spriteBatch, Position);
            heartManager.Draw(spriteBatch, Position);
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public Rectangle GetRectangle()
        {
            return hudSprite.GetPositionRectangle();
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }
    }
}

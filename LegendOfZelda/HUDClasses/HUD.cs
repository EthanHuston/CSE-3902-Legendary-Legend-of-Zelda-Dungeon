using LegendOfZelda.GameState;
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.HUDClasses
{
    internal class HUD : IMenu
    {
        public RoomGameState roomGameState;
        private SpriteBatch spriteBatch;
        private ISprite hudSprite;
        private HeartManager heartManager;
        private NumberManager numberManager;
        private MinimapManager minimapManager;
        private ItemsManager itemsManager;
        private HUDNumber levelNum;
        private Point position;
        public Point Position { get => position; set => position = new Point(value.X, value.Y); }

        public HUD(RoomGameState gameState)
        {
            roomGameState = gameState;
            spriteBatch = gameState.Game.SpriteBatch;
            heartManager = new HeartManager((LinkPlayer)gameState.PlayerList[0]);
            numberManager = new NumberManager((LinkPlayer)gameState.PlayerList[0]);
            minimapManager = new MinimapManager(gameState);
            itemsManager = new ItemsManager(this);
            hudSprite = HUDSpriteFactory.Instance.CreateHUDSprite();
            levelNum = new HUDNumber(1);
            Position = new Point(HUDConstants.hudx, HUDConstants.hudy);
        }

        public void Update()
        {
            numberManager.Update();
            heartManager.Update();
            minimapManager.Update();
            itemsManager.Update();
        }

        public void Draw()
        {
            hudSprite.Draw(spriteBatch, position, Constants.DrawLayer.HUD);
            levelNum.Draw(spriteBatch, position + HUDConstants.LevelNumberLocation, Constants.DrawLayer.HUD);
            numberManager.Draw(spriteBatch, position);
            heartManager.Draw(spriteBatch, position);
            minimapManager.Draw(position);
            itemsManager.Draw(position);
        }

        public Rectangle GetRectangle()
        {
            return hudSprite.GetPositionRectangle();
        }

    }
}

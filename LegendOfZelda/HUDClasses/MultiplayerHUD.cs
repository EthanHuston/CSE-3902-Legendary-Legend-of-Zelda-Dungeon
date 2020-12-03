using LegendOfZelda.GameState;
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.HUDClasses
{
    internal class MultiplayerHUD : IMenu
    {
        public RoomGameState roomGameState;
        private readonly SpriteBatch spriteBatch;
        private readonly ISprite hudSprite;
        private readonly MinimapManager minimapManager;
        private readonly HeartManager player1HeartManager;
        private readonly NumberManager player1NumberManager;
        private readonly ItemsManager player1ItemsManager;
        private readonly HeartManager player2HeartManager;
        private readonly NumberManager player2NumberManager;
        private readonly ItemsManager player2ItemsManager;
        private readonly HUDNumber levelNum;
        private Point position;
        public Point Position { get => position; set => position = new Point(value.X, value.Y); }

        public MultiplayerHUD(RoomGameState gameState)
        {
            roomGameState = gameState;
            spriteBatch = gameState.Game.SpriteBatch;
            minimapManager = new MinimapManager(gameState);
            player1HeartManager = new HeartManager((LinkPlayer)gameState.PlayerList[0]);
            player1NumberManager = new NumberManager((LinkPlayer)gameState.PlayerList[0]);
            player1ItemsManager = new ItemsManager(this, gameState.PlayerList[0]);
            player2HeartManager = new HeartManager((LinkPlayer)gameState.PlayerList[1]);
            player2NumberManager = new NumberManager((LinkPlayer)gameState.PlayerList[1]);
            player2ItemsManager = new ItemsManager(this, gameState.PlayerList[1]);
            hudSprite = HUDSpriteFactory.Instance.CreateMultiplayerHUDSprite();
            levelNum = new HUDNumber(1);
            Position = new Point(HUDConstants.hudx, HUDConstants.hudy);
        }

        public void Update()
        {
            minimapManager.Update();
            player1NumberManager.Update();
            player1HeartManager.Update();
            player1ItemsManager.Update();
            player2NumberManager.Update();
            player2HeartManager.Update();
            player2ItemsManager.Update();
        }

        public void Draw()
        {
            hudSprite.Draw(spriteBatch, position, Constants.DrawLayer.HUD);
            levelNum.Draw(spriteBatch, position + HUDConstants.LevelNumberLocation, Constants.DrawLayer.HUDMinimap);
            minimapManager.Draw(position);
            player1NumberManager.Draw(spriteBatch, position + HUDConstants.RupeePos);
            player1HeartManager.Draw(spriteBatch, position + HUDConstants.HeartPos);
            player1ItemsManager.Draw();
            player2NumberManager.Draw(spriteBatch, position + HUDConstants.RupeePosPlayer2);
            player2HeartManager.Draw(spriteBatch, position + HUDConstants.HeartPosPlayer2);
            player2ItemsManager.Draw();
        }

        public Rectangle GetRectangle()
        {
            return hudSprite.GetPositionRectangle();
        }

    }
}

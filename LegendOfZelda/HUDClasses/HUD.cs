using LegendOfZelda.GameState;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.HUDClasses
{
    internal class HUD
    {
        private List<IPlayer> players;
        private ISprite hudSprite;
        private HUDNumber[] numRupees;
        private HUDNumber[] numKeys;
        private HUDNumber[] numBombs;
        private int linkRupeeCount = -20; //These will be changed on the first update
        private int linkKeyCount = -20;
        private int linkBombCount = -20;
        private HUDNumber levelNum;
        private ISprite minimapSprite;
        private bool displayMinimap;
        
        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }
        public HUD(List<IPlayer> players)
        {
            this.players = players;
            hudSprite = HUDSpriteFactory.Instance.CreateHUDSprite();
            minimapSprite = HUDSpriteFactory.Instance.CreateMiniMapSprite();
            levelNum = new HUDNumber(1);
            initNumberArrays();
            displayMinimap = false;
            Position = new Point(HUDConstants.hudx, HUDConstants.hudy);
        }

        private void initNumberArrays()
        {
            numRupees = new HUDNumber[3];
            numKeys = new HUDNumber[3];
            numBombs = new HUDNumber[3];

            //-1 assings the HUDNumber to the "X"
            numRupees[0] = new HUDNumber(-1);
            numKeys[0] = new HUDNumber(-1);
            numBombs[0] = new HUDNumber(-1);

            for(int i = 1; i < 3; i++)
            {
                //10 assigns the HUDNumber to the black square
                numRupees[i] = new HUDNumber(10);
                numKeys[i] = new HUDNumber(10);
                numBombs[i] = new HUDNumber(10);
            }
        }

        public void Update()
        {
            if (players[0].GetQuantityInInventory(LinkConstants.ItemType.Map) != 0)
                displayMinimap = true;
            if (players[0].GetQuantityInInventory(LinkConstants.ItemType.Rupee) != linkRupeeCount)
                UpdateNumRupees();
            if (players[0].GetQuantityInInventory(LinkConstants.ItemType.Key) != linkKeyCount)
                UpdateNumKeys();
            if (players[0].GetQuantityInInventory(LinkConstants.ItemType.Bomb) != linkBombCount)
                UpdateNumBombs();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            hudSprite.Draw(spriteBatch, position);
            levelNum.Draw(spriteBatch, Position + GameStateConstants.LevelNumberLocation);
            if (displayMinimap)
                minimapSprite.Draw(spriteBatch, Position + GameStateConstants.MinimapLocation);
            DrawNumRupees(spriteBatch);
            DrawNumKeys(spriteBatch);
            DrawNumBombs(spriteBatch);
        }

        private void DrawNumRupees(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < numRupees.Length; i++)
            {
                Point position = new Point(HUDConstants.RupeeNumberX + i * HUDConstants.NumberWidth, HUDConstants.RupeeNumberY);
                numRupees[i].Draw(spriteBatch, Position + position);
            }
        }
        private void DrawNumKeys(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < numKeys.Length; i++)
            {
                Point position = new Point(HUDConstants.KeyNumberX + i * HUDConstants.NumberWidth, HUDConstants.KeyNumberY);
                numKeys[i].Draw(spriteBatch, Position + position);
            }
        }
        private void DrawNumBombs(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < numBombs.Length; i++)
            {
                Point position = new Point(HUDConstants.BombNumberX + i * HUDConstants.NumberWidth, HUDConstants.BombNumberY);
                numBombs[i].Draw(spriteBatch, Position + position);
            }
        }

        private void UpdateNumRupees()
        {
            linkRupeeCount = players[0].GetQuantityInInventory(LinkConstants.ItemType.Rupee);
            int tensPlace = linkRupeeCount / 10;
            int remainder = linkRupeeCount % 10;
            if (tensPlace > 0)
            {
                numRupees[1].AssignNumber(tensPlace);
                numRupees[2].AssignNumber(remainder);
            }
            else
            {
                numRupees[1].AssignNumber(remainder);
                numRupees[2].AssignNumber(10);
            }
        }

        private void UpdateNumKeys()
        {
            linkKeyCount = players[0].GetQuantityInInventory(LinkConstants.ItemType.Key);
            int tensPlace = linkKeyCount / 10;
            int remainder = linkKeyCount % 10;
            if (tensPlace > 0)
            {
                numKeys[1].AssignNumber(tensPlace);
                numKeys[2].AssignNumber(remainder);
            }
            else
            {
                numKeys[1].AssignNumber(remainder);
                numKeys[2].AssignNumber(10);
            }
        }

        private void UpdateNumBombs()
        {
            linkBombCount = players[0].GetQuantityInInventory(LinkConstants.ItemType.Bomb);
            int tensPlace = linkBombCount / 10;
            int remainder = linkBombCount % 10;
            if (tensPlace > 0)
            {
                numBombs[1].AssignNumber(tensPlace);
                numBombs[2].AssignNumber(remainder);
            }
            else
            {
                numBombs[1].AssignNumber(remainder);
                numBombs[2].AssignNumber(10);
            }
        }
    }
}

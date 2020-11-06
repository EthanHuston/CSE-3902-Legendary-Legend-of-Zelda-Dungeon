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
        HUDNumber[] numRupees;
        int linkRupeeCount;
        HUDNumber[] numKeys;
        int linkKeyCount;
        ISprite minimapSprite;
        bool displayMinimap;

        public HUD(List<IPlayer> players)
        {
            this.players = players;
            hudSprite = HUDSpriteFactory.Instance.CreateHUDSprite();
            minimapSprite = HUDSpriteFactory.Instance.CreateMiniMapSprite();
            levelNum = new HUDNumber(1);
            numRupees = new HUDNumber[3];
            numKeys = new HUDNumber[3];
            initNumberArrays();
            displayMinimap = false;
            linkRupeeCount = -20;
            linkKeyCount = -20;
        }

        private void initNumberArrays()
        {
            for(int i = 0; i < 3; i++)
            {
                numRupees[i] = new HUDNumber(10);
                numKeys[i] = new HUDNumber(10);
            }
        }

        public void Update()
        {
            if (players[0].GetQuantityInInventory(LinkConstants.ItemType.Map) != 0)
                displayMinimap = true;
            if(players[0].GetQuantityInInventory(LinkConstants.ItemType.Rupee) != linkRupeeCount)
                UpdateNumRupees();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            hudSprite.Draw(spriteBatch, position);
            levelNum.Draw(spriteBatch, GameStateConstants.LevelNumberLocation);
            if (displayMinimap)
                minimapSprite.Draw(spriteBatch, GameStateConstants.MinimapLocation);
            DrawNumRupees(spriteBatch);
        }

        private void DrawNumRupees(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < numRupees.Length; i++)
            {
                Point position = new Point(HUDConstants.RupeeNumberX + i * HUDConstants.NumberWidth, HUDConstants.RupeeNumberY);
                numRupees[i].Draw(spriteBatch, position);
            }
        }

        private void UpdateNumRupees()
        {
            numRupees[0].AssignNumber(-1);
            linkRupeeCount = players[0].GetQuantityInInventory(LinkConstants.ItemType.Rupee);
            int tensPlace = linkRupeeCount;
            int remainder = tensPlace % 10;
            tensPlace /= 10;
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
    }
}

using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.HUDClasses
{
    internal class NumberManager
    {
        private LinkPlayer link;
        private HUDNumber[] numRupees;
        private HUDNumber[] numKeys;
        private HUDNumber[] numBombs;
        private int linkRupeeCount = -20; //These will be changed on the first update
        private int linkKeyCount = -20;
        private int linkBombCount = -20;

        public NumberManager(LinkPlayer link)
        {
            this.link = link;
            InitNumberArrays();
        }

        private void InitNumberArrays()
        {
            numRupees = new HUDNumber[3];
            numKeys = new HUDNumber[3];
            numBombs = new HUDNumber[3];

            //-1 assigns the HUDNumber to the "X"
            numRupees[0] = new HUDNumber(-1);
            numKeys[0] = new HUDNumber(-1);
            numBombs[0] = new HUDNumber(-1);

            for (int i = 1; i < 3; i++)
            {
                //10 assigns the HUDNumber to the black square
                numRupees[i] = new HUDNumber(10);
                numKeys[i] = new HUDNumber(10);
                numBombs[i] = new HUDNumber(10);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point hudPosition)
        {
            DrawNumRupees(spriteBatch, hudPosition);
            DrawNumKeys(spriteBatch, hudPosition);
            DrawNumBombs(spriteBatch, hudPosition);
        }

        public void Update()
        {
            
            if (link.GetQuantityInInventory(LinkConstants.ItemType.Rupee) != linkRupeeCount)
                UpdateNumRupees();
            if (link.GetQuantityInInventory(LinkConstants.ItemType.Key) != linkKeyCount)
                UpdateNumKeys();
            if (link.GetQuantityInInventory(LinkConstants.ItemType.Bomb) != linkBombCount)
                UpdateNumBombs();
        }

        private void DrawNumRupees(SpriteBatch spriteBatch, Point hudPosition)
        {
            for (int i = 0; i < numRupees.Length; i++)
            {
                Point position = new Point(HUDConstants.RupeeNumberX + i * HUDConstants.NumberWidth, HUDConstants.RupeeNumberY);
                numRupees[i].Draw(spriteBatch, hudPosition + position, Constants.DrawLayer.MenuIcon);
            }
        }
        private void DrawNumKeys(SpriteBatch spriteBatch, Point hudPosition)
        {
            for (int i = 0; i < numKeys.Length; i++)
            {
                Point position = new Point(HUDConstants.KeyNumberX + i * HUDConstants.NumberWidth, HUDConstants.KeyNumberY);
                numKeys[i].Draw(spriteBatch, hudPosition + position, Constants.DrawLayer.MenuIcon);
            }
        }
        private void DrawNumBombs(SpriteBatch spriteBatch, Point hudPosition)
        {
            for (int i = 0; i < numBombs.Length; i++)
            {
                Point position = new Point(HUDConstants.BombNumberX + i * HUDConstants.NumberWidth, HUDConstants.BombNumberY);
                numBombs[i].Draw(spriteBatch, hudPosition + position, Constants.DrawLayer.MenuIcon);
            }
        }

        private void UpdateNumRupees()
        {
            linkRupeeCount = link.GetQuantityInInventory(LinkConstants.ItemType.Rupee);
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
            linkKeyCount = link.GetQuantityInInventory(LinkConstants.ItemType.Key);
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
            linkBombCount = link.GetQuantityInInventory(LinkConstants.ItemType.Bomb);
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

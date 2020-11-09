using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.HUDClasses
{
    internal class HeartManager : ISpawnable
    {
        private LinkPlayer link;
        private HUDHeart[] hearts;
        private double linkHealth;
        private Point position;

        public HeartManager(LinkPlayer link)
        {
            this.link = link;
            linkHealth = link.CurrentHealth;
            hearts = new HUDHeart[LinkConstants.StartingHearts / Constants.HeartValue];
            for(int i = 0; i < hearts.Length; i++)
                hearts[i] = new HUDHeart(2);
        }


        public Point Position { get => position; set => position = new Point(value.X, value.Y); }

        public void Despawn()
        {
            throw new System.NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch, Point hudPosition)
        {
            for(int i = 0; i < hearts.Length; i++)
            {
                Point heartPosition = new Point(HUDConstants.HeartX + i * HUDConstants.NumberWidth, HUDConstants.HeartY);
                hearts[i].Draw(spriteBatch, hudPosition + heartPosition);
            }
                
        }

        public void Draw()
        {
            throw new System.NotImplementedException();
        }

        public Rectangle GetRectangle()
        {
            throw new System.NotImplementedException();
        }

        public bool SafeToDespawn()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            if(link.CurrentHealth != linkHealth)
            {
                UpdateHearts();
            }
        }

        private void UpdateHearts()
        {
            linkHealth = (int)link.CurrentHealth;
            int tensPlace = (int)linkHealth / 10;
            int onesPlace = (int)linkHealth % 10;
            for(int i = 0; i < hearts.Length; i++)
            {
                if (i < tensPlace)
                    hearts[i].AssignNumber(2);
                else if (i == tensPlace && onesPlace > 4)
                    hearts[i].AssignNumber(1);
                else
                    hearts[i].AssignNumber(0);
            }
        }
    }
}

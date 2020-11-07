using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.HUDClasses
{
    internal class HeartManager
    {
        private LinkPlayer link;
        private HUDHeart[] hearts;
        private int linkHealth;

        public HeartManager(LinkPlayer link)
        {
            this.link = link;
            linkHealth = link.GetHealth;
            hearts = new HUDHeart[LinkConstants.StartingHealth / Constants.HeartValue];
            for(int i = 0; i < hearts.Length; i++)
                hearts[i] = new HUDHeart(2);
        }

        public void Draw(SpriteBatch spriteBatch, Point hudPosition)
        {
            for(int i = 0; i < hearts.Length; i++)
            {
                Point heartPosition = new Point(HUDConstants.HeartX + i * HUDConstants.NumberWidth, HUDConstants.HeartY);
                hearts[i].Draw(spriteBatch, hudPosition + heartPosition);
            }
                
        }

        public void Update()
        {
            if(link.GetHealth != linkHealth)
            {
                UpdateHearts();
            }
        }

        private void UpdateHearts()
        {
            linkHealth = link.GetHealth;
            int tensPlace = linkHealth / 10;
            int onesPlace = linkHealth % 10;
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

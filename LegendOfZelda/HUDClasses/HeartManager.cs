using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.HUDClasses
{
    internal class HeartManager
    {
        private IPlayer link;
        private List<HUDHeart> hearts;
        private double linkHealth;

        public HeartManager(IPlayer link)
        {
            this.link = link;
            linkHealth = link.CurrentHealth;
            hearts = new List<HUDHeart>();
            UpdateTotalHeartList();
        }

        public void Draw(SpriteBatch spriteBatch, Point hudPosition)
        {
            for(int i = 0; i < hearts.Count; i++)
            {
                Point heartPosition = new Point(HUDConstants.HeartX + i * HUDConstants.NumberWidth, HUDConstants.HeartY);
                hearts[i].Draw(spriteBatch, hudPosition + heartPosition);
            }
                
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
            UpdateTotalHeartList();
            linkHealth = (int)link.CurrentHealth;
            int tensPlace = (int)linkHealth / 10;
            int onesPlace = (int)linkHealth % 10;
            for(int i = 0; i < hearts.Count; i++)
            {
                if (i < tensPlace)
                    hearts[i].AssignNumber(2);
                else if (i == tensPlace && onesPlace > 4)
                    hearts[i].AssignNumber(1);
                else
                    hearts[i].AssignNumber(0);
            }
        }

        private void UpdateTotalHeartList()
        {
            while(hearts.Count < link.MaxHealth / Constants.HeartValue)
            {
                hearts.Add(new HUDHeart(2));
            }
        }
    }
}

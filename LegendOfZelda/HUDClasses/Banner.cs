using LegendOfZelda.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.HUDClasses
{
    internal class Banner
    {
        public SpriteBatch spriteBatch;
        private readonly BannerLink link;
        private List<BannerEnemy> enemyList;
        private readonly int enemyListLen = 6;
        public int loopCount;
        private readonly int posy = (int)(4 * Constants.GameScaler);
        private readonly int xGap = (int)(24 * Constants.GameScaler);

        public Banner(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            link = new BannerLink(this, new Point(0, posy));
            InitEnemyList();
            loopCount = 0;
        }

        public void Update()
        {
            link.Update();
            if (loopCount > enemyListLen)
                loopCount = enemyListLen;
            for(int i = 0; i < loopCount; i++)
            {
                enemyList[i].Update();
            }
        }

        public void Draw()
        {
            link.Draw();
            for(int i = 0; i < enemyListLen; i++)
            {
                enemyList[i].Draw(spriteBatch);
            }
        }

        private void InitEnemyList()
        {
            enemyList = new List<BannerEnemy>();
            Point pos = new Point(HUDConstants.hudWidth + 2*xGap, posy);
            enemyList.Add(new BannerEnemy(EnemySpriteFactory.Instance.CreateBatSprite(), pos));
            pos = new Point(pos.X + xGap, pos.Y);
            enemyList.Add(new BannerEnemy(EnemySpriteFactory.Instance.CreateSkeletonSprite(), pos));
            pos = new Point(pos.X + xGap, pos.Y);
            enemyList.Add(new BannerEnemy(EnemySpriteFactory.Instance.CreateJellySprite(), pos));
            pos = new Point(pos.X + xGap, pos.Y);
            enemyList.Add(new BannerEnemy(EnemySpriteFactory.Instance.CreateGoriyaLeftSprite(), pos));
            pos = new Point(pos.X + xGap, pos.Y);
            enemyList.Add(new BannerEnemy(EnemySpriteFactory.Instance.CreateHandSprite(), pos));
            pos = new Point(pos.X + xGap, pos.Y);
            enemyList.Add(new BannerEnemy(EnemySpriteFactory.Instance.CreateAquamentusWalkingSprite(), pos));
        }
    }
}

using LegendOfZelda.Link;
using Microsoft.Xna.Framework.Content;

namespace LegendOfZelda
{
    //Sprite Factory based of model found in slides
    class SpriteFactory
    {
        public static SpriteFactory Instance { get; } = new SpriteFactory();

        public void LoadAllTextures(ContentManager content)
        {
            // Load SpriteFactory
            LinkSpriteFactory.Instance.LoadAllTextures(content);
            EnemySpriteFactory.Instance.LoadAllTextures(content);
            ItemSpriteFactory.Instance.LoadAllTextures(content);
            ProjectileSpriteFactory.Instance.LoadAllTextures(content);
        }
    }
}

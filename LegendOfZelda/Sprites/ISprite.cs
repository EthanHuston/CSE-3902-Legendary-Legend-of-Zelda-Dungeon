using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public interface ISprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, int XValue, int YValue);
    }
}

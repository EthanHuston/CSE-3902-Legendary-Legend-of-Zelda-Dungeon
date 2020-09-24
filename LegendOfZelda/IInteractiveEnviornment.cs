using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    interface IInteractiveEnviornment
    {
        void Update();

        void Draw(SpriteBatch spriteBatch);
    }
}

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LegendOfZelda.Enemies
{
    public interface IEnemy
    {
        void Update();

        void Draw();
    }
}

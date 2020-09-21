using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    interface IPlayer
    {
        void TakeDamage(int damage);
        void Heal(int healAmount);
        void Update();
        void Draw();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link
{
    interface ILinkState
    {
        void MoveLeft();
        void MoveRight();
        void MoveDown();
        void MoveUp();
        void BeDamaged();
        void BeHealthy();
        void StopMoving();
    }
}

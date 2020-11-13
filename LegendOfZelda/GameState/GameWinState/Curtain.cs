using LegendOfZelda.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.GameState.GameWinState
{
    class Curtain
    {
        private ISprite blackOverlaySpriteLeft;
        private ISprite blackOverlaySpriteRight;

        public Curtain()
        {
            blackOverlaySpriteLeft = GameStateSpriteFactory.Instance.CreateBlackOverlaySprite();
            blackOverlaySpriteRight = GameStateSpriteFactory.Instance.CreateBlackOverlaySprite();
        }

        public void Draw()
        {

        }

        public void Update()
        {

        }
    }
}

﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    class Fire : IInteractiveEnviornment
    {
        private FireSprite fireSprite;
        private SpriteBatch sB;
        public Fire(SpriteBatch spriteBatch)
        {
            fireSprite = (FireSprite)SpriteFactory.Instance.CreateFireSprite();
            sB = spriteBatch;
        }

        public void Draw()
        {
            fireSprite.Draw(sB, ConstantsSprint2.ieX, ConstantsSprint2.ieY);
        }

        public void Interaction()
        {
            //Update
        }

    }
}
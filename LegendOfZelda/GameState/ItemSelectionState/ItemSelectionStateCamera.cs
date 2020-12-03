using LegendOfZelda.GameLogic;
using LegendOfZelda.Menu;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    internal class ItemSelectionStateCamera : ICamera
    {
        private readonly IMenu hud;
        private readonly List<IMenu> inventorySelectionSpawnables;
        private Vector2 velocityWhenPan;
        private int distanceToPan;
        private int distancePanned;

        public bool IsPanning { get; private set; }

        public ItemSelectionStateCamera(IMenu hud, List<IMenu> inventorySpawnablesList)
        {
            this.hud = hud;
            inventorySelectionSpawnables = inventorySpawnablesList;
            IsPanning = false;
        }

        public void Draw()
        {
            foreach (IMenu spawnable in inventorySelectionSpawnables) spawnable.Draw();
            hud.Draw();
        }

        public void Pan(Vector2 velocity, int distance)
        {
            IsPanning = true;
            velocityWhenPan = velocity;
            distanceToPan = distance;
            distancePanned = 0;
        }

        public void ReversePan()
        {
            IsPanning = true;
            distancePanned = 0;
            velocityWhenPan = new Vector2(velocityWhenPan.X * -1, velocityWhenPan.Y * -1);
        }

        public void Update()
        {
            if (IsPanning)
            {
                Vector2 moveVector = new Vector2(velocityWhenPan.X, velocityWhenPan.Y);
                distancePanned += (int)velocityWhenPan.Length();

                if (distancePanned > distanceToPan)
                {
                    IsPanning = false;
                    moveVector.Normalize();
                    moveVector *= distanceToPan - (distancePanned - (int)velocityWhenPan.Length());
                }

                foreach (IMenu spawnable in inventorySelectionSpawnables) spawnable.Position += moveVector.ToPoint();
                hud.Position += moveVector.ToPoint();
            }
        }
    }
}

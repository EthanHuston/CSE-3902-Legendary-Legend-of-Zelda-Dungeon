using LegendOfZelda.GameLogic;
using LegendOfZelda.HUDClasses;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    class ItemSelectionStateCamera : ICamera
    {
        private readonly HUD hud;
        private readonly List<IMenu> inventorySelectionSpawnables;
        private Vector2 velocityWhenPan;
        private int distanceToPan;
        private int distancePanned;

        public bool IsPanning { get; private set; }

        public ItemSelectionStateCamera(HUD hud, List<IMenu> inventorySpawnablesList)
        {
            this.hud = hud;
            inventorySelectionSpawnables = inventorySpawnablesList;
            IsPanning = false;
        }

        public void Draw()
        {
            foreach (ISpawnable spawnable in inventorySelectionSpawnables) spawnable.Draw();
            // draw hud
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
            IsPanning = distancePanned < distanceToPan;
            if (IsPanning)
            {
                foreach (ISpawnable spawnable in inventorySelectionSpawnables) spawnable.Position += velocityWhenPan.ToPoint();
                // hud.Position += velocityWhenPan.ToPoint();
                distancePanned += (int) velocityWhenPan.Length();
            }
        }
    }
}

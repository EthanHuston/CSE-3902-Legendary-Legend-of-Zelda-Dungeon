using LegendOfZelda.Link.Interface;
using System.Collections.Generic;

namespace LegendOfZelda.Link.Items
{
    class LinkSpawnedItems : ISpawnedItems
    {
        private List<ILinkItem> spawnedItemList;
        private Dictionary<Constants.Item, bool> ItemIsSpawnable; // key is an item, value is true if item can be spawned, else false
        public LinkSpawnedItems()
        {
            ItemIsSpawnable = new Dictionary<Constants.Item, bool>()
            {
                // initialize to true because nothing has been spawned yet
                { Constants.Item.ArrowFlying, true },
                { Constants.Item.BombExploding, true },
                { Constants.Item.BoomerangFlying, true },
                { Constants.Item.SwordBeamFlying, true }
            };
        }

        public bool SpawnNewItem(ILinkItem item)
        {
            switch (item.GetItemType())
            {
                case Constants.Item.ArrowFlying:
                    return SpawnNewArrow(item);
                case Constants.Item.BombExploding:
                    return SpawnNewBomb(item);
                case Constants.Item.BoomerangFlying:
                    return SpawnNewBoomerang(item);
                case Constants.Item.SwordBeamFlying:
                    return SpawnNewSwordBeam(item);
                default:
                    return false;
            }
        }

        public void DrawAll()
        {
            for (int i = 0; i < spawnedItemList.Count; i++)
            {
                spawnedItemList[i].Draw();
            }
        }

        public void UpdateAll()
        {
            List<int> indicesToRemove = new List<int>();
            for (int i = 0; i < spawnedItemList.Count; i++)
            {
                ILinkItem item = spawnedItemList[i];
                item.Update();
                if (item.SafeToDespawn())
                {
                    indicesToRemove.Add(i);
                    ToggleSpawnable(item.GetItemType());
                }
            }

            for (int i = 0; i < indicesToRemove.Count; i++)
            {
                spawnedItemList.RemoveAt(indicesToRemove[i]);
            }
        }

        private bool SpawnNewArrow(ILinkItem item)
        {
            if (ItemIsSpawnable[Constants.Item.ArrowFlying] == false) return false; // exit if it cannot be spawned right now
            ToggleSpawnableForArrow();

            spawnedItemList.Add(item);

            return true;
        }

        private bool SpawnNewBomb(ILinkItem item)
        {
            if (ItemIsSpawnable[Constants.Item.BombExploding] == false) return false; // exit if it cannot be spawned right now
            ToggleSpawnableForBomb();

            spawnedItemList.Add(item);

            return true;
        }

        private bool SpawnNewSwordBeam(ILinkItem item)
        {
            if (ItemIsSpawnable[Constants.Item.SwordBeamFlying] == false) return false; // exit if it cannot be spawned right now
            ToggleSpawnableForSwordBeam();

            spawnedItemList.Add(item);

            return true;
        }

        private bool SpawnNewBoomerang(ILinkItem item)
        {
            if (ItemIsSpawnable[Constants.Item.BoomerangFlying] == false) return false; // exit if it cannot be spawned right now
            ToggleSpawnableForBoomerang();

            spawnedItemList.Add(item);

            return true;
        }

        private void ToggleSpawnable(Constants.Item itemType)
        {
            switch (itemType)
            {
                case Constants.Item.ArrowFlying:
                    ToggleSpawnableForArrow();
                    break;
                case Constants.Item.BombExploding:
                    ToggleSpawnableForBomb();
                    break;
                case Constants.Item.BoomerangFlying:
                    ToggleSpawnableForBoomerang();
                    break;
                case Constants.Item.SwordBeamFlying:
                    ToggleSpawnableForSwordBeam();
                    break;
            }
        }

        private void ToggleSpawnableForArrow()
        {
            ItemIsSpawnable[Constants.Item.ArrowFlying] = !ItemIsSpawnable[Constants.Item.ArrowFlying];
            ItemIsSpawnable[Constants.Item.BoomerangFlying] = !ItemIsSpawnable[Constants.Item.BoomerangFlying];
        }
        private void ToggleSpawnableForBoomerang()
        {
            ItemIsSpawnable[Constants.Item.BoomerangFlying] = !ItemIsSpawnable[Constants.Item.BoomerangFlying];
            ItemIsSpawnable[Constants.Item.ArrowFlying] = !ItemIsSpawnable[Constants.Item.ArrowFlying];
        }

        private void ToggleSpawnableForBomb()
        {
            ItemIsSpawnable[Constants.Item.BombExploding] = !ItemIsSpawnable[Constants.Item.BombExploding];
        }

        private void ToggleSpawnableForSwordBeam()
        {
            ItemIsSpawnable[Constants.Item.SwordBeamFlying] = !ItemIsSpawnable[Constants.Item.SwordBeamFlying];
        }
    }
}

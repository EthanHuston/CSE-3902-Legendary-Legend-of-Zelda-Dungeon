using LegendOfZelda.Link.Interface;
using System.Collections.Generic;

namespace LegendOfZelda.Link.Items
{
    class LinkSpawnedItems : ISpawnedItems
    {
        private List<ILinkItem> spawnedItemList = new List<ILinkItem>();
        private Dictionary<Constants.Item, bool> ItemIsSpawnable; // key is an item, value is true if item can be spawned, else false
        public LinkSpawnedItems()
        {
            ItemIsSpawnable = new Dictionary<Constants.Item, bool>()
            {
                // initialize to true because nothing has been spawned yet
                { Constants.Item.Arrow, true },
                { Constants.Item.Bomb, true },
                { Constants.Item.Boomerang, true }
            };
        }

        public bool SpawnNewItem(ILinkItem item)
        {
            switch (item.GetItemType())
            {
                case Constants.Item.Arrow:
                    return SpawnNewArrow(item);
                case Constants.Item.Bomb:
                    return SpawnNewBomb(item);
                case Constants.Item.Boomerang:
                    return SpawnNewBoomerang(item);
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
            if (ItemIsSpawnable[Constants.Item.Arrow] == false) return false; // exit if it cannot be spawned right now
            ToggleSpawnableForArrow();

            spawnedItemList.Add(item);

            return true;
        }

        private bool SpawnNewBomb(ILinkItem item)
        {
            if (ItemIsSpawnable[Constants.Item.Bomb] == false) return false; // exit if it cannot be spawned right now
            ToggleSpawnableForBomb();

            spawnedItemList.Add(item);

            return true;
        }

        private bool SpawnNewBoomerang(ILinkItem item)
        {
            if (ItemIsSpawnable[Constants.Item.Boomerang] == false) return false; // exit if it cannot be spawned right now
            ToggleSpawnableForBoomerang();

            spawnedItemList.Add(item);

            return true;
        }

        private void ToggleSpawnable(Constants.Item itemType)
        {
            switch (itemType)
            {
                case Constants.Item.Arrow:
                    ToggleSpawnableForArrow();
                    break;
                case Constants.Item.Bomb:
                    ToggleSpawnableForBomb();
                    break;
                case Constants.Item.Boomerang:
                    ToggleSpawnableForBoomerang();
                    break;
            }
        }

        private void ToggleSpawnableForArrow()
        {
            ItemIsSpawnable[Constants.Item.Arrow] = !ItemIsSpawnable[Constants.Item.Arrow];
            ItemIsSpawnable[Constants.Item.Boomerang] = !ItemIsSpawnable[Constants.Item.Boomerang];
        }
        private void ToggleSpawnableForBoomerang()
        {
            ItemIsSpawnable[Constants.Item.Boomerang] = !ItemIsSpawnable[Constants.Item.Boomerang];
            ItemIsSpawnable[Constants.Item.Arrow] = !ItemIsSpawnable[Constants.Item.Arrow];
        }

        private void ToggleSpawnableForBomb()
        {
            ItemIsSpawnable[Constants.Item.Bomb] = !ItemIsSpawnable[Constants.Item.Bomb];
        }
    }
}

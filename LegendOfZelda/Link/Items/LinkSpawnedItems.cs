using Sprint0.Link.Interface;
using System.Collections.Generic;

namespace Sprint0.Link.Items
{
    class LinkSpawnedItems : ISpawnedItems
    {
        private List<ILinkItem> spawnedItemList = new List<ILinkItem>();
        private Dictionary<Constants.Items, bool> ItemIsSpawnable; // key is an item, value is true if item can be spawned, else false
        public LinkSpawnedItems()
        {
            ItemIsSpawnable = new Dictionary<Constants.Items, bool>()
            {
                // initialize to true because nothing has been spawned yet
                { Constants.Items.Arrow, true },
                { Constants.Items.Bomb, true },
                { Constants.Items.Boomerang, true }
            };
        }

        public bool AddNewArrow(ILinkItem item)
        {
            if (ItemIsSpawnable[Constants.Items.Arrow] == false) return false; // exit if it cannot be spawned right now
            ToggleSpawnableForArrow();

            return true;
        }

        public bool AddNewBomb(ILinkItem item)
        {
            if (ItemIsSpawnable[Constants.Items.Bomb] == false) return false; // exit if it cannot be spawned right now
            ToggleSpawnableForBomb();
            return true;
        }

        public bool AddNewBoomerang(ILinkItem item)
        {
            if (ItemIsSpawnable[Constants.Items.Boomerang] == false) return false; // exit if it cannot be spawned right now
            ToggleSpawnableForBoomerang();
            return true;
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

        private void ToggleSpawnable(Constants.Items itemType)
        {
            switch (itemType)
            {
                case Constants.Items.Arrow:
                    ToggleSpawnableForArrow();
                    break;
                case Constants.Items.Bomb:
                    ToggleSpawnableForBomb();
                    break;
                case Constants.Items.Boomerang:
                    ToggleSpawnableForBoomerang();
                    break;
            }
        }

        private void ToggleSpawnableForArrow()
        {
            ItemIsSpawnable[Constants.Items.Arrow] = !ItemIsSpawnable[Constants.Items.Arrow];
            ItemIsSpawnable[Constants.Items.Boomerang] = !ItemIsSpawnable[Constants.Items.Boomerang];
        }
        private void ToggleSpawnableForBoomerang()
        {
            ItemIsSpawnable[Constants.Items.Boomerang] = !ItemIsSpawnable[Constants.Items.Boomerang];
            ItemIsSpawnable[Constants.Items.Arrow] = !ItemIsSpawnable[Constants.Items.Arrow];
        }

        private void ToggleSpawnableForBomb()
        {
            ItemIsSpawnable[Constants.Items.Bomb] = !ItemIsSpawnable[Constants.Items.Bomb];
        }
    }
}

namespace Sprint0.Link.Interface
{
    interface ISpawnedItems
    {
        void UpdateAll();
        void DrawAll();
        bool AddNewBomb(ILinkItem item);
        bool AddNewArrow(ILinkItem item);
        bool AddNewBoomerang(ILinkItem item);
    }
}

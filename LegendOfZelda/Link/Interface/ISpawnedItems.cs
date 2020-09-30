namespace Sprint0.Link.Interface
{
    interface ISpawnedItems
    {
        void UpdateAll();
        void DrawAll();
        bool SpawnNewItem(ILinkItem item);
    }
}

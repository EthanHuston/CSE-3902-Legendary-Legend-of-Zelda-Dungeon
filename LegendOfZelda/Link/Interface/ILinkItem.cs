namespace Sprint0.Link.Interface
{
    interface ILinkItem
    {
        void Update();
        void Draw();
        bool SafeToDespawn();
        Constants.Item GetItemType();
    }
}

namespace LegendOfZelda.Link.Interface
{
    interface ILinkItem
    {
        void Update();
        void Draw();
        bool SafeToDespawn();
        Constants.Item GetItemType();
    }
}

using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Link.Interface;
using System;

namespace LegendOfZelda.Link.CollisionHandler.WithBlock
{
    internal class LinkStairsCollisionHandler : ICollisionHandler<IPlayer, IBlock>
    {
        private const int linkMoveDistance = 1;

        public void HandleCollision(IPlayer link, IBlock block, Constants.Direction side)
        {
            SoundFactory.Instance.CreateStairsSound();
            // TODO: implement me
            throw new NotImplementedException();
        }
    }
}

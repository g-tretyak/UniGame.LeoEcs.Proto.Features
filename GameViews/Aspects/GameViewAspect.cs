namespace unigame.ecs.proto.Gameplay.LevelProgress.Aspects
{
    using System;
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class GameViewAspect : EcsAspect
    {
        public ProtoPool<GameViewComponent> View;
        public ProtoPool<GameObjectComponent> GameObject;
        public ProtoPool<OwnerComponent> Owner;
    }
}
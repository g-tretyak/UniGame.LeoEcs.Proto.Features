namespace unigame.ecs.proto.Gameplay.LevelProgress.Aspects
{
    using System;
    using Components;
     
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class ParentGameViewAspect : EcsAspect
    {
        public ProtoPool<GameViewParentComponent> Parent;
        public ProtoPool<ActiveGameViewComponent> ActiveView;
        public ProtoPool<GameObjectComponent> View;
        
        //requests
        public ProtoPool<ActivateGameViewRequest> Activate;
        public ProtoPool<DisableActiveGameViewRequest> Disable;
    }
}
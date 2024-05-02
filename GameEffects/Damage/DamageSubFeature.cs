namespace UniGame.Ecs.Proto.Gameplay.Damage
{
    using System.Collections.Generic;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime;

    public abstract class DamageSubFeature : BaseLeoEcsFeature
    {
        public override UniTask InitializeAsync(IProtoSystems ecsSystems)
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask BeforeDamageSystem(IProtoSystems ecsSystems)
        {
            return UniTask.CompletedTask;
        }
        
        public virtual UniTask AfterDamageSystem(IProtoSystems ecsSystems)
        {
            return UniTask.CompletedTask;
        }
        
    }
}
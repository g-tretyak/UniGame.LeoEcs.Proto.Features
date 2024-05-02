namespace UniGame.Ecs.Proto.Input
{
    using Systems;
    using Components.Ability;
    using Components.Direction;
    using Cysharp.Threading.Tasks;
    using JetBrains.Annotations;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Map.Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;

    [UsedImplicitly]
    public sealed class InputFeature : EcsFeature
    {
        protected override UniTask OnInitializeAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new MapSpaceInitializeSystem());
            ecsSystems.DelHere<DirectionInputEvent>();
            ecsSystems.Add(new DirectionRawMapConvertSystem());

            ecsSystems.DelHere<AbilityCellVelocityEvent>();
            ecsSystems.Add(new AbilityVelocityRawConvertSystem());
            
            ecsSystems.Add(new ProcessAbilityActiveTimeSystem());
            ecsSystems.Add(new ClearAbilityInputStateSystem());

            return UniTask.CompletedTask;
        }
    }
}
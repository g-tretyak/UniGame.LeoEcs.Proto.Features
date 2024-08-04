namespace UniGame.Ecs.Proto.Ability.SubFeatures.Area.Behaviours
{
    using System;
    using Components;
    using Game.Code.Configuration.Runtime.Ability.Description;
    using Leopotam.EcsProto;
    using Target.Components;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;
    using UserInput.Components;

    [Serializable]
    public sealed class AreableBehaviour : IAbilityBehaviour
    {
        [SerializeField]
        private float _areaRadius;
        [SerializeField]
        private GameObject _areaView;
        
        public void Compose(ProtoWorld world, ProtoEntity abilityEntity)
        {
            var targetsPool = world.GetPool<AbilityTargetsComponent>();
            targetsPool.Add(abilityEntity);

            var areablePool = world.GetPool<AreableAbilityComponent>();
            areablePool.Add(abilityEntity);

            var areaRadiusPool = world.GetPool<AreaRadiusComponent>();
            ref var areaRadius = ref areaRadiusPool.Add(abilityEntity);
            areaRadius.Value = _areaRadius;

            var areaRadiusViewPool = world.GetPool<AreaRadiusViewComponent>();
            ref var areaRadiusView = ref areaRadiusViewPool.Add(abilityEntity);
            areaRadiusView.View = _areaView;
            
            var upPool = world.GetPool<CanApplyWhenUpInputComponent>();
            
            if(!upPool.Has(abilityEntity))
                upPool.Add(abilityEntity);
        }

        public void DrawGizmos(GameObject target)
        {
        }
    }
}
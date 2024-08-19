namespace UniGame.Ecs.Proto.Ability.SubFeatures.AbilitySequence.Systems
{
    using System;
    using System.Collections.Generic;
    using Ability.Aspects;
    using Aspects;
    using AbilitySequence;
    using Cysharp.Threading.Tasks;
    using Game.Code.Services.Ability;
    using Game.Code.Services.AbilityLoadout.Data;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.AddressableTools.Runtime;
    using UniGame.Core.Runtime;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

    /// <summary>
    /// create ability sequence
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class CreateAbilitySequenceByReferenceSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private ILifeTime _worldLifeTime;

        private AbilityAspect _abilityTools;
        private AbilitySequenceAspect _aspect;

        private ProtoItExc _createRequestFilter = It
            .Chain<CreateAbilitySequenceReferenceSelfRequest>()
            .Exc<CreateAbilitySequenceSelfRequest>()
            .End();

        public void Run()
        {
            foreach (var requestEntity in _createRequestFilter)
            {
                ref var requestComponent = ref _aspect.CreateByReference.Get(requestEntity);
                var reference = requestComponent.Reference;
                var sequence = reference.sequence;

                if (sequence.Count <= 0) continue;

                ref var createSequenceRequest = ref _aspect
                    .Create
                    .Add(requestEntity);

                createSequenceRequest.Owner = requestComponent.Owner;
                createSequenceRequest.Name = reference.name;
                var abilities = createSequenceRequest.Abilities;
                var owner = requestComponent.Owner;

                var tasks = sequence
                    .Select(x => AddAbilityToSequence(x, abilities, owner));
                
                ExecuteInOrder(tasks,requestEntity).Forget();
            }
        }

        private async UniTask ExecuteInOrder(IEnumerable<UniTask> tasks, ProtoEntity entity)
        {
            foreach (var task in tasks)
                await task;
            _aspect.CreateById.Del(entity);
        }

        private async UniTask AddAbilityToSequence(
            AbilityConfigurationValue value,
            List<ProtoEntity> abilities,
            ProtoPackedEntity owner)
        {
            //load configuration sync
            var configuration = await value
                .reference
                .LoadAssetInstanceTaskAsync(_worldLifeTime, true);

            var abilityEntity = _abilityTools
                .EquipAbilityByReference(ref owner, configuration, AbilitySlotId.EmptyAbilitySlot);

            abilities.Add(abilityEntity);
        }
    }
}
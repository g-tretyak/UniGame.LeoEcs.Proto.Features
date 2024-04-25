namespace unigame.ecs.proto.Ability.SubFeatures.AbilitySequence.Tools
{
    using System.Collections.Generic;
    using Aspects;
    using Data;
    using Game.Code.Configuration.Runtime.Ability.Description;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    [ECSDI]
    public class AbilitySequenceTools: IProtoInitSystem
    {
        public const string SequenceNameTemplate = "{0}_{1}_ability_sequence";
        
        private ProtoWorld _world;
        
        public AbilitySequenceAspect sequenceAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
        }
        
        public ProtoEntity CreateAbilitySequence(ProtoEntity ownerEntity,IReadOnlyList<AbilityId> abilityIds,string name)
        {
            var requestEntity = _world.NewEntity();
            ref var createRequest = ref sequenceAspect.CreateById.Add(requestEntity);
            createRequest.Owner = ownerEntity.PackedEntity(_world);
            createRequest.Abilities.Clear();
            createRequest.Abilities.AddRange(abilityIds);
            createRequest.Name = name;
            return requestEntity;
        }
        
        public ProtoEntity CreateAbilitySequence(ref ProtoPackedEntity ownerEntity,AbilitySequenceReference sequence)
        {
            var requestEntity = _world.NewEntity();
            ref var createRequest = ref sequenceAspect.CreateByReference.Add(requestEntity);
            createRequest.Owner = ownerEntity;
            createRequest.Reference = sequence;
            return requestEntity;
        }


    }
}
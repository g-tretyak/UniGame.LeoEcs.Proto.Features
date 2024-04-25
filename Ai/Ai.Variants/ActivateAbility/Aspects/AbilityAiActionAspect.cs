namespace Game.Code.Ai.ActivateAbility.Aspects
{
    using System;
    using Ecs.Core.Components;
    using Leopotam.EcsProto;
    using unigame.ecs.proto.Ability.Common.Components;
    using unigame.ecs.proto.Characteristics.Radius.Component;
    using unigame.ecs.proto.GameAi.ActivateAbility;
    using unigame.ecs.proto.GameAi.ActivateAbility.Components;
    using unigame.ecs.proto.GameLayers.Category.Components;
    using unigame.ecs.proto.GameLayers.Layer.Components;
    using unigame.ecs.proto.GameLayers.Relationship.Components;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class AbilityAiActionAspect : EcsAspect
    {
        public ProtoPool<RadiusComponent> Radius;
        public ProtoPool<RelationshipIdComponent> Relationship;
        public ProtoPool<CategoryIdComponent> Category;
        public ProtoPool<TransformComponent> Transform;
        public ProtoPool<TransformPositionComponent> Position;
        public ProtoPool<TransformDirectionComponent> Direction;
        public ProtoPool<AbilityActionActiveTargetComponent> ActiveTarget;
        public ProtoPool<LayerIdComponent> LayerId;
        public ProtoPool<EntityAvatarComponent> Avatar;
        public ProtoPool<AbilityAiActionTargetComponent> AiTarget;
        public ProtoPool<AbilityByDefaultComponent> DefaultAbility;
        public ProtoPool<AbilityByRangeComponent> ByRangeAbility;
        public ProtoPool<AbilityRangeActionDataComponent> AbilityRangeData;
        
        //request
        public ProtoPool<ApplyAbilityBySlotSelfRequest> ApplyAbilityFromSlot;
    }
}
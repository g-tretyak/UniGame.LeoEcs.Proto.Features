namespace Game.Code.Ai.ActivateAbility.Aspects
{
    using System;
    using Ecs.Ability.Common.Components;
    using Ecs.Characteristics.Radius.Component;
    using Ecs.Core.Components;
    using Ecs.GameAi.ActivateAbility;
    using Ecs.GameAi.ActivateAbility.Components;
    using Ecs.GameLayers.Category.Components;
    using Ecs.GameLayers.Layer.Components;
    using Ecs.GameLayers.Relationship.Components;
     
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
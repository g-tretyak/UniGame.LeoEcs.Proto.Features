namespace unigame.ecs.proto.Ability.SubFeatures.Target.Components
{
    using System;
    using System.Runtime.CompilerServices;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using TargetSelection;
    using Unity.Mathematics;

    /// <summary>
    /// Цели для применения умения.
    /// </summary>
    public struct AbilityTargetsComponent : IProtoAutoReset<AbilityTargetsComponent>
    {
        public static readonly ProtoPackedEntity Empty = default;
        
        public ProtoPackedEntity[] Entities;
        public int Count;
        
        public ProtoPackedEntity[] PreviousEntities;
        public int PreviousCount;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetEntity(ProtoPackedEntity entities)
        {
            CopyCurrent();
            Count = 1;
            Entities[0] = entities;
            MarkEmpty(Count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetEmpty()
        {
            SetEntities(Array.Empty<ProtoPackedEntity>(),0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetEntities(ProtoPackedEntity[] entities,int count)
        {
            CopyCurrent();

            Count = math.min(count, TargetSelectionData.MaxTargets);

            for (int i = 0; i < Count; i++)
                Entities[i] = entities[i];

            MarkEmpty(Count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AutoReset(ref AbilityTargetsComponent c)
        {
            c.Entities ??= new ProtoPackedEntity[TargetSelectionData.MaxTargets];
            c.Count = 0;
            
            c.PreviousEntities ??=  new ProtoPackedEntity[TargetSelectionData.MaxTargets];
            c.PreviousCount = 0;
            
            c.MarkEmpty(0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void MarkEmpty(int start)
        {
            for (var i = start; i < TargetSelectionData.MaxTargets; i++)
                Entities[i] = Empty;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CopyCurrent()
        {
            PreviousCount = Count;
            for (int i = 0; i < PreviousCount; i++)
                PreviousEntities[i] = Entities[i];
        }
    }
}
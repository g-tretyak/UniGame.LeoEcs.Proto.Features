namespace UniGame.Ecs.Proto.Ability.SubFeatures.Target.Systems
{
	using System;
	using Aspects;
	using Components;
	using Leopotam.EcsLite;
	using Leopotam.EcsProto;
	using Leopotam.EcsProto.QoL;
	using TargetSelection;
	using UniGame.Core.Runtime;
	using UniGame.LeoEcs.Shared.Extensions;
	using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
	using Unity.Collections;

	/// <summary>
	/// Remove non-target from list of targets
	/// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	[Serializable]
	[ECSDI]
	public class RemoveUntargetableTargetSystem : IProtoInitSystem, IProtoRunSystem
	{
		private ProtoWorld _world;
		private EcsFilter _nonTargetsFilter;
		private EcsFilter _filterAbilityTarget;
		private NonTargetAspect _aspect;

		private ILifeTime _lifeTime;
		private ProtoEntity[] _targets = new ProtoEntity[TargetSelectionData.MaxTargets];
		private ProtoPackedEntity[] _resultTargets = new ProtoPackedEntity[TargetSelectionData.MaxTargets];
		private NativeHashSet<ProtoEntity> _targetsHashSet;

		public void Init(IProtoSystems systems)
		{
			_world = systems.GetWorld();
			_lifeTime = _world.GetLifeTime();
			
			_targetsHashSet = new NativeHashSet<ProtoEntity>(
				TargetSelectionData.MaxTargets,
				Allocator.Persistent)
				.AddTo(_lifeTime);
			
			_nonTargetsFilter = _world
				.Filter<UntargetableComponent>()
				.End();
			
			_filterAbilityTarget = _world
				.Filter<AbilityTargetsComponent>()
				.End();
		}

		public void Run()
		{
			foreach (var targetsEntity in _filterAbilityTarget)
			{
				_targetsHashSet.Clear();
				
				ref var abilityTargetsComponent = ref _aspect
					.AbilityTargetsComponent.Get(targetsEntity);

				var amount = 0;

				for (var i = 0; i < abilityTargetsComponent.Count; i++)
				{
					ref var packedEntity = ref abilityTargetsComponent.Entities[i];
					if(!packedEntity.Unpack(_world,out var entity)) continue;
					
					_targets[amount] = entity;
					_targetsHashSet.Add(entity);
					
					amount++;
				}
				
				foreach (var nonTargetEntity in _nonTargetsFilter)
				{
					_targetsHashSet.Remove(nonTargetEntity);
				}

				amount = 0;
				
				foreach (var entity in _targetsHashSet)
				{
					_resultTargets[amount] = _world.PackEntity(entity);
					amount++;
				}
				
				abilityTargetsComponent.SetEntities(_resultTargets, amount);
			}
		}
	}
}
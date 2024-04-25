namespace unigame.ecs.proto.Ability.SubFeatures.Target.Systems
{
	using System;
	using Aspects;
	using Components;
	using Game.Code.GameTools.Runtime;
	using Game.Ecs.Core.Components;
	using Leopotam.EcsLite;
	using Leopotam.EcsProto;
	using Leopotam.EcsProto.QoL;
	using TargetSelection;
	using UniGame.Core.Runtime;
	using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
	using UniGame.LeoEcs.Shared.Extensions;
	using Unity.Collections;
	/// <summary>
	/// Cone zone detection system.
	/// </summary>
#if ENABLE_IL2CPP
	using Unity.IL2CPP.CompilerServices;

	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	[Serializable]
	[ECSDI]
	public class ConeZoneDetectionSystem : IProtoInitSystem, IProtoRunSystem
	{
		private ProtoWorld _world;
		private EcsFilter _filter;

		private TargetAbilityAspect _targetAspect;
		
		private NativeHashSet<ProtoEntity> _foundTarget;
		private ILifeTime _lifeTime;
		
		private ProtoPool<ConeZoneDetectionComponent> _zoneDetectionPool;

		private ProtoEntity[] _unpacked = new  ProtoEntity[TargetSelectionData.MaxTargets];
		private ProtoPackedEntity[] _targets = new  ProtoPackedEntity[TargetSelectionData.MaxTargets];

		public void Init(IProtoSystems systems)
		{
			_world = systems.GetWorld();
			_lifeTime = _world.GetWorldLifeTime();
			
			_foundTarget = new NativeHashSet<ProtoEntity>(TargetSelectionData.MaxTargets,
				Allocator.Persistent)
				.AddTo(_lifeTime);
			
			_filter = _world.Filter<AbilityTargetsComponent>()
				.Inc<ConeZoneDetectionComponent>()
				.Inc<OwnerComponent>()
				.End();
		}

		public void Run()
		{
			foreach (var entity in _filter)
			{
				_foundTarget.Clear();
				
				ref var ownerComponent = ref _targetAspect.Owner.Get(entity);
				if (!ownerComponent.Value.Unpack(_world, out var rootObject))
					continue;

				ref var zoneDetectionComponent = ref _zoneDetectionPool.Get(entity);
				var zoneAngle = zoneDetectionComponent.Angle;
				var zoneDistance = zoneDetectionComponent.Distance;
                
				ref var directionComponent = ref _targetAspect.Direction.Get(rootObject);
				ref var positionComponent = ref _targetAspect.Position.Get(rootObject);
				ref var abilityTargets = ref _targetAspect.AbilityTargets.Get(entity);
				
				ref var transformSource = ref positionComponent.Position;
				ref var forward = ref directionComponent.Forward;
				
				var count = _world.UnpackAll(abilityTargets.Entities,_unpacked,abilityTargets.Count);
				var targetsCount = 0;
				
				for (var i = 0; i < count; i++)
				{
					var targetEntity = _unpacked[i];
					
					if (_foundTarget.Contains(targetEntity)) continue;
					if (!_targetAspect.Position.Has(targetEntity)) continue;
					if (!_targetAspect.Direction.Has(targetEntity)) continue;
					
					ref var transformTargetComponent = ref _targetAspect.Position.Get(targetEntity);
					ref var positionTarget = ref transformTargetComponent.Position;
					
					if (!ZoneDetectionMathTool.IsPointWithin(positionTarget,
						    transformSource,forward,
						    zoneAngle, zoneDistance))
						continue;
					
					_foundTarget.Add(targetEntity);
					_targets[targetsCount] = _world.PackEntity(targetEntity);
					
					targetsCount++;
				}

				abilityTargets.SetEntities(_targets, targetsCount);
			}
		}
	}
}
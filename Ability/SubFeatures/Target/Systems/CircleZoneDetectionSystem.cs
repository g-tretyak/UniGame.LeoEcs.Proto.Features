namespace UniGame.Ecs.Proto.Ability.SubFeatures.Target.Systems
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
	/// Target detection system in the area of the ability
	/// </summary>
#if ENABLE_IL2CPP
	using Unity.IL2CPP.CompilerServices;
	
	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	[Serializable]
	[ECSDI]
	public class CircleZoneDetectionSystem : IProtoInitSystem, IProtoRunSystem
	{
		private ProtoWorld _world;
		private EcsFilter _filter;

		private NativeHashSet<ProtoEntity> _nativeHashSet;

		private TargetAbilityAspect _targetAspect;
		private ProtoPool<CircleZoneDetectionComponent> _zoneDetectionPool;

		private ILifeTime _lifeTime;
		private ProtoPackedEntity[] _targets = new ProtoPackedEntity[TargetSelectionData.MaxTargets];
		private ProtoEntity[] _unpacked = new ProtoEntity[TargetSelectionData.MaxTargets];

		public void Init(IProtoSystems systems)
		{
			_world = systems.GetWorld();
			_lifeTime = _world.GetLifeTime();
			
			_nativeHashSet = new NativeHashSet<ProtoEntity>(
					TargetSelectionData.MaxTargets, 
					Allocator.Persistent)
				.AddTo(_lifeTime);
			
			_filter = _world
				.Filter<AbilityTargetsComponent>()
				.Inc<CircleZoneDetectionComponent>()
				.Inc<OwnerComponent>()
				.End();
		}

		public void Run()
		{
			foreach (var entity in _filter)
			{
				_nativeHashSet.Clear();
				
				ref var ownerComponent = ref _targetAspect.Owner.Get(entity);
				if (!ownerComponent.Value.Unpack(_world, out var rootObject))
					continue;

				ref var zoneDetectionComponent = ref _zoneDetectionPool.Get(entity);
				var zoneOffset = zoneDetectionComponent.Offset;
				var zoneRadius = zoneDetectionComponent.Radius;
                
				ref var sourcePositionComponent = ref _targetAspect.Position.Get(rootObject);
				ref var directionComponent = ref _targetAspect.Direction.Get(rootObject);
				ref var abilityTargets = ref _targetAspect.AbilityTargets.Get(entity);
				
				ref var sourcePosition = ref sourcePositionComponent.Position;
				ref var froward = ref directionComponent.Forward;
				ref var right = ref directionComponent.Right;
				
				var amount = _world.UnpackAll(abilityTargets.Entities,_unpacked,abilityTargets.Count);
				var counter = 0;
				
				for (var i = 0; i < amount; i++)
				{
					var targetEntity = _unpacked[i];
					
					if (_targetAspect.Position.Has(targetEntity) == false) continue;
					if (_targetAspect.Direction.Has(targetEntity) == false) continue;
					
					ref var transformTargetComponent = ref _targetAspect.Position.Get(targetEntity);
					ref var positionTarget = ref transformTargetComponent.Position;
					
					if (!ZoneDetectionMathTool.IsPointWithin(positionTarget,
						    sourcePosition, 
						    froward,right,
						    zoneOffset, zoneRadius)) continue;
					
					if (_nativeHashSet.Contains(targetEntity)) continue;

					_nativeHashSet.Add(targetEntity);
					_targets[counter] = _world.PackEntity(targetEntity);
					counter++;
				}

				abilityTargets.SetEntities(_targets,counter);
			}
		}
	}
}
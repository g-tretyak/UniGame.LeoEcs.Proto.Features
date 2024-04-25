namespace unigame.ecs.proto.Shaders.Systems
{
	using System;
	using Components;
	using Game.Ecs.Core.Components;
	using Leopotam.EcsLite;
	using Leopotam.EcsProto;
	using UniCore.Runtime.ProfilerTools;
	using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
	using UniGame.LeoEcs.Shared.Components;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	/// <summary>
	/// Take champion position and set it to global mask
	/// </summary>
#if ENABLE_IL2CPP
	using Unity.IL2CPP.CompilerServices;

	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	[ECSDI]
	[Serializable]
	public class ChampionGlobalMaskSystem : IProtoInitSystem, IProtoRunSystem
	{
		private ProtoWorld _world;
		private EcsFilter _championFilter;
		private EcsFilter _globalMaskFilter;
		private ProtoPool<TransformPositionComponent> _positionPool;
		private ProtoPool<ChampionGlobalMaskComponent> _championGlobalMaskPool;

		public void Init(IProtoSystems systems)
		{
			_world = systems.GetWorld();
			
			_championFilter = _world
				.Filter<TransformPositionComponent>()
				.Inc<ChampionComponent>()
				.End();

			_globalMaskFilter = _world
				.Filter<ChampionGlobalMaskComponent>()
				.End();
			
			_positionPool = _world.GetPool<TransformPositionComponent>();
			_championGlobalMaskPool = _world.GetPool<ChampionGlobalMaskComponent>();
		}

		public void Run()
		{
			foreach (var championEntity in _championFilter)
			{
				ref var transformComponent = ref _positionPool.Get(championEntity);
				ref var position = ref transformComponent.Position;
				foreach (var entity in _globalMaskFilter)
				{
					ref var championGlobalMask = ref _championGlobalMaskPool.Get(entity);
					foreach (var championVariable in championGlobalMask.Variables)
					{
						foreach (var material in championGlobalMask.Materials)
						{
							#if UNITY_EDITOR
							if (material == null)
							{
								GameLog.LogError($"Material is null for {championGlobalMask}");
								continue;
							}
							#endif

							var targetPosition = (Vector3)position;
							material.SetVector(championVariable, targetPosition);
						}
					}
				}
			}
		}
	}
}
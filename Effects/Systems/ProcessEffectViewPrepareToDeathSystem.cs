namespace UniGame.Ecs.Proto.Effects.Systems
{
	using System;
	using Components;
	using Game.Ecs.Core.Components;
	using Leopotam.EcsLite;
	using Leopotam.EcsProto;
	using Leopotam.EcsProto.QoL;
	using UniGame.LeoEcs.Shared.Extensions;
	using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

	/// <summary>
	/// Send destroy request to effect view.
	/// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	[Serializable]
	[ECSDI]
	public class ProcessEffectViewPrepareToDeathSystem : IProtoInitSystem, IProtoRunSystem
	{
		private ProtoWorld _world;
		private EcsFilter _eventFilter;
		private EcsFilter _viewFilter;

		private ProtoPool<PrepareToDeathEvent> _prepareToDeathPool;
		private ProtoPool<OwnerComponent> _ownerPool;
		private ProtoPool<DestroyEffectViewSelfRequest> _destroyRequestPool;

		public void Init(IProtoSystems systems)
		{
			_world = systems.GetWorld();
			_eventFilter = _world
				.Filter<PrepareToDeathEvent>()
				.End();
			_viewFilter = _world
				.Filter<EffectViewComponent>()
				.End();
		}

		public void Run()
		{
			foreach (var eventEntity in _eventFilter)
			{
				ref var prepareToDeathEvent = ref _prepareToDeathPool.Get(eventEntity);
				
				foreach (var viewEntity in _viewFilter)
				{
					ref var ownerComponent = ref _ownerPool.Get(viewEntity);
					if (!ownerComponent.Value.Equals(prepareToDeathEvent.Source))
						continue;
					
					_destroyRequestPool.TryAdd(viewEntity);
				}
			}
		}
	}
}
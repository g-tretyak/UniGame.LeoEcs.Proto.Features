namespace UniGame.Ecs.Proto.Gameplay.Tutorial.Triggers.StepTrigger.Systems
{
	using System;
	using Aspects;
	using Components;
	using Leopotam.EcsLite;
	using Leopotam.EcsProto;
	using Tutorial.Components;
	using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
	using UniGame.LeoEcs.Shared.Extensions;
	
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	[Serializable]
	[ECSDI]
	public class StepTriggerSystem : IProtoInitSystem, IProtoRunSystem
	{
		private ProtoWorld _world;
		private EcsFilter _filter;
		private StepTriggerAspect _aspect;
		private EcsFilter _startLevelFilter;

		public void Init(IProtoSystems systems)
		{
			_world = systems.GetWorld();
			_filter = _world
				.Filter<StepTriggerReadyComponent>()
				.Exc<CompletedStepTriggerComponent>()
				.End();
			
			_startLevelFilter = _world
				.Filter<TutorialReadyComponent>()
				.End();
		}

		public void Run()
		{
			var first = _startLevelFilter.First();
			if (first < 0) return;
			
			foreach (var entity in _filter)
			{
				_aspect.CompletedStepTrigger.Add(entity);
				var requestEntity = _world.NewEntity();
				ref var request = ref _aspect.RunTutorialActionsRequest.Add(requestEntity);
				request.Source = entity.PackEntity(_world);
			}
		}
	}
}
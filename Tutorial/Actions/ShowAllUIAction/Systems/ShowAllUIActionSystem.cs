namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.ShowAllUIAction.Systems
{
	using System;
	using Aspects;
	using Components;
	using Leopotam.EcsLite;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
	using UniGame.LeoEcs.Shared.Extensions;

	/// <summary>
	/// Show all UI. Send event to show all UI.
	/// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	[Serializable]
	[ECSDI]
	public class ShowAllUIActionSystem : IProtoInitSystem, IProtoRunSystem
	{
		private ProtoWorld _world;
		private EcsFilter _filter;
		private ShowAllUIActionAspect _aspect;

		public void Init(IProtoSystems systems)
		{
			_world = systems.GetWorld();
			_filter = _world
				.Filter<ShowAllUIActionComponent>()
				.Exc<CompletedShowAllUIComponent>()
				.End();
		}

		public void Run()
		{
			foreach (var entity in _filter)
			{
				var eventEntity = _world.NewEntity();
				_aspect.ShowAllUIActionEvent.Add(eventEntity);
				_aspect.CompletedShowAllUI.Add(entity);
			}
		}
	}
}
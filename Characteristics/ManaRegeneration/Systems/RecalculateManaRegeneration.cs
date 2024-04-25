namespace unigame.ecs.proto.Characteristics.ManaRegeneration.Systems
{
	using Base.Components;
	using Components;
	using Leopotam.EcsLite;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;


#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif
	
	/// <summary>
	/// Recalculates mana regeneration value.
	/// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	public class RecalculateManaRegeneration : IProtoInitSystem, IProtoRunSystem
	{
		private EcsFilter _filter;
		private ProtoWorld _world;
        
		private ProtoPool<CharacteristicComponent<ManaRegenerationComponent>> _characteristicPool;
		private ProtoPool<ManaRegenerationComponent> _characteristicComponentPool;

		public void Init(IProtoSystems systems)
		{
			_world = systems.GetWorld();
            
			_filter = _world
				.Filter<CharacteristicChangedComponent<ManaRegenerationComponent>>()
				.Inc<CharacteristicComponent<ManaRegenerationComponent>>()
				.Inc<ManaRegenerationComponent>()
				.End();

			_characteristicPool = _world.GetPool<CharacteristicComponent<ManaRegenerationComponent>>();
			_characteristicComponentPool = _world.GetPool<ManaRegenerationComponent>();
		}
        
		public void Run()
		{
			foreach (var entity in _filter)
			{
				ref var characteristicComponent = ref _characteristicPool.Get(entity);
				ref var characteristicValueComponent = ref _characteristicComponentPool.Get(entity);
				characteristicValueComponent.Value = characteristicComponent.Value;
			}
		}
	}
}
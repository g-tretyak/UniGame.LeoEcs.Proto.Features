namespace UniGame.Ecs.Proto.Characteristics.Mana.Systems
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
	/// Recalculates max mana value.
	/// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	public class RecalculateManaSystem : IProtoInitSystem, IProtoRunSystem
	{
		private EcsFilter _filter;
		private ProtoWorld _world;
        
		private ProtoPool<CharacteristicComponent<ManaComponent>> _characteristicPool;
		private ProtoPool<ManaComponent> _characteristicComponentPool;

		public void Init(IProtoSystems systems)
		{
			_world = systems.GetWorld();
            
			_filter = _world
				.Filter<CharacteristicChangedComponent<ManaComponent>>()
				.Inc<CharacteristicComponent<ManaComponent>>()
				.Inc<ManaComponent>()
				.End();

			_characteristicPool = _world.GetPool<CharacteristicComponent<ManaComponent>>();
			_characteristicComponentPool = _world.GetPool<ManaComponent>();
		}
        
		public void Run()
		{
			foreach (var entity in _filter)
			{
				ref var characteristicComponent = ref _characteristicPool.Get(entity);
				ref var characteristicValueComponent = ref _characteristicComponentPool.Get(entity);
				characteristicValueComponent.Mana = characteristicComponent.Value;
				characteristicValueComponent.MaxMana = characteristicComponent.MaxValue;
			}
		}
	}
}
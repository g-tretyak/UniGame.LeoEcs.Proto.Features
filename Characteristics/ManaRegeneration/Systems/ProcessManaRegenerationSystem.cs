namespace UniGame.Ecs.Proto.Characteristics.ManaRegeneration.Systems
{
	using Base;
	using Components;
	using Game.Ecs.Time.Service;
	using Leopotam.EcsProto;
	using Leopotam.EcsProto.QoL;
	using Mana;
	using UniGame.LeoEcs.Shared.Extensions;
	
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif
	

	/// <summary>
	/// Regenerate mana.
	/// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	public class ProcessManaRegenerationSystem : IProtoRunSystem
	{
		private ProtoWorld _world;
		private ManaRegenerationAspect _regenerationAspect;
		private ManaAspect _manaAspect;
		
		private ProtoIt _filter = It.Chain<ManaRegenerationComponent>()
			.Inc<ManaRegenerationTimerComponent>()
			.Inc<ManaComponent>()
			.End();

		public void Run()
		{
			foreach (var entity in _filter)
			{
				ref var manaRegenerationComponent = ref _regenerationAspect.Characteristic.Get(entity);
				ref var manaRegenerationTimerComponent = ref _regenerationAspect.RegenerationTimer.Get(entity);
				
				if (GameTime.Time < manaRegenerationTimerComponent.LastTickTime)
					continue;
				
				var manaRegeneration = manaRegenerationComponent.Value * manaRegenerationTimerComponent.TickTime;
				manaRegenerationTimerComponent.LastTickTime = GameTime.Time + manaRegenerationTimerComponent.TickTime;
				
				var requestEntity = _world.NewEntity();
				ref var request = ref _manaAspect.ChangeBaseValue.Add(requestEntity);
				
				request.Value = manaRegeneration;
				request.Source = entity.PackEntity(_world);
				request.Target = entity.PackEntity(_world);
			}
		}
	}
}
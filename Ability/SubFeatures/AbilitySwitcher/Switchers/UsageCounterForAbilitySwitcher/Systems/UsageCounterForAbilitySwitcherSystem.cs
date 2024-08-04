namespace UniGame.Ecs.Proto.Ability.SubFeatures.AbilitySwitcher.Switchers.UsageCounterForAbilitySwitcher.Systems
{
	using System;
	using Ability.Aspects;
	using AbilitySwitcher.Components;
	using Aspects;
	using Components;
	using Leopotam.EcsLite;
	using Leopotam.EcsProto;
	using Leopotam.EcsProto.QoL;
	using UniGame.Ecs.Proto.Ability.Common.Components;
	 
	using Tools;
	using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
	using UniGame.LeoEcs.Shared.Extensions;

	/// <summary>
	/// Counts usages of ability and switches it to another ability after count of usages.
	/// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	[Serializable]
	[ECSDI]
	public class UsageCounterForAbilitySwitcherSystem : IProtoRunSystem
	{
		private ProtoWorld _world;
		private UsageCounterForAbilitySwitcherAspect _aspect;
		private AbilityAspect _abilityTools;

		private ProtoIt _abilityFilter = It
			.Chain<ApplyAbilitySelfRequest>()
			.End();
		
		private ProtoItExc _usageCounterFilter= It
			.Chain<UsageCounterForAbilitySwitcherComponent>()
			.Inc<AbilitySwitcherComponent>()
			.Exc<AbilityUsingComponent>()
			.End();

		public void Run()
		{
			foreach (var requestAbilityEntity in _abilityFilter)
			{
				ref var requestAbilityComponent = ref _aspect.ApplyAbilitySelfRequest.Get(requestAbilityEntity);
				if (!requestAbilityComponent.Value.Unpack(_world, out var abilityEntity))
					continue;
				
				foreach (var counterEntity in _usageCounterFilter)
				{
					ref var owner = ref _aspect.Owner.Get(counterEntity);
					ref var usageCounter = ref _aspect.UsageCounterForAbilitySwitcher.Get(counterEntity);
					if (!_abilityTools.TryGetAbilityById(ref owner.Value, usageCounter.abilityId, out var currentAbilityEntity))
						continue;
					if (!currentAbilityEntity.Equals(abilityEntity))
						continue;
					usageCounter.count++;
					if (usageCounter.count < usageCounter.baseCount)
						continue;
					usageCounter.count = 0;
					var requestEntity = _world.NewEntity();
					ref var request = ref _aspect.AbilitySwitchRequest.Add(requestEntity);
					request.OldAbility = currentAbilityEntity.PackEntity(_world);
					request.NewAbility = counterEntity.PackEntity(_world);
				}
			}
		}
	}
}
namespace unigame.ecs.proto.Ability.SubFeatures.AbilitySwitcher.Switchers.UsageCounterForAbilitySwitcher
{
	using System;
	using Abstracts;
	using Components;
	using Game.Code.Configuration.Runtime.Ability.Description;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;

	[Serializable]
	public class UsageCounterForAbilitySwitcherConfiguration : IAbilitySwitcherConfiguration
	{
		#region Inspector

		public AbilityId abilityId;
		public int count;

		#endregion
		public void Compose(ProtoWorld world, ProtoEntity abilityEntity)
		{
			ref var counterForAbilitySwitcherComponent = ref world.AddComponent<UsageCounterForAbilitySwitcherComponent>(abilityEntity);
			counterForAbilitySwitcherComponent.abilityId = abilityId;
			counterForAbilitySwitcherComponent.baseCount = count;
			counterForAbilitySwitcherComponent.count = 0;
		}
	}
}
namespace UniGame.Ecs.Proto.GameEffects.ManaEffect.Behaviours
{
	using System;
	using Components;
	using Game.Code.Configuration.Runtime.Ability.Description;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;

	[Serializable]
	public class ManaCostBehaviour : IAbilityBehaviour
	{
		public float mana;
		public void Compose(ProtoWorld world, ProtoEntity abilityEntity, bool isDefault)
		{
			ref var manaCostComponent = ref world.AddComponent<ManaCostComponent>(abilityEntity);
			manaCostComponent.Mana = mana;
		}
	}
}
namespace unigame.ecs.proto.Gameplay.ArmorResist.Aspects
{
	using System;
	using Ability.Common.Components;
	using Characteristics.ArmorResist.Components;
	using Damage.Components.Request;
	using GameEffects.DamageEffect.DamageTypes.Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	/// <summary>
	/// Armor resist aspect.
	/// </summary>
	[Serializable]
	public class ArmorResistAspect : EcsAspect
	{
		// Armor resist value
		public ProtoPool<ArmorResistComponent> ArmorResist;
		// Default ability
		public ProtoPool<DefaultAbilityComponent> DefaultAbility;
		// Types of damage
		public ProtoPool<PhysicsDamageComponent> PhysicsDamage;
		
		// request
		// Apply damage request. Need to recalculate damage by armor resist
		public ProtoPool<ApplyDamageRequest> ApplyDamageRequest;
	}
}
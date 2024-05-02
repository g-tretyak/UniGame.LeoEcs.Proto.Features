namespace UniGame.Ecs.Proto.GameEffects.DamageEffect.DamageTypes
{
	using System;
	using Abstracts;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;

	[Serializable]
	public class PhysicsDamageType : IDamageType
	{
		public void Compose(ProtoWorld world, ProtoEntity effectEntity)
		{
			world.AddComponent<PhysicsDamageComponent>(effectEntity);
		}
	}
}
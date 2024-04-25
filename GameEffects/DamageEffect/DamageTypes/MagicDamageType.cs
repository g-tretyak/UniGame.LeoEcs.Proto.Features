namespace unigame.ecs.proto.GameEffects.DamageEffect.DamageTypes
{
	using System;
	using Abstracts;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;

	[Serializable]
	public class MagicDamageType : IDamageType
	{
		public void Compose(ProtoWorld world, ProtoEntity effectEntity)
		{
			world.AddComponent<MagicDamageComponent>(effectEntity);
		}
	}
}
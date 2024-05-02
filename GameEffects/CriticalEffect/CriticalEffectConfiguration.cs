namespace UniGame.Ecs.Proto.GameEffects.CriticalEffect
{
	using System;
	using Components;
	using Effects;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;

	[Serializable]
	public class CriticalEffectConfiguration : EffectConfiguration
	{
		protected override void Compose(ProtoWorld world, ProtoEntity effectEntity)
		{
			world.AddComponent<CriticalEffectComponent>(effectEntity);
		}
	}
}
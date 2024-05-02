namespace UniGame.Ecs.Proto.GameEffects.BlockAutoAttackEffect
{
	using System;
	using Components;
	using Effects;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;

	[Serializable]
	public class BlockAutoAttackEffectConfiguration : EffectConfiguration
	{
		#region Inspector

		public float silenceDuration = 1f;

		#endregion
		protected override void Compose(ProtoWorld world, ProtoEntity effectEntity)
		{
			ref var blockAttackComponent = ref world.AddComponent<BlockAutoAttackEffectComponent>(effectEntity);
			blockAttackComponent.Duration = silenceDuration;
		}
	}
}
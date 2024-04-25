namespace unigame.ecs.proto.GameEffects.DamageEffect.DamageTypes.Abstracts
{
	using Leopotam.EcsProto;


	public interface IDamageType
	{
		void Compose(ProtoWorld world, ProtoEntity effectEntity);
	}
}
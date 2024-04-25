namespace unigame.ecs.proto.Ability.SubFeatures.AbilitySwitcher.Abstracts
{
	using Leopotam.EcsProto;


	public interface IAbilitySwitcherConfiguration
	{
		void Compose(ProtoWorld world, ProtoEntity abilityEntity);
	}
}
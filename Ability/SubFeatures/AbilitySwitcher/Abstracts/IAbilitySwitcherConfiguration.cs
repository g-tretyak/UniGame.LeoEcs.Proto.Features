namespace UniGame.Ecs.Proto.Ability.SubFeatures.AbilitySwitcher.Abstracts
{
	using Leopotam.EcsProto;


	public interface IAbilitySwitcherConfiguration
	{
		void Compose(ProtoWorld world, ProtoEntity abilityEntity);
	}
}
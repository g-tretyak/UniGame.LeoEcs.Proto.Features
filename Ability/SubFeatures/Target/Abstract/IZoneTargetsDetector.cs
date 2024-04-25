namespace unigame.ecs.proto.Ability.SubFeatures.Target.Abstract
{
	using Leopotam.EcsProto;


	public interface IZoneTargetsDetector
	{
		int GetTargetsInZone(ProtoWorld world,int[] result, int entity, int[] targetEntities,int amount);
	}
}
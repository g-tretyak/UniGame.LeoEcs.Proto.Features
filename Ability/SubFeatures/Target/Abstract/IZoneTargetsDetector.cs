namespace unigame.ecs.proto.Ability.SubFeatures.Target.Abstract
{
	 

	public interface IZoneTargetsDetector
	{
		int GetTargetsInZone(ProtoWorld world,int[] result, int entity, int[] targetEntities,int amount);
	}
}
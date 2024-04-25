namespace unigame.ecs.proto.Ability.SubFeatures.Target.Abstract
{
	using Leopotam.EcsProto;


	public interface IZoneTargetsDetector
	{
		int GetTargetsInZone(ProtoWorld world,ProtoEntity[] result,
			ProtoEntity entity, ProtoEntity[] targetEntities,int amount);
	}
}
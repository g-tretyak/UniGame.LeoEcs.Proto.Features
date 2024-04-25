namespace unigame.ecs.proto.Gameplay.Tutorial.Abstracts
{
	using Leopotam.EcsProto;


	/// <summary>
	/// 
	/// </summary>
	public interface ITutorialEvent
	{
		void ComposeEntity(ProtoWorld world, ProtoEntity entity);
	}
}
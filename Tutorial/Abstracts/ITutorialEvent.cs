namespace UniGame.Ecs.Proto.Gameplay.Tutorial.Abstracts
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
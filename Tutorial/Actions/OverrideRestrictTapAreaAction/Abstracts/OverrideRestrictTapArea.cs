namespace UniGame.Ecs.Proto.Gameplay.Tutorial.Actions.OverrideRestrictTapAreaAction.Abstracts
{
	using Leopotam.EcsProto;


	public abstract class OverrideRestrictTapArea : IOverrideRestrictTapArea
	{
		public void ComposeEntity(ProtoWorld world, ProtoEntity entity)
		{
			Composer(world, entity);
		}
		
		protected abstract void Composer(ProtoWorld world, ProtoEntity entity);
	}
}
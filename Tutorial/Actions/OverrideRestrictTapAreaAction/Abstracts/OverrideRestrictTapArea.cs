namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.OverrideRestrictTapAreaAction.Abstracts
{
	 

	public abstract class OverrideRestrictTapArea : IOverrideRestrictTapArea
	{
		public void ComposeEntity(ProtoWorld world, int entity)
		{
			Composer(world, entity);
		}
		
		protected abstract void Composer(ProtoWorld world, int entity);
	}
}
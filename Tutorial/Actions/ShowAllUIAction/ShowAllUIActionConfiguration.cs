namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.ShowAllUIAction
{
	using System;
	using Abstracts;
	using Components;
	 
	using UniGame.LeoEcs.Shared.Extensions;
    
	public class ShowAllUIActionConfiguration : TutorialAction
	{
		protected override void Composer(ProtoWorld world, int entity)
		{
			world.AddComponent<ShowAllUIActionComponent>(entity);
		}
	}
}
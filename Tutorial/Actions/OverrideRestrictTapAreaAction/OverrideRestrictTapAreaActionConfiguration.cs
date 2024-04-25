namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.OverrideRestrictTapAreaAction
{
	using Abstracts;
	using Components;
	 
	using Tutorial.Abstracts;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	public class OverrideRestrictTapAreaActionConfiguration : TutorialAction
	{
		#region Inspector
		
		[SerializeReference]
		public IOverrideRestrictTapArea OverrideRestrictTapArea;

		#endregion
		protected override void Composer(ProtoWorld world, int entity)
		{
			ref var overriderComponent = ref world.AddComponent<OverrideRestrictTapAreaActionComponent>(entity);
			overriderComponent.Value = OverrideRestrictTapArea;
		}
	}
}
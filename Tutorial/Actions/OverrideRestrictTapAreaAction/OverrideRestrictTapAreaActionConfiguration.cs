namespace UniGame.Ecs.Proto.Gameplay.Tutorial.Actions.OverrideRestrictTapAreaAction
{
	using Abstracts;
	using Components;
	using Leopotam.EcsProto;
	using Tutorial.Abstracts;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	public class OverrideRestrictTapAreaActionConfiguration : TutorialAction
	{
		#region Inspector
		
		[SerializeReference]
		public IOverrideRestrictTapArea OverrideRestrictTapArea;

		#endregion
		
		protected override void Composer(ProtoWorld world, ProtoEntity entity)
		{
			ref var overriderComponent = ref world.AddComponent<OverrideRestrictTapAreaActionComponent>(entity);
			overriderComponent.Value = OverrideRestrictTapArea;
		}
	}
}
namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.FreezingTimeAction
{
	using System;
	using Abstracts;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;


	[Serializable]
	public class FreezingTimeActionConfiguration : TutorialAction
	{
		#region Inspector
        
		public float duration = 1f;
		public float timeScale = 1f;

		#endregion
		
		protected override void Composer(ProtoWorld world, ProtoEntity entity)
		{
			ref var freezingTimeActionComponent = ref world.AddComponent<FreezingTimeActionComponent>(entity);
			freezingTimeActionComponent.Duration = duration;
			freezingTimeActionComponent.TimeScale = timeScale;
		}
	}
}
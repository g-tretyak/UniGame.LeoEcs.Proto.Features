namespace unigame.ecs.proto.Gameplay.Tutorial.Triggers.DistanceTrigger
{
	using Abstracts;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;
    
	public class DistanceTriggerConfiguration : TutorialTrigger
	{
		#region Inspector

		public float distance = 1f;

		#endregion
		
		protected override void Composer(ProtoWorld world, ProtoEntity entity)
		{
			ref var distanceComponent = ref world.AddComponent<DistanceTriggerPointComponent>(entity);
			distanceComponent.TriggerDistance = distance;
		}
	}
}
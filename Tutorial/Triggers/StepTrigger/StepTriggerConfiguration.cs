namespace unigame.ecs.proto.Gameplay.Tutorial.Triggers.StepTrigger
{
	using Abstracts;
	using ActionTools;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	public class StepTriggerConfiguration : TutorialTrigger
	{
		#region Inspector

		public int Level;
		public int Stage;
		[SerializeReference]
		public TutorialKey StepKey;

		#endregion
		protected override void Composer(ProtoWorld world, int entity)
		{
			ref var stepTriggerComponent = ref world.AddComponent<StepTriggerComponent>(entity);
			stepTriggerComponent.StepKey = StepKey;
			stepTriggerComponent.Level = Level;
			stepTriggerComponent.Stage = Stage;
		}
	}
}
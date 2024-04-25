namespace unigame.ecs.proto.Gameplay.Tutorial.Triggers.ActionTrigger
{
	using Abstracts;
	using Components;
	using Cysharp.Threading.Tasks;
	 
	using Leopotam.EcsLite.ExtendedSystems;
	using Systems;
	using UnityEngine;

	[CreateAssetMenu(menuName = "Game/Feature/Gameplay/Tutorial/TutorialTrigger/Action Trigger Feature", 
		fileName = "Action Trigger Feature")]
	public class ActionTriggerFeature : TutorialFeature
	{
		public override async UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
		{
			// Sends request to execute action. Await ActionTriggerRequest.
			ecsSystems.Add(new ActionTriggerSystem());
			ecsSystems.DelHere<ActionTriggerRequest>();
		}
	}
}
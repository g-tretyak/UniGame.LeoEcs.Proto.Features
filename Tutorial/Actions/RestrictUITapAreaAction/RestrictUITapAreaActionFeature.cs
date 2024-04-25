namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.RestrictUITapAreaAction
{
	using Abstracts;
	using Cysharp.Threading.Tasks;
	 
	using Systems;
	using UnityEngine;

	[CreateAssetMenu(menuName = "Game/Feature/Gameplay/Tutorial/TutorialAction/Restrict UI Tap Area Action Feature", 
		fileName = "Restrict UI Tap Area Action Feature")]
	public class RestrictUITapAreaActionFeature : TutorialFeature
	{
		public override async UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
		{
			ecsSystems.Add(new InitializationRestrictUITapAreaActionSystem());
			ecsSystems.Add(new ProcessRestrictUITapAreaSystem());
			ecsSystems.Add(new SelectionNextTapAreaSystem());
			ecsSystems.Add(new RunRestrictAreaActionsSystem());
		}
	}
}
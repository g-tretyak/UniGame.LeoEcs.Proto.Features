namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.OverrideRestrictTapAreaAction
{
	using Abstracts;
	using Cysharp.Threading.Tasks;
	 
	using Systems;
	using Tutorial.Abstracts;
	using UnityEngine;

	[CreateAssetMenu(menuName = "Game/Feature/Gameplay/Tutorial/TutorialAction/Override Restrict UI Tap Area Action Feature", 
		fileName = "Override Restrict UI Tap Area Action Feature")]
	public class OverrideRestrictTapAreaActionFeature : TutorialFeature
	{
		public override async UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
		{
			ecsSystems.Add(new InitializationOverrideRestrictAreaActionSystem());
		}
	}
}
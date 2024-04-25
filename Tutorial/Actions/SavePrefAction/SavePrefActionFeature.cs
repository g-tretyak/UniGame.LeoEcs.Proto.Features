namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.SavePrefAction
{
	using Abstracts;
	using Cysharp.Threading.Tasks;
	 
	using Systems;
	using UnityEngine;

	[CreateAssetMenu(menuName = "Game/Feature/Gameplay/Tutorial/TutorialAction/Save Pref Action Feature", 
		fileName = "Save Pref Action Feature")]
	public class SavePrefActionFeature : TutorialFeature
	{
		public override async UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
		{
			ecsSystems.Add(new SavePrefSystem());
		}
	}
}
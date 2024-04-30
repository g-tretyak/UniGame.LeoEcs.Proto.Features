namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.SavePrefAction
{
	using Abstracts;
	using Cysharp.Threading.Tasks;
	using Leopotam.EcsProto;
	using Systems;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	[CreateAssetMenu(menuName = "Game/Feature/Gameplay/Tutorial/TutorialAction/Save Pref Action Feature", 
		fileName = "Save Pref Action Feature")]
	public class SavePrefActionFeature : TutorialFeature
	{
		public override async UniTask InitializeAsync(IProtoSystems ecsSystems)
		{
			ecsSystems.Add(new SavePrefSystem());
		}
	}
}
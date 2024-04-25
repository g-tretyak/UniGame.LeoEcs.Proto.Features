namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.EquipAbilityAction
{
	using Abstracts;
	using Cysharp.Threading.Tasks;
	using Leopotam.EcsProto;
	using Systems;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	[CreateAssetMenu(menuName = "Game/Feature/Gameplay/Tutorial/TutorialAction/Equip Ability Action Feature", 
		fileName = "Equip Ability Action Feature")]
	public class EquipAbilityActionFeature : TutorialFeature
	{
		public override async UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
		{
			// Equip ability to champion
			ecsSystems.Add(new EquipAbilityActionSystem());
		}
	}
}
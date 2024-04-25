﻿namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.HealingChampionAction
{
	using Abstracts;
	using Cysharp.Threading.Tasks;
	using Leopotam.EcsProto;
	using Systems;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	[CreateAssetMenu(menuName = "Game/Feature/Gameplay/Tutorial/TutorialAction/Healing Champion Action", 
		fileName = "Healing Champion Action Feature")]
	public class HealingChampionActionFeature : TutorialFeature
	{
		public override async UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
		{
			// Heals champion
			ecsSystems.Add(new HealingChampionActionSystem());
		}
	}
}
namespace unigame.ecs.proto.GameEffects.LevitationEffect
{
	using Cysharp.Threading.Tasks;
	using Effects.Feature;
	 
	using Leopotam.EcsLite.ExtendedSystems;
	using Systems;
	using UnityEngine;

	[CreateAssetMenu(menuName = "Game/Feature/Effects/Levitation Effect Feature")]
	public sealed class LevitationEffectFeature : EffectFeatureAsset
	{
		protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
		{
			ecsSystems.Add(new LevitationEffectSystem());

			return UniTask.CompletedTask;
		}
	}
}
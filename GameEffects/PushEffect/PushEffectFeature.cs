namespace UniGame.Ecs.Proto.GameEffects.PushEffect
{
	using Cysharp.Threading.Tasks;
	using Effects.Feature;
	 
	using Systems;
	using UnityEngine;

	[CreateAssetMenu(menuName = "Game/Feature/Effects/Push Effect Feature")]
	public class PushEffectFeature : EffectFeatureAsset
	{
		protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
		{
			// Push target to direction
			ecsSystems.Add(new PushEffectSystem());
			return UniTask.CompletedTask;
		}
	}
}
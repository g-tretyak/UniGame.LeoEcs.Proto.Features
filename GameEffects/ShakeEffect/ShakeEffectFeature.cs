namespace unigame.ecs.proto.GameEffects.ShakeEffect
{
	using Components;
	using Cysharp.Threading.Tasks;
	using unigame.ecs.proto.Effects.Feature;
	 
	using Leopotam.EcsLite.ExtendedSystems;
	using Systems;
	using UnityEngine;

	/// <summary>
	/// shake effect for targets
	/// if create Entity with ShakeEffectDataComponent without ShakeEffectTargetComponent ->
	///    shake all entities with ShakeEffectDefaultTargetComponent
	/// if create Entity with ShakeEffectDataComponent & ShakeEffectTargetComponent -> shake only target
	/// </summary>
	[CreateAssetMenu(menuName = "Game/Feature/Effects/Shake Effect Feature",fileName = "Shake Effect Feature")]
	public sealed class ShakeEffectFeature : EffectFeatureAsset
	{
		protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
		{
			//apply shake to all defaults targets. create new entity to all defaults targets
			ecsSystems.Add(new ApplyDefaultShakeEffectSystem());
			//apply shake to all targets.
			ecsSystems.Add(new ApplyShakeEffectSystem());
			
			//remove shake all effects
			ecsSystems.DelHere<ShakeEffectTargetComponent>();
			ecsSystems.DelHere<ShakeEffectDataComponent>();

			return UniTask.CompletedTask;
		}
	}
}
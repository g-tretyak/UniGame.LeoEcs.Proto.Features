namespace unigame.ecs.proto.Gameplay.FreezingTime
{
	using Components;
	using Cysharp.Threading.Tasks;
	 
	using Leopotam.EcsLite.ExtendedSystems;
	using Systems;
	using UniGame.LeoEcs.Bootstrap.Runtime;
	using UnityEngine;

	[CreateAssetMenu(menuName = "Game/Feature/Gameplay/Freezing Time Feature", fileName = "Freezing Time Feature")]
	public class FreezingTimeFeature : BaseLeoEcsFeature
	{
		public override async UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
		{
			ecsSystems.DelHere<FreezingTimeCompletedEvent>();
			
			// Responsible for freezing time. Wait for the request FreezingTimeRequest
			ecsSystems.Add(new FreezingTimeSystem());
			
			ecsSystems.DelHere<FreezingTimeRequest>();
		}
	}
}
namespace unigame.ecs.proto.Gameplay.Tutorial.Abstracts
{
	using System;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	[Serializable]
	public abstract class TutorialAction : ITutorialAction
	{
		#region Inspector
		
		public float delay;

		#endregion
		
		public void ComposeEntity(ProtoWorld world, ProtoEntity entity)
		{
			var delayedPool = world.GetPool<DelayedTutorialComponent>();
			if (delay > 0f && !delayedPool.Has(entity))
			{
				ref var delayed = ref delayedPool.Add(entity);
				delayed.Delay = delay;
				delayed.LastApplyingTime = Time.unscaledTime;
				delayed.Context = this;
				return;
			}
			
			Composer(world, entity);
		}
		
		protected abstract void Composer(ProtoWorld world, ProtoEntity entity);
	}
}
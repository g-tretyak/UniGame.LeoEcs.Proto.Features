namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.AnalyticsAction
{
	using System;
	using Abstracts;
	using ActionTools;
	using Components;
	using Leopotam.EcsProto;
	using Sirenix.OdinInspector;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	[Serializable]
	public class AnalyticsActionConfiguration : ITutorialAction
	{
		#region Inspector


		[TitleGroup("Event Data")]
		[SerializeReference]
		public TutorialKey stepName;
        

		#endregion
		
		public void ComposeEntity(ProtoWorld world, ProtoEntity entity)
		{
			ref var request = ref world.AddComponent<AnalyticsActionComponent>(entity);
			request.stepName = stepName;
		}
	}
}
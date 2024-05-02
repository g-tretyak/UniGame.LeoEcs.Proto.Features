namespace UniGame.Ecs.Proto.Gameplay.Tutorial.Converters
{
	using System;
	using Components;
	using Configurations;
	using Leopotam.EcsProto;
	using Sirenix.OdinInspector;
	using UniGame.LeoEcs.Converter.Runtime;
	using UniGame.LeoEcs.Converter.Runtime.Abstract;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	[Serializable]
	public class TutorialTriggerPointConverter : LeoEcsConverter, ILeoEcsGizmosDrawer
	{
		#region Inspector
		
		[Searchable(FilterOptions = SearchFilterOptions.ISearchFilterableInterface)]
		[InlineEditor]
		[SerializeReference]
		public TutorialTriggerPointConfiguration configuration;

		#endregion
		
		public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
		{
			world.AddComponent<TutorialTriggerPointComponent>(entity);
			configuration.Apply(world, entity);
		}


		public void DrawGizmos(GameObject target)
		{
#if UNITY_EDITOR
			foreach (var converterValue in configuration.StartTriggerActions)
			{
				if (converterValue is ILeoEcsGizmosDrawer gizmosDrawer)
					gizmosDrawer.DrawGizmos(target);
			}
			
			foreach (var converterValue in configuration.FinalTriggerActions)
			{
				if (converterValue is ILeoEcsGizmosDrawer gizmosDrawer)
					gizmosDrawer.DrawGizmos(target);
			}
#endif
		}
	}
}
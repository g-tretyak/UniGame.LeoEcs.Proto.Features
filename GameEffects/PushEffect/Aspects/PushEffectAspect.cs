namespace unigame.ecs.proto.GameEffects.PushEffect.Aspects
{
	using System;
	using Ability.SubFeatures.Target.Components;
	using Components;
	using Effects.Components;
	 
	using Modules.UnioModules.UniGame.LeoEcsLite.LeoEcs.Shared.Components;
	using UniGame.LeoEcs.Shared.Components;
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	/// <summary>
	/// Push effect aspect
	/// </summary>
	[Serializable]
	public class PushEffectAspect : EcsAspect
	{
		// Effect data 
		public ProtoPool<EffectComponent> Effect;
		// Push effect data
		public ProtoPool<PushEffectDataComponent> PushEffectData;
		// Transform for entity
		public ProtoPool<TransformComponent> Transform;
		// Say that effect is completed
		public ProtoPool<CompletedPushEffectComponent> CompletedPushEffect;
		// Says that entity is not target for push effect
		public ProtoPool<EmptyTargetComponent> EmptyTarget;
	}
}
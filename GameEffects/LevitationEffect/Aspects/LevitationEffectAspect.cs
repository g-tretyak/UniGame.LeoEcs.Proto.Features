namespace UniGame.Ecs.Proto.GameEffects.LevitationEffect.Aspects
{
	using System;
	using Ability.SubFeatures.Target.Components;
	using Components;
	using Effects.Components;
	 
	using Modules.UnioModules.UniGame.LeoEcsLite.LeoEcs.Shared.Components;
	using UniGame.LeoEcs.Shared.Components;
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	/// <summary>
	/// Levitation effect aspect
	/// </summary>
	[Serializable]
	public class LevitationEffectAspect : EcsAspect
	{
		public ProtoPool<EmptyTargetComponent> EmptyTarget;
		public ProtoPool<LevitationEffectComponent> LevitationEffect;
		public ProtoPool<TransformComponent> Transform;
		public ProtoPool<EffectComponent> Effect;
	}
}
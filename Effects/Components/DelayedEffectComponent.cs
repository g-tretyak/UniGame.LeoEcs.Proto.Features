namespace unigame.ecs.proto.Effects.Components
{
	public struct DelayedEffectComponent
	{
		public float Delay;
		public float LastApplyingTime;
		public EffectConfiguration Configuration;
	}
}
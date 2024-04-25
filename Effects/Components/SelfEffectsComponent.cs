namespace unigame.ecs.proto.Effects.Components
{
	using System.Collections.Generic;
	using Game.Code.Configuration.Runtime.Effects.Abstract;
	using Leopotam.EcsLite;
	using Leopotam.EcsProto;


	public struct SelfEffectsComponent : IProtoAutoReset<SelfEffectsComponent>
	{
		public List<IEffectConfiguration> Effects;
        
		public void AutoReset(ref SelfEffectsComponent c)
		{
			c.Effects ??= new List<IEffectConfiguration>();
			c.Effects.Clear();
		}
	}
}
namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.FreezingTimeAction.Aspects
{
	using Components;
	using FreezingTime.Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	public class FreezingTimeActionAspect : EcsAspect
	{
		public ProtoWorld World;
		
		public ProtoPool<FreezingTimeActionComponent> FreezingTimeAction;
		public ProtoPool<FreezingTimeRequest> FreezingTimeRequest;
		public ProtoPool<CompletedFreezingTimeActionComponent> CompletedFreezingTimeAction;
	}
}
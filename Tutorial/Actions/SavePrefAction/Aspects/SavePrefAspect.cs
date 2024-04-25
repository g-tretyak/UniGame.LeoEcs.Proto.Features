namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.SavePrefAction.Aspects
{
	using System;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	[Serializable]
	public class SavePrefAspect : EcsAspect
	{
		public ProtoPool<SavePrefComponent> SavePref;
		public ProtoPool<CompletedSavePrefComponent> CompletedSavePref;
	}
}
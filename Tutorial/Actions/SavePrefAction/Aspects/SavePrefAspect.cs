namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.SavePrefAction.Aspects
{
	using System;
	using Components;
	 
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	/// <summary>
	/// ADD DESCRIPTION HERE
	/// </summary>
	[Serializable]
	public class SavePrefAspect : EcsAspect
	{
		public ProtoPool<SavePrefComponent> SavePref;
		public ProtoPool<CompletedSavePrefComponent> CompletedSavePref;
	}
}
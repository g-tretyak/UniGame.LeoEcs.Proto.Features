namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.CloseTemporaryUIAction
{
	using System;
	using Abstracts;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;

	[Serializable]
	public class CloseTemporaryUIActionConfiguration : ITutorialAction
	{
		public void ComposeEntity(ProtoWorld world, ProtoEntity entity)
		{
			world.AddComponent<CloseTemporaryUIActionComponent>(entity);
		}
	}
}
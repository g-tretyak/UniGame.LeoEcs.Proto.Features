﻿namespace unigame.ecs.proto.Gameplay.Tutorial.Configurations
{
	using Abstracts;
	using Leopotam.EcsProto;


	public class EmptyTrigger : ITutorialTrigger
	{
		public void ComposeEntity(ProtoWorld world, ProtoEntity entity)
		{
		}
	}
}
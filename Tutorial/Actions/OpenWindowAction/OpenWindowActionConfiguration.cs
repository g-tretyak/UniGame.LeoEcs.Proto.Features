namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.OpenWindowAction
{
	using Abstracts;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;
	using UniGame.UiSystem.Runtime.Settings;
	using UniModules.UniGame.UiSystem.Runtime;
    
	public class OpenWindowActionConfiguration : TutorialAction
	{
		#region inspector
        
		public ViewId view;
		public ViewType layoutType = ViewType.Window;

		#endregion
		
		protected override void Composer(ProtoWorld world, ProtoEntity entity)
		{
			ref var openWindowActionComponent = ref world.AddComponent<OpenWindowActionComponent>(entity);
			openWindowActionComponent.View = view;
            openWindowActionComponent.LayoutType = layoutType;
		}
	}
}
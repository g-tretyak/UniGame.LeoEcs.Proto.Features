namespace Game.Ecs.Input.Mouse
{
    using Components.Events;
    using Components.Requests;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;

    /// <summary>
    /// Feature responsible for managing mouse input-related systems.
    /// </summary>
    public class MouseFeature : EcsFeature
    {
        protected override UniTask OnInitializeAsync(IProtoSystems ecsSystems)
        {
            // System responsible for detecting mouse input and sending corresponding requests.
            ecsSystems.AddSystem(new MouseInputSystem());
            
            // Delete used ClickMouseButtonEvent
            ecsSystems.DelHere<ClickLeftMouseButtonEvent>();
            // A system responsible for catching mouse input events and generating corresponding events.
            ecsSystems.AddSystem(new CatchMouseInputSystem());
            // Delete used ClickMouseButtonRequest
            ecsSystems.DelHere<ClickLeftMouseButtonRequest>();
            
            // System for mouse position.
            ecsSystems.AddSystem(new GetMousePositionSystem());
            
            return UniTask.CompletedTask;
        }
    }
}
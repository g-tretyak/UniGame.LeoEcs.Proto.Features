namespace Game.Ecs.Input.Systems
{
    using System;
    using Aspects;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine.InputSystem;

    /// <summary>
    /// System responsible for initializing input actions.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class InitInputSystem : IEcsInitSystem
    {
        private ProtoWorld _world;
        private InputAspect _inputAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();

            var inputActions = new DefaultInputActions();
            
            var inputEntity = _world.NewEntity();
            ref var inputActionsComponent = ref _inputAspect.InputActions.Add(inputEntity);
            inputActionsComponent.InputActions = inputActions;

            var requestEntity = _world.NewEntity();
            _inputAspect.SwitchInputMap.Add(requestEntity);
        }
    }
}
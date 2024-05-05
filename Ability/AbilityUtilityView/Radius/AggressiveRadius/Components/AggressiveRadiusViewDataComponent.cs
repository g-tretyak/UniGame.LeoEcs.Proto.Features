namespace UniGame.Ecs.Proto.Ability.AbilityUtilityView.Radius.AggressiveRadius.Components
{
    using Game.Code.GameLayers.Category;
    using Game.Code.GameLayers.Layer;
    using UnityEngine;

#if ENABLE_IL2CP
	using Unity.IL2CPP.CompilerServices;

	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public struct AggressiveRadiusViewDataComponent
    {
        public GameObject NoTargetRadiusView;
        public GameObject TargetCloseRadiusView;
        public GameObject HasTargetRadiusView;
        
        public CategoryId CategoryId;
        public LayerId LayerMask;
    }
}
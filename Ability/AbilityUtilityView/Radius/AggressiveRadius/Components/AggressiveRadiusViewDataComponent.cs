namespace UniGame.Ecs.Proto.Ability.AbilityUtilityView.Radius.AggressiveRadius.Components
{
    using Game.Code.GameLayers.Category;
    using Game.Code.GameLayers.Layer;
    using UnityEngine;

    public struct AggressiveRadiusViewDataComponent
    {
        public GameObject NoTargetRadiusView;
        public GameObject TargetCloseRadiusView;
        public GameObject HasTargetRadiusView;
        
        public CategoryId CategoryId;
        public LayerId LayerMask;
    }
}
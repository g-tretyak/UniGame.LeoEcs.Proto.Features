namespace Game.Code.Ai.ActivateAbility
{
    using System;
    using GameLayers.Category;
    using Sirenix.OdinInspector;
    using UniGame.Ecs.Proto.AI.Service;
    using UniGame.LeoEcs.Shared.Abstract;
    using UnityEngine;

#if ENABLE_IL2CP
	using Unity.IL2CPP.CompilerServices;

	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct ActivateAbilityPlannerComponent : IApplyableComponent<ActivateAbilityPlannerComponent>
    {
        /// <summary>
        /// Action Planner Data
        /// </summary>
        [InlineProperty]
        [SerializeField]
        [HideLabel]
        public AiPlannerData PlannerData;

        public void Apply(ref ActivateAbilityPlannerComponent component)
        {
            component.PlannerData = PlannerData;
        }
    }

    [Serializable]
    [HorizontalGroup(nameof(CategoryPriority),LabelWidth = 40)]
    public struct CategoryPriority
    {
        public CategoryId Category;
        public float Value;
    }
}
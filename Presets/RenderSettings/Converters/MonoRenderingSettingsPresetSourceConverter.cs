namespace UniGame.Ecs.Proto.Presets.Converters
{
    using System;
    using Abstract;
    using Assets;
    using Components;
    using Leopotam.EcsProto;
    using Sirenix.OdinInspector;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    public sealed class MonoRenderingSettingsPresetSourceConverter : MonoLeoEcsConverter
    {
        [SerializeField]
        [InlineProperty]
        [HideLabel]
        public RenderingSettingsSourceConverter renderingConverter = new RenderingSettingsSourceConverter();
        
        public sealed override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            renderingConverter.Apply(world, entity);
        }
    }

    [Serializable]
    public sealed class RenderingSettingsSourceConverter : EcsComponentConverter,IPresetAction
    {
        [ShowIf(nameof(isEnabled))]
        public string targetId = nameof(RenderingSettingsPresetComponent);
        [ShowIf(nameof(isEnabled))]
        public float duration;
        [ShowIf(nameof(isEnabled))]
        public bool showButtons;

        [ShowIf(nameof(isEnabled))]
        [FoldoutGroup("Rendering Settings")]
        [HideLabel]
        public RenderingSettingsPreset preset;

        [Button] 
        [ShowIf(nameof(showButtons))]
        public void Bake()
        {
            preset.BakeActiveRenderingSettings();
        }    
        
        [Button] 
        [ShowIf(nameof(showButtons))]
        public void ApplyToTarget()
        {
            preset.ApplyToRendering();
        }
        
        public override void Apply(ProtoWorld world, ProtoEntity entity)
        {
            ref var presetComponent = ref world.GetOrAddComponent<PresetComponent>(entity);
            ref var presetSourceComponent = ref world.GetOrAddComponent<PresetSourceComponent>(entity);
            ref var dataComponent = ref world.GetOrAddComponent<RenderingSettingsPresetComponent>(entity);
            ref var idComponent = ref world.GetOrAddComponent<PresetIdComponent>(entity);
            ref var durationComponent = ref world.GetOrAddComponent<PresetDurationComponent>(entity);
            ref var activePresetSource = ref world.GetOrAddComponent<ActivePresetSourceComponent>(entity);

            idComponent.Value = targetId.GetHashCode();
            dataComponent.Value = preset;
            durationComponent.Value = duration;
        }
    }
}
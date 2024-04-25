namespace unigame.ecs.proto.Ability.AbilityUtilityView.Radius.AggressiveRadius.Converters
{
    using System;
    using Components;
    using Game.Code.GameLayers.Category;
    using Game.Code.GameLayers.Layer;
    using Leopotam.EcsProto;
    using UniGame.AddressableTools.Runtime;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniModules.UniGame.Core.Runtime.DataFlow.Extensions;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    [Serializable]
    public sealed class AggressiveRadiusViewConverter : LeoEcsConverter
    {
        public AssetReferenceGameObject noTargetView;
        public AssetReferenceGameObject targetCloseView;
        public AssetReferenceGameObject hasTargetView;
        
        [CategoryIdMask]
        [SerializeField]
        public CategoryId categoryId;
        [LayerIdMask]
        [SerializeField]
        public LayerId layerMask;
        
        public override void Apply(GameObject target, ProtoWorld world, int entity)
        {
#if !UNITY_EDITOR
            return;
#endif
            var lifeTime = target.GetAssetLifeTime();
            var radiusViewPool = world.GetPool<AggressiveRadiusViewDataComponent>();
            ref var radiusView = ref radiusViewPool.Add(entity);
            
            radiusView.NoTargetRadiusView = noTargetView.LoadAssetInstanceForCompletion(lifeTime,true);
            radiusView.TargetCloseRadiusView = targetCloseView.LoadAssetInstanceForCompletion(lifeTime,true);
            radiusView.HasTargetRadiusView = hasTargetView.LoadAssetInstanceForCompletion(lifeTime,true);

            radiusView.CategoryId = categoryId;
            radiusView.LayerMask = layerMask;

            var viewStatePool = world.GetPool<AggressiveRadiusViewStateComponent>();
            viewStatePool.Add(entity);
        }
    }
}
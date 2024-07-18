namespace Game.Code.DataBase.Runtime
{
    using System;
    using Abstract;
    using Cysharp.Threading.Tasks;
    using UniGame.AddressableTools.Runtime;
    using UniGame.Core.Runtime;
    using UnityEngine;
    using Object = UnityEngine.Object;

    [Serializable]
    public class AddressableResourceLocation : IGameResourceLocation
    {
        public static Type ComponentType = typeof(Component);
        
        public async UniTask<GameResourceResult> LoadAsync<TAsset>(string resource,ILifeTime lifeTime) 
            where TAsset : Object
        {
            var addressableResult = await resource.LoadAssetTaskAsync<TAsset>(lifeTime);

            var result = new GameResourceResult()
            {
                Complete = addressableResult.Complete,
                Error = addressableResult.Error,
                Exception = addressableResult.Exception,
                Result = addressableResult.Result
            };
            
            return result;
        }
    }
}
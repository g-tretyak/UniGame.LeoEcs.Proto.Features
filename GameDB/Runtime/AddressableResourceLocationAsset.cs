namespace Game.Code.DataBase.Runtime
{
    using Cysharp.Threading.Tasks;
    using UniGame.Core.Runtime;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/GameDatabase/Locations/"+nameof(AddressableResourceLocationAsset),
        fileName = nameof(AddressableResourceLocationAsset))]
    public class AddressableResourceLocationAsset : GameResourceLocation
    {
        public AddressableResourceLocation location = new();
        
        public override async UniTask<GameResourceResult> LoadAsync<TAsset>(string resource,ILifeTime lifeTime)
        {
            return await location.LoadAsync<TAsset>(resource, lifeTime);
        }

    }
}
using System;
using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Code.Services.Animation.Data.AnimacerActorList
{
    [Serializable]
    public struct AnimancerActorType
    {
        public string Name;
        public int Id;
    }
}
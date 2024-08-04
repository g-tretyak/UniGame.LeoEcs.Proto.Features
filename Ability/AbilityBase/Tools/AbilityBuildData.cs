namespace UniGame.Ecs.Proto.Ability.Tools
{
    using System;

    [Serializable]
    public struct AbilityBuildData
    {
        public int Slot;
        public bool IsDefault;
        public int AbilityId;
    }
}
namespace UniGame.Ecs.Proto.Ability.Tools
{
    using System;

    [Serializable]
    public struct AbilityBuildData
    {
        public int Slot;
        public bool IsDefault;
        public bool IsUserInput;
        public bool IsBlocked;
        public int AbilityId;
    }
}
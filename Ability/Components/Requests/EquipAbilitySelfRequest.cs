namespace unigame.ecs.proto.AbilityInventory.Components
{
	using Leopotam.EcsProto.QoL;
	using Unity.IL2CPP.CompilerServices;

	/// <summary>
	/// Request to equip ability
	/// </summary>
	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
	public struct EquipAbilitySelfRequest
	{
		public int AbilityId;
		public int AbilitySlot;
		public bool IsUserInput;
		public bool IsDefault;
		public bool IsBlocked;
		public bool Hide;
		public ProtoPackedEntity Target;
	}

}
namespace unigame.ecs.proto.AbilityInventory.Components
{
	using System;
	using Game.Code.Configuration.Runtime.Ability;
	using Leopotam.EcsProto.QoL;
	using Unity.IL2CPP.CompilerServices;

	/// <summary>
	/// Search ability in inventory
	/// </summary>
	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
	[Serializable]
	public struct EquipAbilityIdSelfRequest
	{
		public int AbilityId;
		public int AbilitySlot;
		public bool IsUserInput;
		public bool IsDefault;
		public ProtoPackedEntity Owner;
	}

	/// <summary>
	/// Search ability in inventory
	/// </summary>
	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
	[Serializable]
	public struct EquipAbilityReferenceSelfRequest
	{
		public int AbilitySlot;
		public bool IsUserInput;
		public bool IsDefault;
		public AbilityConfiguration Reference;
		public ProtoPackedEntity Owner;
	}
}
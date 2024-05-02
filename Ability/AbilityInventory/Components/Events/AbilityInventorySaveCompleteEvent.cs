namespace UniGame.Ecs.Proto.AbilityInventory.Components
{
	using Leopotam.EcsProto.QoL;
	using Unity.IL2CPP.CompilerServices;

	/// <summary>
	/// Save to profile complete
	/// </summary>
	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
	public struct AbilityInventorySaveCompleteEvent
	{
		public ProtoPackedEntity Value;
	}
}
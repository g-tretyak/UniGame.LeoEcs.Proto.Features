namespace UniGame.Ecs.Proto.Characteristics.ArmorResist.Aspects
{
	using System;
	using Base.Aspects;
	using Base.Components;
	using Components;
	using Leopotam.EcsProto;

	/// <summary>
	/// Armor resist aspect
	/// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	[Serializable]
	public class ArmorResistAspect : GameCharacteristicAspect<ArmorResistComponent>
	{
		// characteristics marker
		public ProtoPool<CharacteristicComponent<ArmorResistComponent>> Characteristic;
		// armor resist value
		public ProtoPool<ArmorResistComponent> ArmorResist;
	}
}
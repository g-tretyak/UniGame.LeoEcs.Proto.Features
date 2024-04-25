namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.RestrictUITapAreaAction.Components
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	 

	/// <summary>
	/// ADD DESCRIPTION HERE
	/// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	[Serializable]
	public struct RestrictUITapAreasComponent
	{
		public Queue<ProtoPackedEntity> Value;
	}
}
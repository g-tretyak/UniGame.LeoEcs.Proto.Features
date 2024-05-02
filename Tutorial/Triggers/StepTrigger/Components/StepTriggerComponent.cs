﻿namespace UniGame.Ecs.Proto.Gameplay.Tutorial.Triggers.StepTrigger.Components
{
	using System;
	using ActionTools;
	using UnityEngine.Serialization;

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
	public struct StepTriggerComponent
	{
		public int Stage;
		public int Level;
		public TutorialKey StepKey;
	}
}
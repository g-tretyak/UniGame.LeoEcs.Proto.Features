namespace UniGame.Ecs.Proto.Characteristics.SplashDamage.Components
{
	using System;
	
	/// <summary>
	/// Splash Damage value
	/// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	[Serializable]
	public struct SplashDamageComponent
	{
		public float Value;
	}
}
namespace unigame.ecs.proto.Characteristics.ManaRegeneration.Components
{
	using UnityEngine.Serialization;

	/// <summary>
	/// Stores mana regeneration timer.
	/// </summary>
	public struct ManaRegenerationTimerComponent
	{
		public float TickTime;
		public float LastTickTime;
	}
}
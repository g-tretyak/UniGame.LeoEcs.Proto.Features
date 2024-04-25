namespace unigame.ecs.proto.Shaders.Components
{
	using System.Collections.Generic;
	 
	using UnityEngine;

	/// <summary>
	/// Store global mask variables and materials
	/// </summary>
	public struct ChampionGlobalMaskComponent : IProtoAutoReset<ChampionGlobalMaskComponent>
	{
		public List<string> Variables;
		public List<Material> Materials;
		
		public void AutoReset(ref ChampionGlobalMaskComponent c)
		{
			c.Variables ??= new List<string>();
			c.Materials ??= new List<Material>();
			
			c.Materials.Clear();
			c.Variables.Clear();
		}
	}
}
﻿using Terraria.ModLoader;

namespace FluidLibrary.Content
{
	public abstract class ModFluid
	{
		public Mod Mod { get; internal set; }

		public string Name { get; internal set; }
		public ModTranslation DisplayName { get; internal set; }

		public virtual string Texture => (GetType().Namespace + "." + Name).Replace('.', '/');

		public int volume;
		public float VolumeBuckets => volume / 255f;

		public virtual ModFluid Clone()
		{
			ModFluid fluid = (ModFluid)MemberwiseClone();
			fluid.volume = 0;
			return fluid;
		}

		public virtual void Initialize()
		{
		}

		public virtual ModFluid NewInstance()
		{
			var copy = (ModFluid)MemberwiseClone();
			return copy;
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is ModFluid fluid) return fluid.Name == Name;

			return false;
		}
	}
}
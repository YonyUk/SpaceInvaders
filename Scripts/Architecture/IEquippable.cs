using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Architecture{

	public enum StructureType {
		Bullet,
		Ship,
		Engine,
		Shooter
	}

	public enum ModifierType {
		Temporal,
		Permanent,
	}

	public enum UpgradeMode {
		Replace,
		Modify
	}

	public interface IEquippable{
		IStructure Modifier { get; }
		UpgradeMode Mode { get; }
		StructureType StructTarget { get; }
		Dictionary<Object,ModifierType> ModifierTimes { get; }
		GameObject Prefab { get; }
		GameObject gameObject { get; }
	}

	public interface IStructureModifier: IEquippable{
		float LifeTiem { get; }
	}
}
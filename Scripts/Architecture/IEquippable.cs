using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Architecture{

	public enum StructureType {
		Bullet,
		Ship
	}

	public enum ModifierType {
		Temporal,
		Permanent,
	}
	
	public interface IEquippable{
		IStructure Modifier { get; }
		Dictionary<Object,ModifierType> ModifierTimes { get; }
	}
}
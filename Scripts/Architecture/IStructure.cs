using UnityEngine;
using System.Collections;

namespace Architecture{
	public interface IStructure{
		Transform transform { get; }
		GameObject gameObject { get; }
		StructureType Structure { get; }
		void Upgrade(IEquippable other);
	}
}
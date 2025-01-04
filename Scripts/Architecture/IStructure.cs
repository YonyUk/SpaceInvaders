using UnityEngine;
using System.Collections;

namespace Architecture{
	public interface IStructure{
		StructureType Structure { get; }
		void Upgrade(IStructure other);
	}
}
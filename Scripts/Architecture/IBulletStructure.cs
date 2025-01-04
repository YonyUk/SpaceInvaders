using UnityEngine;
using System.Collections;

namespace Architecture{
	public interface IBulletStructure:IStructure{
		float Speed { get; }
		int Damage { get; }
	}
}
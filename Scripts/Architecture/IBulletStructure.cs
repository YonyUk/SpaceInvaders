using UnityEngine;
using System.Collections;

namespace Architecture{
	public interface IBulletStructure:IStructure{
		float Speed { get; }
		int LifeTime { get; }
		int Damage { get; }
	}
}
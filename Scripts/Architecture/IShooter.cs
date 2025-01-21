using UnityEngine;
using System.Collections;

namespace Architecture{
	public interface IShooter:IStructure{
		void Shoot(Vector3 direction);
	}
}
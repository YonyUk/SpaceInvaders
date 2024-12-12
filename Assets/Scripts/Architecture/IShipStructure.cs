using UnityEngine;
using System.Collections;

namespace Architecture{

	public interface IShipStructure:IStructure{
		IShooter Shooter { get; }
		float Speed { get; }
		float MaxSpeed { get; }
	}
}
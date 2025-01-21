using UnityEngine;
using System.Collections;

namespace Architecture{
	// interface que caracteriza al motor de la nave
	public interface IEngine: IStructure{
		float Force { get; }
	}
}
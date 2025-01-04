using UnityEngine;
using System.Collections;
using Architecture;

namespace WorldConfig {
	public static class Globals{
		public static Vector3 ShipScale = new Vector3 (0.25f, 0.25f, 0.25f);
		public static IShipStructure InitialShipStructure = new DefaultShipStructure ();
	}
}
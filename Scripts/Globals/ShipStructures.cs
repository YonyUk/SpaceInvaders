using UnityEngine;
using System.Collections;
using Architecture;

namespace WorldConfig{
	public class DefaultShipStructure: IShipStructure {
		// velocidad de la nave
		public float Speed { get; private set; }
		// maxima velocidad de la nave
		public float MaxSpeed { get; private set; }
		// shooter de la nave
		public IShooter Shooter { get; private set; }
		// tipo de estructura
		public StructureType Structure { get; private set; }
		
		public DefaultShipStructure(){
			Speed = 0.25f;
			MaxSpeed = 1f;
			Structure = StructureType.Ship;
		}

		public void Upgrade(IStructure other){}
	}
}
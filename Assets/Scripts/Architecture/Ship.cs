using UnityEngine;
using System.Collections;

namespace Architecture{

	public abstract class Ship: MonoBehaviour {
		// Estructura de la nave
		protected IShipStructure Specifications { get; set; }
		// Activa el nitro
		protected abstract void UseNitro();
		// Recibe el damage
		protected abstract void TakeDamage(int damage);
		// Mueve la nave
		protected virtual void Move(Vector3 direction){
			transform.Translate (direction.normalized * Specifications.Speed);
		}
		// Rota la nave
		protected virtual void Rotate(Vector3 rotation){
			transform.Rotate (rotation);
		}
		// Dispara
		protected virtual void Shoot(){
			Specifications.Shooter.Shoot();
		}
		protected virtual void Upgrade(IStructure modifier){
			if (modifier.Structure == StructureType.Ship)
				Specifications.Upgrade (modifier);
		}
	}
}
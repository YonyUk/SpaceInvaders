using UnityEngine;
using System.Collections;

namespace Architecture{

	public abstract class Ship: MonoBehaviour {
		protected Vector3 shoot_direction { get; set; }
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
			Specifications.Shooter.Shoot(shoot_direction);
		}
		public virtual void Upgrade(IEquippable modifier){
			if (modifier.StructTarget == StructureType.Ship && modifier.Mode == UpgradeMode.Replace) {
				Specifications = (IShipStructure)modifier.Modifier;
			}
			else
				Specifications.Upgrade (modifier);
		}
	}
}
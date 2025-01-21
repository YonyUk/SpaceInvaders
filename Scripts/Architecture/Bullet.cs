using UnityEngine;
using System.Collections;

namespace Architecture{
	public abstract class Bullet:MonoBehaviour{

		protected Vector3 direction { get; set; }
		protected IBulletStructure Specifications { get; set; }
		public virtual void SetDirection(Vector3 direction){
			this.direction = direction;
		}
		protected void Update(){
			transform.Translate (direction.normalized * Specifications.Speed);
		}
		protected abstract void OnCollision();
	}
}
using UnityEngine;
using System.Collections;

namespace Architecture{
	public abstract class Bullet:MonoBehaviour{
		protected IBulletStructure Specifications { get; set; }
		protected abstract void Move();
		protected abstract void OnCollision();
	}
}
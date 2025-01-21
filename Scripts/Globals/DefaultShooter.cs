using UnityEngine;
using System.Collections;
using WorldConfig;
using Architecture;

public class DefaultShooter : MonoBehaviour,IShooter {

	public GameObject BulletPrefab;

	public StructureType Structure {
		get{ return StructureType.Shooter; }
	}

	public void Shoot(Vector3 direction){
		foreach (Vector3 canon in Globals.DefaultShooterCanons) {
			Bullet bullet = ((GameObject)Instantiate (BulletPrefab, transform.position + canon, Globals.DefaultBulletRotation)).GetComponent<Bullet>();
			bullet.SetDirection (direction);
		}
	}
	void Start(){
		transform.localScale = Globals.ShipScale;
		transform.localPosition = Globals.DefaultShooterOffsetPosition;
	}
	public void Upgrade(IEquippable other){
		throw new System.NotImplementedException ();
	}
}

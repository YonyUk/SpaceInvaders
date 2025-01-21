using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Architecture;
using WorldConfig;

public class PlasmaShooter : MonoBehaviour, IShooter {

	public GameObject BulletPrefab;

	public StructureType Structure {
		get{ return StructureType.Shooter; }
	}
	// Use this for initialization
	void Start () {
		transform.localScale = Globals.ShipScale;
		transform.localPosition = Globals.DefaultShooterOffsetPosition;
	}

	public void Shoot(Vector3 direction){
		foreach (Vector3 canon in Globals.DefaultShooterCanons) {
			Bullet bullet = ((GameObject)Instantiate (BulletPrefab, transform.position + canon, Globals.DefaultBulletRotation)).GetComponent<Bullet>();
			bullet.SetDirection (direction);
		}
	}

	public void Upgrade(IEquippable modifier){
		throw new System.NotImplementedException ();
	}
}

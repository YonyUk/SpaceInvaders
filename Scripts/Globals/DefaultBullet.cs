using UnityEngine;
using System.Collections;
using Architecture;
using WorldConfig;

public class DefaultBullet : Bullet {

	public GameObject bulletStructurePrefab;
	
	void Awake(){
		Specifications = ((GameObject)Instantiate (bulletStructurePrefab, transform.position, Quaternion.identity)).GetComponent<IBulletStructure> ();
		transform.localScale = Globals.DefaultBulletScale;
	}
	void Start(){
		Destroy (gameObject, Specifications.LifeTime);
	}

	protected override void OnCollision(){
		throw new System.NotImplementedException ();
	}
}

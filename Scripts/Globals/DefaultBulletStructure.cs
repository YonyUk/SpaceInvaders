using UnityEngine;
using System.Collections;
using Architecture;
using WorldConfig;

public class DefaultBulletStructure : MonoBehaviour, IBulletStructure{

	public float Speed { get; private set; }
	public int LifeTime { get; private set; }
	public int Damage { get; private set; }

	public StructureType Structure {
		get{ return StructureType.Bullet; }
	}
	// Use this for initialization
	void Awake() {
		Speed = Globals.DefaultBulletSpeed;
		LifeTime = Globals.BulletLifeTime;
	}

	void Start(){
		Destroy (gameObject, LifeTime);
	}

	public void Upgrade(IEquippable other){
		throw new System.NotImplementedException();
	}
}

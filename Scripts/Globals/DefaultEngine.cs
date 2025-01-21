using UnityEngine;
using System.Collections;
using Architecture;
using WorldConfig;

public class DefaultEngine : MonoBehaviour, IEngine{

	public float Force { get; private set; }

	public StructureType Structure {
		get{ return StructureType.Engine; }
	}
	// Use this for initialization
	void Start () {
		Force = Globals.DefaultEngineForce;
		transform.localScale = Globals.ShipScale;
		transform.localPosition = Globals.DefaultEngineOffsetPosition;
	}
	public void Upgrade(IEquippable other){
		throw new System.NotImplementedException ();
	}
}

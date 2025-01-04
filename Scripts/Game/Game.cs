using UnityEngine;
using System.Collections;
using WorldConfig;

public class Game : MonoBehaviour {

	public GameObject ShipModel;
	// Use this for initialization
	GameObject Player;

	void Start () {
		Player = (GameObject)Instantiate (ShipModel, new Vector3 (), Quaternion.identity);
		Player.transform.localScale = Globals.ShipScale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using WorldConfig;
using Architecture;

public class Game : MonoBehaviour {

	public GameObject ShipModel;
	public GameObject ItemPrefab;
	float item_timer_counter { get; set; }
	// Use this for initialization
	GameObject Player;
	GameObject Item;

	void Start () {
		item_timer_counter = 0;
		Player = (GameObject)Instantiate (ShipModel, new Vector3 (), Quaternion.identity);
		Player.transform.localScale = Globals.ShipScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (item_timer_counter >= Globals.ItemsRate) {
			if (Item == null)
			{
				Item = (GameObject)Instantiate (ItemPrefab, new Vector3 (3, 0, 3), Quaternion.identity);
				Item.transform.localScale = Globals.ItemScale;
			}
			item_timer_counter = 0;
		}
		if (Item != null)
			UpdateItemShipRelation ();
		item_timer_counter += Time.deltaTime;
	}
	void UpdateItemShipRelation(){
		Vector3 distance = Item.transform.position - Player.transform.position;
		if (distance.magnitude < Globals.ItemDistanceToCatch) {
			Player.GetComponent<Ship> ().Upgrade (Item.GetComponent<IEquippable> ());
		}
	}
}

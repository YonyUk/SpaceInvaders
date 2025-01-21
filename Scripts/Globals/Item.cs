using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Architecture;
using WorldConfig;

public class Item : MonoBehaviour,IEquippable {

	//lista de items modificadores
	public GameObject[] modifiersList;
	public IStructure Modifier { get; private set; }
	public Dictionary<Object,ModifierType> ModifierTimes { get; private set; }

	GameObject modifierPrefab { get; set; }
	Camera main_camera { get; set; }
	Vector3 target_pos { get; set; }
	System.Random random { get; set; }

	public GameObject Prefab {
		get{ return modifierPrefab; }
	}

	public UpgradeMode Mode {
		get{ return UpgradeMode.Replace; }
	}

	void SetModifier(){
		modifierPrefab = modifiersList [random.Next (0, modifiersList.Length)];
		GameObject obj = (GameObject)Instantiate (modifierPrefab, transform.position, Quaternion.identity);
		switch (StructTarget) {
		case StructureType.Shooter:
			Modifier = obj.GetComponent<IShooter>();
			break;
		default:
			throw new System.NotImplementedException();
		}
		Modifier.transform.SetParent (transform);
	}

	public StructureType StructTarget {
		get{ return StructureType.Shooter; }
	}

	void SelectNewTargetPos(){
		Vector3 viewPos = main_camera.WorldToViewportPoint (transform.position);
		target_pos = new Vector3 ((float)random.NextDouble(),(float)random.NextDouble(),viewPos.z);
		target_pos = main_camera.ViewportToWorldPoint (target_pos);
	}

	void Start(){
		random = new System.Random ();
		SetModifier ();
		Modifier.transform.rotation = Quaternion.Euler (Globals.ItemRotation);
		main_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		SelectNewTargetPos ();
	}

	void FixedUpdate(){
		if ((transform.position - target_pos).magnitude < Globals.ItemDistanceToCatch) {
			SelectNewTargetPos ();
		}
		else {
			transform.Translate((target_pos - transform.position).normalized * Globals.DefaultStructureSpeed / 2);
		}
	}
}

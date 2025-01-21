using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Architecture;
using WorldConfig;

public class DefaultShipStructure : MonoBehaviour,IShipStructure {
	//shooter de la nave
	public GameObject shooter;
	//motor de la nave
	public GameObject engine;
	//velocidad de la nave
	public float Speed { get; private set; }
	//maxima velocidad de la nave
	public float MaxSpeed { get; private set; }

	public IShooter Shooter{ get; private set; }

	public IEngine Engine { get; private set; }

	Dictionary<StructureType,IStructure> StructureMap { get; set; }

	public StructureType Structure {
		get{ return StructureType.Ship; }
	}

	public void Upgrade(IEquippable modifier){
		//si es un equpable de remplazamiento de piezas
		if (modifier.Mode == UpgradeMode.Replace) {
			IStructure new_piece = ((GameObject)Instantiate(modifier.Prefab,transform.position,transform.rotation)).GetComponent<IStructure>();
			switch (modifier.StructTarget) {
			case StructureType.Engine:
				Engine = (IEngine)new_piece;
				StructureMap [StructureType.Engine] = Engine;
				break;
			case StructureType.Shooter:
				Destroy(Shooter.gameObject);
				Shooter = (IShooter)new_piece;
				StructureMap [StructureType.Shooter] = Shooter;
				Shooter.transform.SetParent(transform);
				break;
			default:
				throw new System.NotImplementedException ();
			}
		}
		// si esta destinado a la estructura de la nave
		else if (modifier.StructTarget == StructureType.Ship) {
			throw new System.NotImplementedException();
		}
		// se modifica la estructura a la que esta destinado
		else {
			StructureMap[modifier.StructTarget].Upgrade(modifier);
		}
		Destroy (modifier.gameObject);
	}

	void Start(){
		StructureMap = new Dictionary<StructureType, IStructure> ();
		Speed = Globals.DefaultStructureSpeed;
		MaxSpeed = Globals.DefaultStructureMaxSpeed;
		Engine = ((GameObject)Instantiate (engine, transform.position, Quaternion.identity)).GetComponent<IEngine> ();
		Engine.transform.SetParent (transform);
		Shooter = ((GameObject)Instantiate (shooter, transform.position, Quaternion.identity)).GetComponent<IShooter> ();
		Shooter.transform.SetParent (transform);
		InitStructMap ();
	}

	void InitStructMap(){
		StructureMap [StructureType.Engine] = Engine;
		StructureMap [StructureType.Shooter] = Shooter;
	}
}

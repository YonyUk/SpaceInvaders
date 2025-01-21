using UnityEngine;
using System.Collections;
using Architecture;
using WorldConfig;

public class PlayerShip : Ship {
	//structura de la nave
	public GameObject structure;
	// vector de movimiento
	Vector3 movement { get; set; }
	// rotacion en eje x
	float x_rotation { get; set; }
	// rotacion en eje z
	float z_rotation { get; set; }
	// maxima rotacion permitida en x y z
	float max_rotation = 15f;
	// incremento de rotacion en ejes
	float rotation_increment = 5f;
	//camara del juego
	GameObject main_camera { get; set; }
	// metodo heredado para el nitro
	protected override void UseNitro(){
		throw new System.NotImplementedException ();
	}
	// metodo heredado para recibir dano
	protected override void TakeDamage(int damage){
		throw new System.NotImplementedException ();
	}

	void Start(){
		Specifications = ((GameObject)Instantiate (structure, transform.position, Quaternion.identity)).GetComponent<IShipStructure> ();
		Specifications.transform.SetParent (transform);
		shoot_direction = transform.up;
		main_camera = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	void Update(){
		movement = new Vector3 ();
		DirectionalControls ();
		WeaponsControls ();
		transform.localRotation = Quaternion.Euler (new Vector3 (x_rotation, 0, z_rotation));
		Move (movement);
		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
	}

	void WeaponsControls(){
		if (Input.GetKeyUp(KeyCode.Space))
			Shoot ();
	}
	
	void DirectionalControls(){
		bool z_moving, x_moving;
		x_moving = false;
		z_moving = false;
		Vector3 viewPos = main_camera.GetComponent<Camera> ().WorldToViewportPoint (transform.position);
		if (Input.GetKey (KeyCode.W) && viewPos.y <= 1 - Globals.BorderViewSize) {
			z_moving = true;
			movement += new Vector3(0,0,1);
			if (x_rotation < max_rotation)
				x_rotation += rotation_increment;
		}
		if (Input.GetKey (KeyCode.S) && viewPos.y >= Globals.BorderViewSize) {
			z_moving = true;
			movement += new Vector3 (0, 0, -1);
			if (x_rotation > -1 * max_rotation)
				x_rotation -= rotation_increment;
		}
		if (Input.GetKey (KeyCode.A) && viewPos.x >= Globals.BorderViewSize / 2) {
			x_moving = true;
			movement += new Vector3 (-1, 0, 0);
			if (z_rotation < 2*max_rotation)
				z_rotation += rotation_increment;
		}
		if (Input.GetKey (KeyCode.D) && viewPos.x <= 1 - Globals.BorderViewSize / 2) {
			x_moving = true;
			movement += new Vector3 (1, 0, 0);
			if (z_rotation > -2 * max_rotation)
				z_rotation -= rotation_increment;
		}
		if (!z_moving) {
			if (x_rotation > 0)
				x_rotation -= rotation_increment;
			else if(x_rotation < 0)
				x_rotation += rotation_increment;
		}
		if (!x_moving) {
			if (z_rotation > 0)
				z_rotation -= rotation_increment;
			else if(z_rotation < 0)
				z_rotation += rotation_increment;
		}
	}
}

using UnityEngine;
using System.Collections;
using Architecture;
using WorldConfig;

public class PlayerShip : Ship {
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
	// metodo heredado para el nitro
	protected override void UseNitro(){}
	// metodo heredado para recibir dano
	protected override void TakeDamage(int damage){}

	void Start(){
		// damos una structura inicial
		Specifications = Globals.InitialShipStructure;
	}

	void Update(){
		movement = new Vector3 ();
		DirectionalControls ();
		transform.localRotation = Quaternion.Euler (new Vector3 (x_rotation, 0, z_rotation));
		Move (movement);
		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
	}

	void DirectionalControls(){
		bool z_moving, x_moving;
		x_moving = false;
		z_moving = false;
		if (Input.GetKey (KeyCode.W)) {
			z_moving = true;
			movement += new Vector3(0,0,1);
			if (x_rotation < max_rotation)
				x_rotation += rotation_increment;
		}
		if (Input.GetKey (KeyCode.S)) {
			z_moving = true;
			movement += new Vector3 (0, 0, -1);
			if (x_rotation > -1 * max_rotation)
				x_rotation -= rotation_increment;
		}
		if (Input.GetKey (KeyCode.A)) {
			x_moving = true;
			movement += new Vector3 (-1, 0, 0);
			if (z_rotation < max_rotation)
				z_rotation += rotation_increment;
		}
		if (Input.GetKey (KeyCode.D)) {
			x_moving = true;
			movement += new Vector3 (1, 0, 0);
			if (z_rotation > -1 * max_rotation)
				z_rotation -= rotation_increment;
		}
		if (!x_moving) {
			if (x_rotation > 0)
				x_rotation -= rotation_increment;
			if (x_rotation < 0)
				x_rotation += rotation_increment;
		}
		if (!z_moving) {
			if (z_rotation > 0)
				z_rotation -= rotation_increment;
			if (z_rotation < 0)
				z_rotation += rotation_increment;
		}
	}
}

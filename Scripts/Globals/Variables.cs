using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Architecture;
using System.IO;

namespace WorldConfig {
	public static class Globals{
		//scala de la nave
		public static Vector3 ShipScale = Vector3.one * 0.07f;
		//velocidad de la estructura inicial de la nave
		public static float DefaultStructureSpeed = 0.1f;
		//maxima velocidad de la estructura inicial de la nave
		public static float DefaultStructureMaxSpeed = 0.2f;
		//fuerza de impulso del motor inicial de la nave
		public static float DefaultEngineForce = 3f;
		//posicion relativa a la nave del motor inicial de la nave
		public static Vector3 DefaultEngineOffsetPosition = new Vector3 (0, 0.06f, -0.5f);
		//posicion relativa a la nave del arma inicial de la nave
		public static Vector3 DefaultShooterOffsetPosition = new Vector3 (0, 0.12f, -0.05f);
		//posiciones de los canones del arma inicial de la nave
		public static Vector3[] DefaultShooterCanons = new[]{new Vector3(-0.3f,0.9f,0.35f), new Vector3(0.3f,0.9f,0.35f)};
		//posiciones de los canones del canon de plasma
		public static Vector3[] PlasmaShooterCanons = new[]{new Vector3(-0.3f,0.9f,0.35f), new Vector3(0.3f,0.9f,0.35f)};
		//velocidad de los proyectiles iniciales
		public static float DefaultBulletSpeed = 0.5f;
		//escala de los proyectiles iniciales
		public static Vector3 DefaultBulletScale = new Vector3 (0.01f, 0.1f, 0.01f);
		//rotacion de los proyectiles iniciales
		public static Quaternion DefaultBulletRotation = Quaternion.Euler (new Vector3 (90f, 0f, 0f));
		//tiempo de vida de los proyectiles
		public static int BulletLifeTime = 2;
		//rotacion de los items para mostrar el contenido
		public static Vector3 ItemRotation = new Vector3 (25f, 65f, 55f);
		//scala de los items
		public static Vector3 ItemScale = Vector3.one * 1.7f;
		//distancia para atrapar un item
		public static float ItemDistanceToCatch = 0.5f * Mathf.Sqrt (2);
		//distancia a los bordes de la pantalla
		public static float BorderViewSize = 0.05f;
		//tiempo entre cada disparo de un item
		public static float ItemsRate = 5f;
	}
}
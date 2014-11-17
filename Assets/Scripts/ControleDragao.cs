using UnityEngine;
using System.Collections;

public class ControleDragao : MonoBehaviour {
	public GameObject bolaOriginal;
	public float velocidadeTranslacao;
	public float velocidadeRotacao;

	void Update () {
		if (Input.GetButtonUp ("JogarBolaDeFogo")) {
			GameObject bolaNova = Instantiate(bolaOriginal, transform.position, transform.rotation) as GameObject;
			Physics.IgnoreCollision(collider, bolaNova.collider);
			bolaNova.rigidbody.AddForce(-Vector3.right * 1000);
		}
	}

	void FixedUpdate () {
		float translacao = Input.GetAxis ("DragaoVertical") * velocidadeTranslacao;
		float rotacao    = Input.GetAxis ("DragaoHorizontal") * velocidadeRotacao;
		translacao *= Time.deltaTime;
		rotacao    *= Time.deltaTime;
		transform.Translate (translacao, 0, 0);
		transform.Rotate (0, rotacao, 0);
	}
}

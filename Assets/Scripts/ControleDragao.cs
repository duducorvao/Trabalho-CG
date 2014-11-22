using UnityEngine;
using System.Collections;

public class ControleDragao : MonoBehaviour {
	public GameObject bolaOriginal;
	public GameObject fumaca;
	public float velocidadeTranslacao;
	public float velocidadeRotacao;

	void Update () {
		if (Input.GetButtonUp ("JogarBolaDeFogo")) {
			GameObject bolaNova = Instantiate(bolaOriginal, transform.position, transform.rotation) as GameObject;
			Physics.IgnoreCollision(collider, bolaNova.collider);
			bolaNova.rigidbody.AddForce(-Vector3.right * 1000);
		}

		// todo: colocar no lugar certo
		if (Input.GetKeyUp(KeyCode.M)) {
			StartCoroutine(AnimacaoMorte(Vector3.up * 720.0f, Vector3.one * 0.1f, 3.0f));
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


	IEnumerator AnimacaoMorte(Vector3 anguloGiro, Vector3 tamanhoFinal, float duracao) {
		Vector3 grausPorSegundo = anguloGiro / duracao;
		Vector3 scalePorSegundo = (tamanhoFinal - transform.localScale) / duracao;
		Debug.Log (grausPorSegundo);
		Debug.Log (scalePorSegundo);
		for(float t = 0f ; t < duracao; t += Time.deltaTime) {
			transform.Rotate(grausPorSegundo * Time.deltaTime);
			transform.localScale += scalePorSegundo * Time.deltaTime;
			yield return null ;
		}
		fumaca.transform.position = transform.position;
		fumaca.SetActive (true);
	}
}

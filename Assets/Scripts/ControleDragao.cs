using UnityEngine;
using System.Collections;

public class ControleDragao : MonoBehaviour {
	public GameObject jogador;
	public GameObject bolaOriginal;
	public GameObject fumaca;
 	public GameObject[] caminho;
	public GameObject cameraJogador;
	public GameObject cameraDragao;
	public float velocidadeTranslacao;
	public float velocidadeRotacao;

	void Update () {
		if (Input.GetButtonUp ("JogarBolaDeFogo")) {
			GameObject bolaNova = Instantiate(bolaOriginal, transform.position, transform.rotation) as GameObject;
			Physics.IgnoreCollision(collider, bolaNova.collider);
			bolaNova.rigidbody.AddForce(-Vector3.right * 1000);
		}

		// TODO: colocar no lugar certo
		if (Input.GetKeyUp(KeyCode.M)) {
			StartCoroutine(AnimacaoMorte(Vector3.up * 720.0f, Vector3.one * 0.1f, 3.0f));
		}
	}

	void FixedUpdate () {
		float translacao = Input.GetAxis ("DragaoVertical") * velocidadeTranslacao;
		float rotacao    = Input.GetAxis ("DragaoHorizontal") * velocidadeRotacao;
		transform.Translate (translacao * Time.deltaTime, 0, 0);
		transform.Rotate (0, rotacao * Time.deltaTime, 0);
	}

	IEnumerator AnimacaoMorte(Vector3 anguloGiro, Vector3 tamanhoFinal, float duracao) {
		Vector3 grausPorSegundo = anguloGiro / duracao;
		Vector3 scalePorSegundo = (tamanhoFinal - transform.localScale) / duracao;
		for(float t = 0f ; t < duracao; t += Time.deltaTime) {
			transform.Rotate(grausPorSegundo * Time.deltaTime);
			transform.localScale += scalePorSegundo * Time.deltaTime;
			yield return null ;
		}
		fumaca.transform.position = transform.position;
		fumaca.SetActive (true);
	}

	public IEnumerator IrParaArena(float duracaoTotal) {
		float distanciaTotal = 0.0f;
		Transform ultimo;
		Transform atual;
		// calcula as distancias de cada trecho. inicialmente o vetor tempos tem a distancia de cada trecho
		float[] tempos = new float[caminho.Length];
		ultimo = transform;
		for (int i = 0; i < caminho.Length; i++) {
			atual = caminho[i].transform;
			tempos[i] = Vector3.Distance(ultimo.position, atual.position);
			distanciaTotal += tempos[i];
			ultimo = atual;
		}
		// calcula o tempo de cada trecho. agora o vetor tempos tem, de fato, os tempos de cada trecho
		for (int i = 0; i < caminho.Length; i++)
		tempos[i] = tempos[i] / distanciaTotal;
		// 
		alterarCameras();
		// faz o movimento
		float velocidade = distanciaTotal / duracaoTotal;
		float duracaoAtual;
		ultimo = transform;
		for (int i = 0; i < caminho.Length; i++) {
			atual = caminho[i].transform;
			duracaoAtual = tempos[i] * duracaoTotal;
			for (float t = 0.0f; t < duracaoAtual; t += Time.deltaTime) {
				transform.position = Vector3.MoveTowards(transform.position, atual.position, velocidade * Time.deltaTime);
				yield return null;
			}
			ultimo = atual;
		}

		rigidbody.useGravity = true;
		alterarCameras ();
	}

	void alterarCameras() {
		bool jogador = cameraJogador.camera.enabled;
		cameraJogador.camera.enabled = !jogador;
		cameraDragao.camera.enabled = jogador;
	}
}

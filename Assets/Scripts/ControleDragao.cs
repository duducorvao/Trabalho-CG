using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ControleDragao : MonoBehaviour {
	public GameObject jogador;
	public GameObject bolaOriginal;
	public GameObject fumaca;
 	public GameObject[] caminho;
	public GameObject cameraJogador;
	public GameObject cameraDragao;
	public GameObject cameraBau;
	public ControleIluminacao iluminacao;
	public float velocidadeTranslacao;
	public float velocidadeRotacao;
	public AudioClip somMorte;

	void Update () {
		if (Input.GetButtonUp ("JogarBolaDeFogo")) {
			GameObject bolaNova = Instantiate(bolaOriginal, transform.position, transform.rotation) as GameObject;
			Physics.IgnoreCollision(collider, bolaNova.collider);
			bolaNova.rigidbody.AddRelativeForce(Quaternion.Euler(0, -90, 0) * Vector3.forward * 1000);
		}
		if (Input.GetButtonUp("BotaoRabada"))
			StartCoroutine(Rabada(Vector3.up * -45.0f, 0.25f, Vector3.up * (360.0f + 45.0f), 1.0f));
	}

	void FixedUpdate () {
		float translacao = Input.GetAxis ("DragaoVertical") * velocidadeTranslacao;
		float rotacao    = Input.GetAxis ("DragaoHorizontal") * velocidadeRotacao;
		transform.Translate (translacao * Time.deltaTime, 0, 0);
		transform.Rotate (0, rotacao * Time.deltaTime, 0);
	}

	IEnumerator Rabada(Vector3 anguloGiro1, float duracao1, Vector3 anguloGiro2, float duracao2) {
		Vector3 grausPorSegundo1 = anguloGiro1 / duracao1;
		for(float t = 0f ; t < duracao1; t += Time.deltaTime) {
			transform.Rotate(grausPorSegundo1 * Time.deltaTime);
			yield return null;
		}
		Vector3 grausPorSegundo2 = anguloGiro2 / duracao2;
		for(float t = 0f ; t < duracao2; t += Time.deltaTime) {
			transform.Rotate(grausPorSegundo2 * Time.deltaTime);
			yield return null;
		}
	}
	public IEnumerator AnimacaoMorte(Vector3 anguloGiro, Vector3 tamanhoFinal, float duracao) {
		ControleSom.tocarDragaoMorrendo ();
		Vector3 grausPorSegundo = anguloGiro / duracao;
		Vector3 scalePorSegundo = (tamanhoFinal - transform.localScale) / duracao;
		for(float t = 0f ; t < duracao; t += Time.deltaTime) {
			transform.Rotate(grausPorSegundo * Time.deltaTime);
			transform.localScale += scalePorSegundo * Time.deltaTime;
			yield return null ;
		}

		fumaca.transform.position = transform.position;
		fumaca.SetActive (true);

		ControleSom.tocarDragaoEstrondo ();
		yield return new WaitForSeconds(5.0f);


		StartCoroutine (iluminacao.Fade (false, 3.0f));

		alterarCamerasBau();
	}

	public IEnumerator IrParaArena(float duracaoTotal) {
		ControleSom.tocarDragaoVoando ();

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
		alterarCamerasJogadorDragao();
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

		ControleSom.parar ();

		rigidbody.useGravity = true;
		alterarCamerasJogadorDragao ();
	}

	void alterarCamerasJogadorDragao() {
		bool jogador = cameraJogador.camera.enabled;
		cameraJogador.camera.enabled = !jogador;
		cameraDragao.camera.enabled = jogador;
	}
	void alterarCamerasBau() {
		cameraJogador.camera.enabled = false;
		cameraDragao.camera.enabled = false;
		cameraBau.camera.enabled = true;
	}
}

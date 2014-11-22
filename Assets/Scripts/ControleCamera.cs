using UnityEngine;
using System.Collections;

public class ControleCamera : MonoBehaviour {
	public GameObject jogador;
	public GameObject dragao;
	public float anguloRotacao;

	void Start() {
		alterarCameraParaDragao ();
	}

	void Update () {
		if (Input.GetButtonUp ("BotaoTipoProjecao")) {
			camera.orthographic = !camera.orthographic;
		}

		float rotacaoY = Input.GetAxis("BotaoRotacionarY");
		float rotacaoX = Input.GetAxis("BotaoRotacionarX");
		if (rotacaoY > 0)
			rotacaoY = 1;
		else if (rotacaoY < 0)
			rotacaoY = -1;
		if (rotacaoX > 0)
			rotacaoX = 1;
		else if (rotacaoX < 0)
			rotacaoX = -1;

		if (rotacaoY != 0)
			transform.RotateAround (jogador.transform.position, Vector3.up, anguloRotacao * rotacaoY * Time.deltaTime);
		if (rotacaoX != 0)
			transform.RotateAround (jogador.transform.position, Vector3.forward, anguloRotacao * rotacaoX * Time.deltaTime);
	}

	void alterarCameraParaJogador() {
		Camera.main.transform.parent = jogador.transform;
		transform.localPosition = new Vector3 (0.0f, 2.0f, 3.0f);
		transform.localRotation = Quaternion.Euler (15.0f, 180.0f, 0.0f);
	}
	void alterarCameraParaDragao() {
		Camera.main.transform.parent = dragao.transform;
		transform.localPosition = new Vector3 (0.0f, 2.0f, 3.0f);
		transform.localRotation = Quaternion.Euler (15.0f, 180.0f, 0.0f);
	}
}

using UnityEngine;
using System.Collections;

public class ControleCamera : MonoBehaviour {
	public GameObject jogador;
	public float anguloRotacao;

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
}

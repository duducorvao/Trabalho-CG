using UnityEngine;
using System.Collections;

public class ControleJogador : MonoBehaviour {
	public float velocidadeTranslacao;
	public float velocidadeRotacao;

	void FixedUpdate () {
		float translacao = Input.GetAxis ("JogadorVertical") * velocidadeTranslacao;
		float rotacao    = Input.GetAxis ("JogadorHorizontal") * velocidadeRotacao;
		translacao *= Time.deltaTime;
		rotacao    *= Time.deltaTime;
		transform.Translate (translacao, 0, 0);
		transform.Rotate (0, rotacao, 0);
	} 
}

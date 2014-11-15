using UnityEngine;
using System.Collections;

public class ControleJogador : MonoBehaviour {
	public float velocidadeTranslacao;
	public float velocidadeRotacao;

	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate () {
		float translacao = Input.GetAxis ("JogadorVertical") * velocidadeTranslacao;
		float rotacao    = Input.GetAxis ("JogadorHorizontal") * velocidadeRotacao;
		translacao *= Time.deltaTime;
		rotacao    *= Time.deltaTime;
		rigidbody.transform.Translate (translacao, 0, 0);
		rigidbody.transform.Rotate (0, rotacao, 0);
//		rigidbody.AddForce (new Vector3 (movVertical, 0, movHorizontal));
	} 
}

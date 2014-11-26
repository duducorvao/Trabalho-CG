using UnityEngine;
using System.Collections;

public class ColisaoPoder : MonoBehaviour {
	public ControleJogador jogador;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Dragao") {
			jogador.atingiu = true;
			collider.enabled = false;
		}
	}
}

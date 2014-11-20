using UnityEngine;
using System.Collections;

public class ControleLuz : MonoBehaviour {
	public GameObject iluminacao;
	bool jaPassou;

	void Start() {
		jaPassou = false;
	}
	
	void OnTriggerEnter(Collider other) {
		if (!jaPassou) {
			ControleIluminacao controleIluminacao = (ControleIluminacao)iluminacao.GetComponent (typeof(ControleIluminacao));
			controleIluminacao.CriarFade (true);
			jaPassou = true;
		}
	}
}

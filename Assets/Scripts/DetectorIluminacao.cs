using UnityEngine;
using System.Collections;

public class DetectorIluminacao : MonoBehaviour {
	public ControleIluminacao iluminacao;
	public ControleDragao dragao;
	public GameObject cameraJogador;
	public GameObject cameraDragao;
	bool jaPassou;

	void Start() {
		jaPassou = false;
	}
	
	void OnTriggerEnter(Collider other) {
		if (!jaPassou) {
			StartCoroutine(iluminacao.Fade(true, 2.0f));
			cameraDragao.SetActive(true);
			cameraJogador.SetActive(false);
			StartCoroutine(dragao.IrParaArena(5.0f));
			cameraDragao.SetActive(false);
			cameraJogador.SetActive(true);
			jaPassou = true;

		}
	}
}

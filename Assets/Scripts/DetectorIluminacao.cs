using UnityEngine;
using System.Collections;

public class DetectorIluminacao : MonoBehaviour {
	public ControleIluminacao iluminacao;
	public ControleDragao dragao;
	bool jaPassou;

	void Start() {
		jaPassou = false;
	}
	
	void OnTriggerEnter(Collider other) {
		if (!jaPassou) {
			StartCoroutine(animar());
			jaPassou = true;

		}
	}
	IEnumerator animar() {
		StartCoroutine(iluminacao.Fade(true, 3.0f));
		yield return new WaitForSeconds(1.0f);
		dragao.gameObject.SetActive(true);
		StartCoroutine(dragao.IrParaArena(5.0f));
	}
}


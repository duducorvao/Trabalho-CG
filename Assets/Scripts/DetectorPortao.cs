using UnityEngine;
using System.Collections;

public class DetectorPortao : MonoBehaviour {
	public GameObject portao;

	IEnumerator LevantarPortao(Vector3 incrementoPosicao, float duracao) {
		Vector3 deslocamentoPorSegundo = incrementoPosicao / duracao;
		for(float t = 0f ; t < duracao ; t += Time.deltaTime) {
			portao.transform.Translate(deslocamentoPorSegundo * Time.deltaTime);
			yield return null;
		}
	}

	void OnTriggerEnter(Collider other) {
		StartCoroutine (LevantarPortao(new Vector3(6.0f, 0, 0), 2.0f));
	}
}

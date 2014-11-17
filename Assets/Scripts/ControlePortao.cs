using UnityEngine;
using System.Collections;

public class ControlePortao : MonoBehaviour {
	public GameObject portao;

	IEnumerator LevantarPortao() {
		for (float f = portao.transform.position.y; f < 6; f += 0.5f) {
			portao.transform.position = new Vector3(portao.transform.position.x, f, portao.transform.position.z);
			yield return new WaitForSeconds(0.2f);
		}
	}

	void OnTriggerEnter(Collider other) {
		StartCoroutine (LevantarPortao());
	}
}

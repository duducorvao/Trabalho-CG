using UnityEngine;
using System.Collections;

public class ControlePortao : MonoBehaviour {
	IEnumerator LevantarPortao() {
		Vector3 novaPosicao = transform.position;
		for (float f = transform.position.y; f < 6; f += 0.5f) {
			transform.position = new Vector3(transform.position.x, f, transform.position.z);
			yield return new WaitForSeconds(0.2f);
		}
	}

	void OnTriggerEnter(Collider other) {
		StartCoroutine (LevantarPortao());
	}
}

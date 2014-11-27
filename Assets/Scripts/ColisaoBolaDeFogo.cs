using UnityEngine;
using System.Collections;

public class ColisaoBolaDeFogo : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		//if (other.tag != "Cortina")
		Destroy (gameObject, 0.5f);
	}
}

using UnityEngine;
using System.Collections;

public class ColisaoBolaDeFogo : MonoBehaviour {
	void onTriggerEnter(Collider other) {
		Destroy (this);
	}
}

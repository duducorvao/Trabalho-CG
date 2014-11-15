using UnityEngine;
using System.Collections;

public class ControlePortao : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("iei");
		Debug.Log (other.tag);
		if (other.tag == "Jogador") {
			gameObject.SetActive(false);
				}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

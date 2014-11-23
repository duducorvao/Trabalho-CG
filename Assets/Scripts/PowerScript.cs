using UnityEngine;
using System.Collections;

public class PowerScript : MonoBehaviour {

	public GameObject powerCollider;
	public ParticleSystem efeito;
	public Light pointLight;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKey (KeyCode.LeftShift)) {
			
			efeito.Play ();
			pointLight.gameObject.SetActive(true);

		} else {

			efeito.Stop();
			pointLight.gameObject.SetActive(false);

		}

		if(efeito.isPlaying) {
			//pointLight.gameObject.SetActive(true);
			powerCollider.gameObject.SetActive(true);
		}else{
			pointLight.gameObject.SetActive(false);
			powerCollider.gameObject.SetActive(false);
		}

	}
}

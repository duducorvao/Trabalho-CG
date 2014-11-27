using UnityEngine;
using System.Collections;

public class triforceScript : MonoBehaviour {
	private bool found;

	// Use this for initialization
	void Start () {

		found = false;

	}
	
	// Update is called once per frame

	void Update(){

		if (found == true) {
			transform.Rotate(Vector3.back * 50f * Time.deltaTime, Space.Self);

			if(transform.position.y <= 2){
				transform.Translate(Vector3.up * (Time.deltaTime*0.10f), Space.World);

			}

		}



	}


	void FixedUpdate () {

		if (Input.GetKey (KeyCode.O)) {
			found = true;
		}

	}
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject enemy;
	public float speed;
	private float degrees = 0;
	private float velocityLimit = 45;
	
	void FixedUpdate(){
		
//		float moveHorizontal = Input.GetAxis ("Horizontal");
//		float moveVertical = Input.GetAxis ("Vertical");
//		
//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, (moveHorizontal/2));
//		
		if (Input.GetKey (KeyCode.A)) {

			if(degrees > velocityLimit){
				degrees = velocityLimit;
			}

			degrees = degrees + 1;
		}

		if (Input.GetKey (KeyCode.D)) {

			if(degrees < -velocityLimit){
				degrees = -velocityLimit;
			}

			degrees = degrees - 1;
		}

		transform.RotateAround (enemy.transform.position, Vector3.up, degrees * Time.deltaTime);

		//rigidbody.AddForce (movement * speed * Time.deltaTime);
		
	}
}

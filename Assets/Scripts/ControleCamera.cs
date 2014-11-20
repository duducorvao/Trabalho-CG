using UnityEngine;
using System.Collections;

public class ControleCamera : MonoBehaviour {
	void Update () {
		if (Input.GetButtonUp ("BotaoTipoProjecao")) {
			camera.orthographic = !camera.orthographic;
		}
	}
}

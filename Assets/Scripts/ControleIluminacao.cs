using UnityEngine;
using System.Collections;

public class ControleIluminacao : MonoBehaviour {
	public GameObject directional;
	public GameObject fill;
	public float intensidadeDirectional;
	public float intensidadeFill;
	
	void Start () {
		directional.light.intensity = 0;
		fill.light.intensity = 0;
	}

	public IEnumerator Fade(bool fadeIn, float duracao) {
		float intensidadePorSegundoDirectional = intensidadeDirectional / duracao;
		float intensidadePorSegundoFill = intensidadeFill / duracao;
		if (!fadeIn) {
				intensidadePorSegundoDirectional *= -1;
				intensidadePorSegundoFill *= -1;
		}
		for (float t = 0f; t < duracao; t += Time.deltaTime) {
				directional.light.intensity += intensidadePorSegundoDirectional * Time.deltaTime;
				fill.light.intensity += intensidadePorSegundoFill * Time.deltaTime;
				yield return null;
		}
	}
}

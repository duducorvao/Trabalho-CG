using UnityEngine;
using System.Collections;

public class ControleSom : MonoBehaviour {
	public static ControleSom instance;
	public AudioClip portaoAbrindo;
	public AudioClip portaoAberto;
	public AudioClip bauAbrindo;
	public AudioClip bauEfeito;
	public AudioClip dragaoMorrendo;
	public AudioClip dragaoEstrondo;
	public AudioClip aparecimentoDragao;
	public AudioClip dragaoVoando;

	void Start () {
		instance = this;
	}
	
	public static void tocarPortandoAbrindo() {
		instance.tocar(instance.portaoAbrindo);
	}
	public static void tocarPortandoAberto() {
		instance.tocar(instance.portaoAberto);
	}
	public static void tocarBauAbrindo() {
		instance.tocar(instance.bauAbrindo);
	}
	public static void tocarBauEfeito() {
		instance.tocar(instance.bauEfeito);
	}
	public static void tocarDragaoMorrendo() {
		instance.tocar(instance.dragaoMorrendo);
	}
	public static void tocarDragaoEstrondo() {
		instance.tocar(instance.dragaoEstrondo);
	}
	public static void tocarAparecimentoDragao() {
		instance.tocar(instance.aparecimentoDragao);
	}
	public static void tocarDragaoVoando() {
		instance.tocar(instance.dragaoVoando, true);
	}
	public static void parar (){
		instance.audio.Stop ();
	}

	void tocar(AudioClip clip) {
		tocar (clip, false);
	}
	void tocar(AudioClip clip, bool loop) {
		audio.loop = loop;
		audio.Stop ();
		audio.clip = clip;
		audio.Play ();
	}
}

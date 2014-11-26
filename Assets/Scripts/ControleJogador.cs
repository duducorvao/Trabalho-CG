using UnityEngine;
using System.Collections;

public class ControleJogador : MonoBehaviour {
	public Animator animator;
	public float velocidadeTranslacao;
	public float velocidadeRotacao;
	public GameObject powerCollider;
	public ParticleSystem efeito;
	public Light pointLight;
	public ControleDragao dragao;
	public bool atingiu;
	private bool dragaoMorrendo;
	private bool walk;
	private bool attack;
	private bool defend;

	void Start() {
		atingiu = false;
		dragaoMorrendo = false;
		AlterarEstados(0.0f, 0.0f);
	}

	void FixedUpdate(){
		float translacao = Input.GetAxis ("JogadorVertical") * velocidadeTranslacao;
		float rotacao    = Input.GetAxis ("JogadorHorizontal") * velocidadeRotacao;
		if (translacao < 0)
			translacao = 0;
		AlterarEstados (translacao, rotacao);
		if (walk)
			translacao /= 3.0f;

		animator.SetFloat ("Sprint", translacao);
		animator.SetBool ("Walk", walk);
		animator.SetBool ("Attack", attack);
		animator.SetBool ("Defend", defend);

		TratarPoder ();
		
		transform.Translate(0, 0, -translacao * Time.deltaTime);
		transform.Rotate(0, rotacao * Time.deltaTime, 0);
	}

	void AlterarEstados(float translacao, float rotacao) {
		// inicialmente, sem nenhum estado
		walk = false;
		attack = false;
		defend = false;

		// verifica se está andando
		if (translacao > 0) {
			// se andando, verifica se está com o modificador para andar/correr
			if (Input.GetButton("BotaoAndar"))
				walk = true;
		} else {
			// verifica se está atacando ou defendendo
			if (Input.GetButton("BotaoAtacar"))
				attack = true;
			else if (Input.GetButton("BotaoDefender"))
				defend = true;
		}
	}

	void TratarPoder() {
		if (!atingiu && defend) {
			efeito.Play ();
			pointLight.gameObject.SetActive(true);
			powerCollider.gameObject.SetActive(true);
		} else {
			efeito.Stop();
			pointLight.gameObject.SetActive(false);
			powerCollider.gameObject.SetActive(false);
			if (atingiu && !dragaoMorrendo) {
				StartCoroutine(dragao.AnimacaoMorte(Vector3.up * 720.0f, Vector3.one * 0.1f, 4.0f));
				dragaoMorrendo = true;
			}
		}
	}
}

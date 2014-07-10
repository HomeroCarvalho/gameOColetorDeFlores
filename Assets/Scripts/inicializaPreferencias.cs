using UnityEngine;
using System.Collections;

public class inicializaPreferencias : MonoBehaviour {

	// Use this for initialization
	void Start () {


		// Obtem a largura e cumprimento da tela recomendado pelo jogador em  [Opcoes].
		int width = PlayerPrefs.GetInt ("dimX", 800);
		int height = PlayerPrefs.GetInt ("dimY", 600);
		// Obtem se o jogador quer a tela do jogo como cheia ou em janela. Escolhido em [Opcoes].
		int full = PlayerPrefs.GetInt ("fullScreenOuNao", 1);
		bool fullScreen = false;
		if (full == 0)
			fullScreen = false;
		else
			fullScreen = true;
		// seta a resolucao do jogo, e se e' tela cheia ou em janela.
		Screen.SetResolution (width, height, fullScreen);

		// Obtem o nivel de dificuldade escolhido pelo jogador em [Opcoes].
		int dif = PlayerPrefs.GetInt ("nivelDificuldade", 1);
		switch (dif) {
				
		case 1: Jogador.difuldadeGlobalJogo=Jogador.DIFICULDADE.facil;
			break;
		case 2: Jogador.difuldadeGlobalJogo=Jogador.DIFICULDADE.medium;
			break;
		case 3: Jogador.difuldadeGlobalJogo=Jogador.DIFICULDADE.dificil;
			break;
		default: Jogador.difuldadeGlobalJogo=Jogador.DIFICULDADE.facil;
			break;
		
		}


		// Obtem se o jogador quer musica tocando durante o jogo, ou nao. Escolhido em [Opcoes].
		int mus = PlayerPrefs.GetInt ("musicaOuNao", 1);
		if (mus == 0)
			Jogador.musicaOuNao = false;
		else
			Jogador.musicaOuNao = true;


	} // Start()
	

}

using UnityEngine;
using System.Collections;

public class MenuOpcoes : MonoBehaviour {
	int dimX;
	int dimY;
	int nivelDificuldade;
	bool musicaOuNao;
	bool fullscreenOuNao;

	/// <summary>
	/// seta valores default.
	/// </summary>
	void Start () {
		dimX = 800;
		dimY = 600;
		nivelDificuldade = 1;
		musicaOuNao = true;
		fullscreenOuNao = false;
	}

	void OnGUI()
	{
		int top = 200;
		GUI.Label (new Rect (0, 0+top, 150, 23), "Largura da Tela do Jogo");
		dimX = (int)(GUI.HorizontalSlider (new Rect (200, 0+top, 300, 23), dimX, 800.0F, 1024.0F));

		GUI.Label (new Rect (0, 69+top, 150, 23), "Cumprimento da Tela do Jogo");
		dimY = (int)(GUI.HorizontalSlider (new Rect (200, 46+top, 300, 23),dimY, 600.0F, 768.0F));

		GUI.Label (new Rect (0, 4 * 23+top, 150, 23), "Dificuldade do Jogo (de 1 a 3)");
		nivelDificuldade = (int)(GUI.HorizontalSlider (new Rect (200, 3*23+top, 100, 23), nivelDificuldade, 1.0F, 3.0F));


		string txtMusicaOuNao = "Music on/off";
		musicaOuNao = (GUI.Toggle (new Rect (200, 5*23 + top, 23 * txtMusicaOuNao.Length, 23),
		               musicaOuNao, txtMusicaOuNao));
		int mus = 0;
		if (musicaOuNao)
			mus = 1;
		else
			mus = 0;
		string txtFullScreenOuNao = "Full Screen On/Off";
		fullscreenOuNao = (GUI.Toggle(new Rect (200, 6*23+top, 23 * txtFullScreenOuNao.Length, 23),
		                                                      fullscreenOuNao, txtFullScreenOuNao));

		int full = 0;
		if (fullscreenOuNao)
			full = 0;
		else
			full = 1;
		string txtBotaoVoltar = "Back";
     	if (GUI.Button (new Rect (200, 9*23+top, 23 * txtBotaoVoltar.Length, 23), "Back")) 
		{
			Application.LoadLevel("cenaEntrada");
		}

		PlayerPrefs.SetInt ("dimX", dimX);
		PlayerPrefs.SetInt ("dimY", dimY);
		PlayerPrefs.SetInt ("NivelDificuldade", nivelDificuldade);
		PlayerPrefs.SetInt ("musicaOuNao", mus);
		PlayerPrefs.SetInt ("fullscreenOuNao", full);
		PlayerPrefs.Save ();

	} // OnGUI()


} // class MenuOpcoes

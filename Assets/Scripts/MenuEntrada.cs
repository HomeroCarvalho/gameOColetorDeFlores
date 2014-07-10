using UnityEngine;
using System.Collections;

public class MenuEntrada : MonoBehaviour {

	// <summary>
	/// The tamanho letra na tela da internet
	/// </summary>
	private float tamanhoLetra=23.0f;
	
	/// <summary>
	/// The espaco entre as letras,da altura da linha anterior ate a altura da linha currente.
	/// </summary>
	private float espacoLetra;
	

	private float topo;
	private float esquerda;
	private float bottom;
	private float direita;


	private GUIContent gcnt;
	private GUIStyle gStly;
	TextAsset textureMenu;

	void OnGUI()
	{
		
		espacoLetra = this.tamanhoLetra + 3.0f;		
		
		esquerda = 200.0F;
		topo = 0.0F;
		bottom = (float)(Screen.height);
		direita = (float)(Screen.width);

	

		GUI.Box(new Rect(esquerda+1,topo+1,(direita-esquerda)-1,bottom-topo-1),"O COLETOR DE FLORES");

		int linha=5;
		GUI.depth += 1;
		string txtBotaoJogar = "PLAY NOW";	
		        // desenha o botao de jogar".
		        if (GUI.Button (new Rect (esquerda + 150.0f, topo + linha * espacoLetra,
		                          200.0F, tamanhoLetra),
		                txtBotaoJogar))
				{
					Application.LoadLevel("cenaJogo");
				} // if GUI.Button
		linha+=2;
		string txtBotaoCreditos="CREDITS";
			if (GUI.Button (new Rect(esquerda + 150.0f, topo + linha * espacoLetra,
		                          200.0F, tamanhoLetra),
							txtBotaoCreditos))
				{
				
				Application.LoadLevel("cenaCreditos");
				} // if
		linha += 2;
		string txtBotaoOpcoes="OPTIONS";
		if (GUI.Button (new Rect(esquerda + 150.0f, topo + linha * espacoLetra,
		                          200.0F, tamanhoLetra),
							txtBotaoOpcoes))
				{
		
				Application.LoadLevel("cenaOpcoes");
					// COLOCAR A CENA DE OPCOES AQUI (DIMENSOES TELA DO JOGO, DIFICULDADE, MUSICA OU NAO.
				}
		linha += 2;
		string txtBotaoSaida="QUIT";
		if (GUI.Button (new Rect(esquerda + 150.0f, topo + linha * espacoLetra,
		                          200.0F, tamanhoLetra),
						txtBotaoSaida))
		{
			Application.Quit();
		}
					

	} // void OnGUI

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

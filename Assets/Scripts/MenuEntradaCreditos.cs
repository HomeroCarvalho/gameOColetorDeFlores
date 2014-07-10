using UnityEngine;
using System.Collections;

public class MenuEntradaCreditos : MonoBehaviour {
	// <summary>
	/// The tamanho letra na tela da creditos
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

	// Use this for initialization
	void Start ()
	{
	
	} // void Start

	void OnGUI()
	{	
		espacoLetra = this.tamanhoLetra + 3.0f;		
		esquerda = 200.0F;
		topo = 0.0F;
		bottom = (float)(Screen.height);
		direita = (float)(Screen.width);
		GUI.Box(new Rect(0,topo+1,(direita-esquerda)-1,bottom-topo-1),"O COLETOR DE FLORES");
		
		int linha=5;
		GUI.depth += 1;
		string txtNomeJogo = "O COLETOR DE FLORES";
		// desenha o label autor1.
		GUI.Label (new Rect (esquerda + 10.0f, topo + linha * espacoLetra,
		                         20.0F * tamanhoLetra, tamanhoLetra),
		           txtNomeJogo);
		linha += 2;
		string txtAutor1 = "Autor: Homero T. Carvalho";
		// desenha o label autor1.
		GUI.Label (new Rect (esquerda + 10.0f, topo + linha * espacoLetra,
		                          20.0F * tamanhoLetra, tamanhoLetra),
		              txtAutor1);
		linha += 2;
		string txtAutor2 = "Estudante Senac - DF";
		// desenha o label autor2.
		GUI.Label (new Rect (esquerda + 10.0f, topo + linha * espacoLetra,
		                         20.0F * tamanhoLetra, tamanhoLetra),
		              txtAutor2);
		linha += 2;
		// desenha o label curso
		string txtCurso="Curso: Programaçao de Jogos Digitais - EAD";
		GUI.Label (new Rect (esquerda + 10.0f, topo + linha * espacoLetra,
			                         20.0F * tamanhoLetra, tamanhoLetra),
		           txtCurso);
		linha += 2;
		// desenha o label ano
		string txtAno= "Julho/Agosto de 2014";
		GUI.Label (new Rect (esquerda + 10.0f, topo + linha * espacoLetra,
		                         20.0F * tamanhoLetra, tamanhoLetra),
		           txtAno);
		linha+=3;
		// desenha o botao de voltar ao menu inicial.
		string txtBotaoVolta = "Back";
		if (GUI.Button (new Rect (esquerda + 10.0f, topo + linha * espacoLetra,
		                         20.0F * tamanhoLetra, tamanhoLetra),
		               txtBotaoVolta))
			{
				Application.LoadLevel("cenaEntrada");
			}

	} // void OnGUI()

	// Update is called once per frame
	void Update () {
	
	} // void Update()
}

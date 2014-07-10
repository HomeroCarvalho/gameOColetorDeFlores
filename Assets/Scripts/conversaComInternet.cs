using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;



/// <summary>
/// Conversa COM internet. 
/// </summary>
public class conversaComInternet : MonoBehaviour {

	public GUISkin minhaSkin;

	public int nivelAtual=0;
	

	
	public string umaSaudacao;
	
	/// <summary>
	/// Contem todas missoes para um nivel.
	/// </summary>
	public umaMissao missaoumNivel;



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



	void OnGUI()
	{
				this.nivelAtual = Jogador.nivelAtualGlobalJogador;
				this.missaoumNivel = new umaMissao ();
				GerenciamentoDeNiveis gg = new GerenciamentoDeNiveis ();
				this.missaoumNivel = gg.RelacaoDeMissoes () [this.nivelAtual];	

						

				espacoLetra = this.tamanhoLetra + 3.0f;		
		
				esquerda = 0.0F;
				topo = 0.0F;
				bottom = (float)(Screen.height);
				direita = (float)(Screen.width);
		

		
	
		
		
				GUI.Box (new Rect (esquerda, topo, direita, bottom), "MISSOES DISPONIVEIS");
		
		
				GUI.depth += 1;
				int linha = 1;	
				string frase = "";
			
			
				for (int saudacoes=0; saudacoes<missaoumNivel.Saudacao.Length; saudacoes++) {
						frase = missaoumNivel.Saudacao [saudacoes];
						GUI.Label(new Rect (esquerda + 10.0f, topo + linha * espacoLetra, frase.Length * tamanhoLetra, tamanhoLetra), frase);
						linha += 1;
				} // for int saudacoes
				linha += 1;
				for (int metas=0; metas<missaoumNivel.metas.Length; metas++) {
						frase = missaoumNivel.metas [metas];
						GUI.Label (new Rect (esquerda + 10.0f, topo + linha * espacoLetra, frase.Length * tamanhoLetra, tamanhoLetra), frase);
						linha += 1;
				} // for int metas
				linha += 1;
				for (int observacoes=0; observacoes<missaoumNivel.notas.Length; observacoes++) {
						frase = missaoumNivel.notas [observacoes];
						GUI.Label (new Rect (esquerda + 10.0f, topo + linha * espacoLetra, frase.Length * tamanhoLetra, tamanhoLetra), frase);
						linha += 1;
				}
				linha += 1;
			
				GUI.depth += 1;
				string txtBotaoAceitar = " ACEITA A MISSAO? ";	
				// desenha o botao de aceitar cada missao de um nivel.
				if (GUI.Button (new Rect (esquerda + 10.0f, topo + linha * espacoLetra,
			                         20.0F * tamanhoLetra, tamanhoLetra),
			                txtBotaoAceitar)) {
						CriadorDeItensParaNiveis.criarItens = true;
						// passa a missao para mostrar no HUD.
						HUD.msgParaJogador="VOCE ACABOU DE RECEBER UMA MISSAO";
					
						Application.LoadLevel("cenaJogo");
				} // if GUI.Button
			
				string txtBotaoNaoAceitar = " NAO,AGORA NAO. ";
				linha += 1;
				// desenha o botao de nao aceitar a missao.
				if (GUI.Button (new Rect (esquerda + 10.0f, topo + linha * espacoLetra,
			                         20.0F * tamanhoLetra, tamanhoLetra),
			                txtBotaoNaoAceitar))
				{
					Application.LoadLevel("cenaJogo");		
				} // if GUI.Button
			
		} // OnGUI
	
			
	
}// class HUD


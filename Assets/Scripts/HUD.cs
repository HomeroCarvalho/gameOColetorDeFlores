using UnityEngine;
using System.Collections.Generic;

public class HUD : MonoBehaviour {

	public static int life;
	public static int score = 0;
	public static float money=0.0F;
	public static string msgParaJogador="";



	float hudWidth;
	float hudHeight;
	
	float percentagemAlturaHUD=0.25F;	
	float percentagemLarguraHUD=1.0F;
	
	string pontosDeVida="VIDAS: ";
	string pontuacao="PONTUAÇAO: ";
	string dinheiro="CASH: $";

	
	float espacamentoEntreTextos=23.0F; // espacamentoEntreTextos= tamanhoFont + 3.0F
	private int Topo;
	private int Esquerda;
	private GUIStyle g;
	public static bool mostraInventario=false;
	
		
			
				
	void OnGUI()
	{

				hudWidth = (this.percentagemLarguraHUD / 1.0F) * Screen.width;
				hudHeight = (1.0F - this.percentagemAlturaHUD / 1.0f) * Screen.height;
		
				Esquerda = (int)(0.1f * hudWidth);
				Topo = (int)hudHeight;
				g = new GUIStyle ();
				g.fontSize = 20;
				
				// Box do HUD
				GUI.Box (new Rect (0.0F, Topo, Screen.width, Screen.height), "");
	
				float posY = Topo + 5.0F;
			
				GUIContent gctnt = new GUIContent ();
					
		        gctnt.text = pontuacao + score.ToString ();
				// Box pontuacao
				GUI.TextField (new Rect (Esquerda, posY,
		                          g.CalcSize(gctnt).x,
		                          g.CalcSize(gctnt).y), gctnt.text);

				posY += this.espacamentoEntreTextos;

		        gctnt.text = dinheiro + money.ToString ();
				// Text dinheiro
				GUI.TextField (new Rect (Esquerda, posY,
		                          g.CalcSize(gctnt).x,
		                          g.CalcSize(gctnt).y), gctnt.text );

				posY += this.espacamentoEntreTextos;

			    gctnt.text = pontosDeVida + life.ToString ();
				// Text pontos de vida
				GUI.TextField (new Rect (Esquerda, posY,
		                         g.CalcSize (gctnt).x,
		                         g.CalcSize (gctnt).y), gctnt.text);
		
				posY += this.espacamentoEntreTextos;

				gctnt.text = msgParaJogador;
				GUI.TextField (new Rect (Esquerda, posY,
		                       g.CalcSize(gctnt).x,
		                       g.CalcSize(gctnt).y), msgParaJogador);

				

				if (mostraInventario) {
						GerenciamentoDeNiveis gn = new GerenciamentoDeNiveis ();
						umaMissao mm = gn.RelacaoDeMissoes () [Jogador.nivelAtualGlobalJogador];

						Vector2 vtScrollView = Vector2.zero;
						
						string txtMetas = "";
			
						float posX = Esquerda + 350.0F;

						posY = Topo + 5.0F;

     					vtScrollView = GUI.BeginScrollView (new Rect (posX, posY, 300.0F, 6.0F *g.CalcSize(gctnt).y), 
			                                    vtScrollView,
			                                    new Rect (posX, posY, 500.0F, 10.0F * g.CalcSize(gctnt).y));

						txtMetas = "METAS: " + '\n';
						if (planta.mapaNomesPlantas != null) {
								foreach (itemMeta meta in mm.tags_missao) 
										txtMetas += meta.quant + " da planta " + 
												planta.mapaNomesPlantas [meta.nomeDoObjeto] + '\n';
								gctnt.text=txtMetas;
								GUI.TextArea (new Rect (
								posX,
		                        posY,
		                        500,
								10.0F * g.CalcSize(gctnt).y), txtMetas);
						}
						GUI.EndScrollView (true);
						
				} // if CriadorDeItensParaNiveis.itensFeitos
	
		} // void OnGUI()


	void Start()
	{
		life = 300;
	}
	

	
} // class HUD

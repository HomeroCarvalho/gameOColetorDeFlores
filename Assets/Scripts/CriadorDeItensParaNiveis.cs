using UnityEngine;
using System.Collections.Generic;

public class CriadorDeItensParaNiveis:MonoBehaviour
{
	
	
    public static Jogador.DIFICULDADE dificuldadeDoJogo;		
	public static bool itensFeitos=false;
	int nivelInterno=0;
	public static List<GameObject> ItensPlantados;
	float raioDePlantacao;
	public static bool criarItens = false;
	int valueFacilidade=1;		


    void OnGUI()
	{   

		if (criarItens) {
						Jogador.DIFICULDADE dificuldadeDoJogo = Jogador.difuldadeGlobalJogo;			
						
						nivelInterno = Jogador.nivelAtualGlobalJogador;
		
						itensFeitos = false;
		
		
						raioDePlantacao = 1.0F;
						ItensPlantados = new List<GameObject> ();
						raioDePlantacao = ((float)dificuldadeDoJogo) * (50 + 5 * nivelInterno) * (Random.value * 10.0F);
						valueFacilidade = 0;
						if (dificuldadeDoJogo == Jogador.DIFICULDADE.facil)
								valueFacilidade = 5;
		
						if (dificuldadeDoJogo == Jogador.DIFICULDADE.medium)	     
								valueFacilidade = 4;
						if (dificuldadeDoJogo == Jogador.DIFICULDADE.dificil)
								valueFacilidade = 3;
				
									
						
						float x, y, z;	
						if (nivelInterno >= 0) {
								GerenciamentoDeNiveis gn = new GerenciamentoDeNiveis ();
								umaMissao mm = gn.RelacaoDeMissoes () [nivelInterno];
								for (int item=0; item<mm.tags_missao.Length; item++) {
										int r = (int.Parse (mm.tags_missao [item].quant)) * 2 + valueFacilidade;
										for (int n=0; n<r; n++) {
												x = GameObject.Find ("Mercado").transform.position.x + Random.value * raioDePlantacao;
												y = 0.0F;
												z = GameObject.Find ("Mercado").transform.position.z + Random.value * raioDePlantacao;
	       	   	
												GameObject objplnt = (GameObject)Instantiate ((
							                            Object)GameObject.Find (mm.tags_missao [item].nomeDoObjeto),
						                                new Vector3 (x, y, z), Quaternion.identity);

												//HUD.mission=GameObject.Find(mm.tags_missao[item].nomeDoObjeto).name;
								
												// chama o algoritmo que corrige a posiçao do jogador conforme o nivel (altura) do terreno.
												adaptacaoAoTerreno (objplnt);
												
												// soma o item para a lista de objetos planta.
												ItensPlantados.Add (objplnt);
										} // for n
								}  
						
						} // if nivelInterno>=0
						criarItens = false;				
						HUD.mostraInventario=true;
				} // if criarItens

	} // OnGUI
	static void adaptacaoAoTerreno(GameObject obj)
	{
		RaycastHit colisor;
		bool colisaoAcima =Physics.Raycast(obj.transform.position,Vector3.up,out colisor);
		bool colisaoAbaixo=Physics.Raycast(obj.transform.position,-Vector3.up,out colisor);
		if ((colisaoAcima) || (colisaoAbaixo))
		{
			obj.transform.position=new Vector3(obj.transform.position.x,colisor.point.y,obj.transform.position.z);
		} // if	
		
	} // void adaptacaoAoTerreno()

} // CriadoresDEPlantasParaNiveis

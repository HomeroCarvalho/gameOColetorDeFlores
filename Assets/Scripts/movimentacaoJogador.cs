using UnityEngine;
using System.Collections.Generic;
using System;
// TECLA H: HELP. TORNA VISIVEL A BUSSOLA 

public class movimentacaoJogador : MonoBehaviour {


	public static Vector3 posicaoJogador;

	public Font fonteTextos;
	//__________________________________________________________________________
	// nivel atual do jogador (começa no 0)
	public static int nivelAtualGlobalJogador=0;


	// numero de dificiculdade do jogo: influencia na plantacao de plantas e colocaçao de demais objtetos	
	
	public enum DIFICULDADE{facil=1,medium=2, dificil=3};	
	
	/// <summary>
	/// difuldade global, setado para o valor default ("facil").
	/// </summary>
	public static DIFICULDADE difuldadeGlobalJogo=DIFICULDADE.facil;
	
	
	//__________________________________________________________________________
	/// VARIAVEIS GLOBAIS
	
	// numero maximo de niveis no jogo inteiro
	public static int maxNiveisGlobal=1;

	
	//__________________________________________________________________________________
	/// <summary>
	/// as missoes para o nivel atual do jogador. disponivel para consultas.
	/// </summary>
	public static List<umaMissao> missoesDoNivel;
	//________________________________________________________________________________	
	
	
	public static  bool	completouMissao=false;
	
		
	//__________________________________________________________________________________			
	public enum movimentacao{ andar, andaLado, rotacionarCorpo, rotacionarCabeca,
		parado, nada,colisaoEntrar, colisaoSair, colidiuComPlanta};
	
	// olhos do jogador
	public Camera cameraOlhar;
	

	public bool descontarVida;


	float constanteAndar=15.0F;
	float constanteRotacaoCorpo=40.0F;
	float fatorRepelente=5.0F;
	
	
	
	float velocidadeTotal;

	// ultimo movimento do jogador
	public static movimentacao movimentoAtual;




	void OnTriggerEnter(Collider outro)
	{
		//compara se o jogador colidiu com uma planta
			movimentoAtual=movimentacao.colisaoEntrar;
			descontarVida=false;		

		if (outro.CompareTag("Mercado"))
		{
		    movimentoAtual=movimentacao.colisaoEntrar;
			if (completouMissao)
			{
				
				GerenciamentoDeNiveis gv= new GerenciamentoDeNiveis();
				umaMissao onemission=gv.RelacaoDeMissoes()[nivelAtualGlobalJogador];
				HUD.msgParaJogador="VOCE ACABOU DE RECEBER UMA RECOMPENSA";
				float cash=0.0F;
				for (int mis=0; mis<onemission.tags_missao.Length; mis++)
				{
					cash+=float.Parse (onemission.tags_missao[mis].cash);
				}
				
				HUD.money+=cash;
    			completouMissao=false;
        				
			}
			
		}
		if (outro.CompareTag("Internet"))
		{
			movimentoAtual=movimentacao.colisaoEntrar;
			// muda para a cena de apresentaçao de niveis na Internet..	
			Application.LoadLevel("cenaInternet");

			
		}

	} // OnTriggerEnter()
	
	
	void OnTriggerExit(Collider outro)
	{
		if (outro.CompareTag ("Mercado"))
		{
			
		   movimentoAtual= movimentacao.colisaoSair;
		}
		if (outro.CompareTag ("Internet")) {
		
		    // tenta sair do computador da internet	
	    	movimentoAtual = movimentacao.colisaoSair;
			}
		if (outro.CompareTag("Flor"))
	{
			movimentoAtual=movimentacao.colisaoSair;		
		}			
		
	}	
		
	void Start ()
	{
		movimentacaoJogador.maxNiveisGlobal=1;
		// atualiza a posicao da camera para a posicao do jogador.
		float xx = this.transform.position.x;
		float yy = this.transform.position.y + 1.0F;
 		float zz = this.transform.position.z;
 		posicaoJogador= new Vector3(xx,yy,zz);
		this.cameraOlhar.transform.position = new Vector3(xx,yy,zz);
		//_______________________________________________________________
		// velocidade de rotacao da camera na cabeca (olhos) e velocidade total de andar.
		this.velocidadeTotal = constanteAndar;
		//_______________________________________________________________

		movimentoAtual = movimentacao.parado;
	
		//_______________________________________________________________
		// inicializa o nivel do jogador;
		GerenciamentoDeNiveis gg = new GerenciamentoDeNiveis ();
		missoesDoNivel = gg.RelacaoDeMissoes ();

	}


	void Update () 
	{


		// atualiza a posicao da camera para a posicao do jogador.
		float xx = this.transform.position.x;
		float yy = this.transform.position.y+1.0F;
		float zz = this.transform.position.z;
		this.cameraOlhar.transform.position = new Vector3(xx,yy,zz);
		posicaoJogador= new Vector3(xx,yy,zz);
			
		float sinalDirecaoAndarCorpo = 1.0F;
		
		
		// cuidado ao adaptar o terreno numa situaçao de colisao.
		if (!this.adaptacaoAoTerreno())
			this.transform.position= new Vector3(xx,0.0F,zz);
						
			// torna visivel/ indivisivel a bussola.
			if (Input.GetKey(KeyCode.H))
			{
				if (!bussola.bussolaVisivel)
					bussola.bussolaVisivel=true;
				else
					bussola.bussolaVisivel=false;
			}						
			if (Input.GetKey (KeyCode.UpArrow))
			{
				if (movimentoAtual.Equals (movimentacao.colisaoEntrar))
				sinalDirecaoAndarCorpo=(-1.0f)*fatorRepelente;
				else
					sinalDirecaoAndarCorpo=(+1.0f);
				movimentoAtual = movimentacao.andar;
			}
			if 	(Input.GetKey (KeyCode.DownArrow))
			{
				if (movimentoAtual.Equals (movimentacao.colisaoEntrar))
					sinalDirecaoAndarCorpo=(+1.0f)*fatorRepelente;
				else
					sinalDirecaoAndarCorpo=(-1.0f);
				movimentoAtual = movimentacao.andar;
								
			}
			float omega=0.0F;
			if((Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.LeftArrow)))
			{
				if (movimentoAtual.Equals (movimentacao.colisaoEntrar))
				omega=-this.constanteRotacaoCorpo*Time.deltaTime*fatorRepelente;
					else
				omega=this.constanteRotacaoCorpo*Time.deltaTime;
				if ((omega>90.0F) || (omega<-90))
					omega=-this.fatorRepelente*omega;
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{	
				transform.Rotate(new Vector3(0.0F,1.0F,0.0F),omega);
				movimentoAtual= movimentacao.nada;
			} // if
			if (Input.GetKey(KeyCode.LeftArrow))
     		{
				transform.Rotate(new Vector3(0.0F,1.0F,0.0F),-omega);
				movimentoAtual=movimentacao.nada;
			}
						
		  	if ((movimentoAtual==movimentacao.andar) || (movimentoAtual==movimentacao.andaLado))
		  	
			{
				float vx=0.0f;
				float vz=0.0f;
				// velocidade de andar.
				float v=sinalDirecaoAndarCorpo*this.velocidadeTotal*Time.deltaTime;
			
				if (movimentoAtual==movimentacao.andaLado)
				{
			  		vx=v;
			  		vz=0.0f;
			  
				}
				if (movimentoAtual== movimentacao.andar)
				{
			  		vx=0.0f;
			  		vz=v;
				}
			
			transform.Translate(vx,0.0F,vz);
			
			movimentoAtual=movimentacao.nada;
		    } //		
	} // Update()
	
	/// <summary>
	/// acompanha o terreno se ha colisao com o terreno ( o terreno esta com y=(-0.1)
	/// </summary>
	bool adaptacaoAoTerreno()
	{
		RaycastHit colisor;
		bool colisaoAcima =Physics.Raycast(transform.position,Vector3.up,out colisor);
		bool colisaoAbaixo=Physics.Raycast(transform.position,-Vector3.up,out colisor);
		if ((colisaoAcima) || (colisaoAbaixo))
		{
			transform.position=new Vector3(transform.position.x,colisor.point.y,transform.position.z);
			return true;
		}
		return false;
	} // void adaptacaoAoTerreno()
	
	
} // class
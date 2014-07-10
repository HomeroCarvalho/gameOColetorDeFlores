using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class planta: MonoBehaviour
{
	public string nome;
	public static Dictionary<string,string> mapaNomesPlantas;  
	private GameObject flecha;	
	// inicializa o objeto planta: o prefab da imagem da planta e' a raiz do objeto.
	// falta criar e inicilizar a flecha indicadora;
	void Start () {

		if (mapaNomesPlantas == null)
			mapaNomesPlantas = new Dictionary<string, string> ();

		string strTry = null;
		if (!mapaNomesPlantas.TryGetValue (this.name, out strTry))
						mapaNomesPlantas.Add (this.name, this.nome);


		flecha = (GameObject)Instantiate ((Object)GameObject.Find ("objetoFlecha"),
		                               new Vector3 (this.transform.position.x,
		                                            this.transform.position.y + 5.0F,
		                                            this.transform.position.z),
		                               Quaternion.Euler (180.0F, 0.0F, 0.0F));

		float indicePlantasVenesoas = Random.value * 10.0F;
		if (indicePlantasVenesoas < 3.0F)
						flecha.renderer.material.color = Color.red;
				else
						flecha.renderer.material.color = Color.blue;
	
	}


	void OnTriggerEnter(Collider outro)
	{
		if (outro.gameObject.tag.Equals ("Player"))
		{
			if (flecha.renderer.material.color.Equals(Color.red))
			{
             // colocar o som de jogador ferido, aqui.  
			System.Random aleatorizador= new System.Random();
			HUD.life-= aleatorizador.Next(20);
			if (HUD.life<0)
				{
					// GAME OVER! Salva o score e passa para a tela de finalizacao..
					PlayerPrefs.SetInt("score",HUD.score);
					Application.LoadLevel("cenaGameOver");
				} // if HUD.life
			}
			
			GerenciamentoDeNiveis gn = new GerenciamentoDeNiveis();
			umaMissao onemission1=gn.RelacaoDeMissoes()[Jogador.nivelAtualGlobalJogador];

			for (int item=0;item<onemission1.tags_missao.Length; item++)
			{
				if (this.name.Equals(onemission1.tags_missao[item].nomeDoObjeto+"(Clone)"))
				{
					// colocar o som de coletar um item aqui.

					int q= int.Parse (onemission1.tags_missao[item].quant);
					q--;
					onemission1.tags_missao[item].quant=q.ToString();

					Jogador.completouMissao=true;
					// tem que completar todas as metas, senao [completouMissao=false]
					for (int index=0; index<onemission1.tags_missao.Length; index++)
					{
						if (q>0)
						{
						 Jogador.completouMissao=false;	
						 
						} // if int.Parse
					} // for int index
					if (Jogador.completouMissao)
					{
						// colocar a musica de nivel cumprido, aqui
						
						HUD.msgParaJogador="VOCE COMPLETOU A MISSAO! VOLTE AO MERCADO";
						HUD.mostraInventario=false;
						Jogador.completouMissao=true;
						// ATUALIZA O NIVEL PARA +1
						Jogador.nivelAtualGlobalJogador+=1;
						bussola.bussolaVisivel=false;
					} // if completouMissao
					
				} //if nomeFlor
			} // for item


			Jogador.movimentoAtual= Jogador.movimentacao.colidiuComPlanta;
			Destroy ((Object)this.flecha);
			Destroy ((Object)this);
     	} // if outro.gameObject

	}
	// Update is called once per frame
	void Update () {
	
	
	}

}

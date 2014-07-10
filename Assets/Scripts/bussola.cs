using UnityEngine;
using System.Collections;
// este script deve ficar vinculado ao objeto que representa a bussola no jogo, dentro da Hierarquia.	
// a bussola orienta o jogador para quando os itens que tem que colher estao fora do alcance visivel
public class bussola : MonoBehaviour {

	// posicao do jogador dentro do script, importado de uma variavel global
	Vector3 posjgdr;
	
	// torna visivel/invisivel a bussola.
	public static bool bussolaVisivel;
	void Start ()
	 {
	  bussolaVisivel=false;
	 }
	
	// Update is called once per frame
	void Update () {

	
	if (bussolaVisivel)
	{		
	float xMedia=0.0F;
	float yMedia=0.0F;
	float zMedia=0.0F;
	if (CriadorDeItensParaNiveis.ItensPlantados!=null)
	{
		for (int index=0; index<CriadorDeItensParaNiveis.ItensPlantados.Count; index++)
		{
		xMedia+=CriadorDeItensParaNiveis.ItensPlantados[index].transform.position.x;
		yMedia+=CriadorDeItensParaNiveis.ItensPlantados[index].transform.position.y;
		zMedia+=CriadorDeItensParaNiveis.ItensPlantados[index].transform.position.z;
		}
		float raio=Mathf.Sqrt (xMedia*xMedia+yMedia*yMedia+zMedia*zMedia);
		if (((int)raio)!=0)
		{
		posjgdr=new Vector3(Jogador.posicaoJogador.x,
		                    Jogador.posicaoJogador.y,
		                    Jogador.posicaoJogador.z);
		xMedia=xMedia/raio;
		yMedia=yMedia/raio;
		zMedia=zMedia/raio;
		Vector3 direcaoBussola=new Vector3(xMedia,yMedia,zMedia);
		direcaoBussola.Normalize();
		float size=10.0F;
		
		// faz a posicao da seta da bussola apontar logo em frente ao jogador
		transform.position=new Vector3(posjgdr.x+direcaoBussola.x*size,
		                               posjgdr.y+direcaoBussola.y*size,
		                               posjgdr.z+direcaoBussola.z*size);
		adaptacaoAoTerreno();
		} // if raio!=0;
	} // if CriadorDeItensParaNiveis.ItensPlantados!=null	
  } // if bussola visivel	
}// Upadate()

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
	
} // class bussola

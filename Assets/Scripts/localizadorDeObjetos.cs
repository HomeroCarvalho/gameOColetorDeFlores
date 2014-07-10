using UnityEngine;
using System.Collections.Generic;

public class localizadorDeObjetos : MonoBehaviour
{
	
		public Object  flecha;
		List<Transform> PositionInicial;
		List<GameObject> flechas;
						
		void Start ()
		{
		
				this.flechas = new List<GameObject> ();
				this.PositionInicial = new List<Transform> ();
		}
	
		void Update ()
		{
				RaycastHit[] hits;
				hits = Physics.RaycastAll (transform.position, transform.forward, 1000.00F);
				int i = 0;
				while (i<hits.Length) {
						RaycastHit hit = hits [i];
						Renderer renderizador = hit.collider.renderer;
						if (renderizador) {
								if ((renderizador.transform.tag.Equals ("Flor")) && (!jaMarcadaComFlecha (renderizador))) { 	
										Vector3 posicao = new Vector3(renderizador.transform.position.x,
										renderizador.transform.position.y,renderizador.transform.position.z);
																												
										// marca a posicao ininicial da flor
										this.PositionInicial.Add(renderizador.transform);
										// gera a flecha; posicao.y e para ficar acima da flor.
										posicao.y += 1.25F;
										Object fflecha = Instantiate (flecha, posicao, renderizador.transform.rotation);
										GameObject gobjFlech= new GameObject();
										gobjFlech = (GameObject)fflecha;
						     			this.flechas.Add (gobjFlech);				
							
								} // if tag==Flor
						} // if renderizador
						i++;
				} // while
				if (hits.Length == 0) {
						this.flechas.Clear ();
				} // if hits.Length==0
	
		} // update
		bool jaMarcadaComFlecha (Renderer renderizador)
		{
				bool res = false;
				for (int i=0; i< flechas.Count-1; i++) {
						if (this.PositionInicial[i].position.Equals((Vector3)(renderizador.transform.position))) {
								res = true;
								break; 
						}
    	
				} // for int i
				return res;	
		} // jaMarcadaComFlecha()
} // class localizadorDeObjetos
			    


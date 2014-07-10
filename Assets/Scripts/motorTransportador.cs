using UnityEngine;
using System.Collections;

public class motorTransportador : MonoBehaviour {

	
	public enum controleNaveCargueira{ ATERRIZAR=1, ENTRAR_EM_ORBITA=2, REPOUSAR=3};

	public static controleNaveCargueira controleNave;
	

	public float posicaoDeOrbita=500.0F;


	float velocidadeDeDescida;
	float velocidadeDeSubida;
	// Use this for initialization
	void Start () {


		GameObject mercado = GameObject.Find ("Mercado");	

		this.transform.position = new Vector3 (mercado.transform.position.x + 10.0F, 
		                                       mercado.transform.position.y + 10.0F,
		                                       mercado.transform.position.z + 10.0F);
		velocidadeDeDescida = -3.5F;
		velocidadeDeSubida = 3.5F;
		controleNave = controleNaveCargueira.ATERRIZAR;
	
	} // void Start()
	
	// Update is called once per frame
	void Update () {
	
		if (controleNave.Equals(controleNaveCargueira.ATERRIZAR))
		    {
			   float y=(velocidadeDeDescida)* Time.deltaTime;
			   if (y>=0)
			   {
			     this.transform.Translate(new Vector3(0.0F,y,0.0F));
			   }	
			   if (y<=0)
			   {
				controleNave=controleNaveCargueira.REPOUSAR;
			   }
		   } // if aterrizar
		if (controleNave.Equals(controleNaveCargueira.ENTRAR_EM_ORBITA))
		    {
						//Time.timeScale=0.5F;
				float y=(velocidadeDeSubida)*Time.deltaTime;		
				if (y<posicaoDeOrbita)
					{
					this.transform.Translate(new Vector3(0.0F,y,0.0F));
					//Time.timeScale+=1/velocidadeDeSubida;						
     				}
				if (y>posicaoDeOrbita)	
					{
					// parte do planeta
					this.transform.Translate(new Vector3(0.0F,10000.00F,0.0F));
					//Time.timeScale=1.0f;
		     		controleNave=controleNaveCargueira.REPOUSAR;
					}

				} // if ENTRAR_EM_ORBITA

	}  // void Update()

} // class motorTransportador

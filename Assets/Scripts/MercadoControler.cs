using UnityEngine;
using System.Collections;

public class MercadoControler : MonoBehaviour {


	GameObject naveDeTransporte;
	// Use this for initialization
	void Start () {
	
		naveDeTransporte = GameObject.Find ("NaveDeTransporte");
		if (naveDeTransporte != null)
						HUD.msgParaJogador = "NAVE LOCALIZADA";
				else
						HUD.msgParaJogador = "NAVE PERDIDA";
		motorTransportador.controleNave = motorTransportador.controleNaveCargueira.ATERRIZAR;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

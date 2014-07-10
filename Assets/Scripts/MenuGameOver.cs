using UnityEngine;
using System.Collections;

public class MenuGameOver : MonoBehaviour {


	void OnGUI()
	{
		Screen.fullScreen = true;
		string strGmovr = "GAME OVER!";
		GUI.Label (new Rect (Screen.width - strGmovr.Length / 2,
		                     Screen.height / 2 - 35, strGmovr.Length * 35, 35), strGmovr);

		string strPontuacao = "Seu Score foi: " + PlayerPrefs.GetInt ("score").ToString ();
		GUI.Label (new Rect (Screen.width - strPontuacao.Length / 2,
		                    Screen.height / 2 - 35 + 35, strPontuacao.Length * 35, 35), strPontuacao);
		string strBack = "Back To Main Menu";
		if (GUI.Button (new Rect (Screen.width - strBack.Length / 2,
		                        Screen.height / 2 - 35 + 5 * 35,
		                        strBack.Length * 35, 35), strBack)) {
				
			Application.LoadLevel("cenaEntrada");
		
		} // if GUI.Button
	} // void OnGUI()

} // class MenuGameOver

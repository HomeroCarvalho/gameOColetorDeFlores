using UnityEngine;
using System.Collections;

public class ObjetoTransferencia : MonoBehaviour {

	public static int dimX;
	public static int dimY;
	public static int nivelDifuldade;
	public static bool musicaOuNao;
	public static bool fullscreenOuNao;
	void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

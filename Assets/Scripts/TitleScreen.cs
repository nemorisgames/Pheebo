using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void playGame(){
		SceneManager.LoadScene ("Park");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

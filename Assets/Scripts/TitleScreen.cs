using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	public AudioClip buttonSound;
	// Use this for initialization
	void Start () {
		
	}

	public void playGame(){
		GetComponent<AudioSource> ().PlayOneShot (buttonSound);
		StartCoroutine (playGameDelay ());
	}

	IEnumerator playGameDelay(){
		yield return new WaitForSeconds (0.5f);
		SceneManager.LoadScene ("Park");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SketchbookBehaviour : MonoBehaviour {
	public Illustration[] illustrations;
	int currentIndex = 0;
	AudioClip currentSound;
	// Use this for initialization
	void Start () {
		
	}

	public void showIllustration(int index){
		StartCoroutine(showIllustrationDelay(index));
	}

	IEnumerator showIllustrationDelay(int index){
		currentIndex = index;
		for (int i = 0; i < illustrations.Length; i++) {
			illustrations [i].illustrationBorder.SetActive (false);
			illustrations [i].illustrationComplete.SetActive (false);
		}
		currentSound = Resources.Load("Sound/es/" + illustrations [currentIndex].soundComplete) as AudioClip;
		yield return new WaitForSeconds (2f);
		illustrations [currentIndex].illustrationBorder.SetActive (true);
	}

	void illustrationClicked(){
		illustrations [currentIndex].illustrationBorder.SetActive (false);
		illustrations [currentIndex].illustrationComplete.SetActive (true);

		GetComponent<AudioSource> ().PlayOneShot (currentSound);
		AC.LocalVariables.SetBooleanValue (0, false);
	}

	public void closeSketckbook(){
		illustrations [currentIndex].illustrationComplete.SetActive (false);
		StartCoroutine (showCloseDelay ());
	}

	IEnumerator showCloseDelay(){
		yield return new WaitForSeconds (0.7f);
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

[System.Serializable]
public class Illustration{
	public GameObject illustrationBorder;
	public GameObject illustrationComplete;
	public string soundComplete;
}
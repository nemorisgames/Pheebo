using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseDown(){
		StartCoroutine (animateButton());
	}

	IEnumerator animateButton(){
		float scale = 1f;
		for (int i = 0; i < 10; i++) {
			scale -= 0.01f;
			transform.localScale = scale * Vector3.one;
			yield return new WaitForSeconds (0.01f);
		}
		for (int i = 0; i < 10; i++) {
			scale += 0.01f;
			transform.localScale = scale * Vector3.one;
			yield return new WaitForSeconds (0.01f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

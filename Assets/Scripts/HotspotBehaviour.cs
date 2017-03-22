using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotspotBehaviour : MonoBehaviour {
	public GameObject[] objectsShowingDuringClick;
	public GameObject[] objectsShowingToCharacter;
	public bool showing1 = false;
	public bool showing2 = false;
	public float timeShowing = 5f;
	public float currentTimeShowing = -1f;
	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	public void onClick(){
		if (showing1)
			return;
		showing1 = true;
		foreach (GameObject g in objectsShowingDuringClick) {
			g.SetActive (true);
			g.SendMessage ("PlayForward", SendMessageOptions.DontRequireReceiver);
		}
		if (animator != null)
			animator.SetTrigger ("Click1");
	}

	public void onCharacter(){
		if (showing2)
			return;
		showing2 = true;
		foreach (GameObject g in objectsShowingDuringClick) {
			g.SendMessage ("ResetToBeginning", SendMessageOptions.DontRequireReceiver);
			g.SetActive (false);
		}
		foreach (GameObject g in objectsShowingToCharacter) {
			g.SetActive (true);
			g.SendMessage ("PlayForward", SendMessageOptions.DontRequireReceiver);
		}
		if (animator != null)
			animator.SetTrigger ("Click2");
	}

	public void completeTask(){
		foreach (GameObject g in objectsShowingToCharacter) {
			g.SendMessage ("ResetToBeginning", SendMessageOptions.DontRequireReceiver);
			g.SetActive (false);
		}
		showing1 = false;
		showing2 = false;
		currentTimeShowing = -1f;
	}

	// Update is called once per frame
	void Update () {
		if (showing1) {
			if (currentTimeShowing < 0f)
				currentTimeShowing = Time.time;
			/*if (currentTimeShowing + timeShowing < Time.time) {
				foreach (GameObject g in objectsShowingToCharacter) {
					g.SendMessage ("ResetToBeginning", SendMessageOptions.DontRequireReceiver);
					g.SetActive (false);
				}
				showing1 = false;
				showing2 = false;
				currentTimeShowing = -1f;
			}*/
		}
	}
}

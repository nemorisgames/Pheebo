﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotspotBehaviour : MonoBehaviour {
	bool resetObjectsShowingDuringClick = false;
	public GameObject[] objectsShowingDuringClick;
	public GameObject[] objectsShowingToCharacter;
	public AudioClip soundDuringClick;
	public AudioClip[] soundDuringShowing;
	public string soundComplete;
	AudioClip soundCompleteClip;
	public AudioClip musicLoop;
	public bool showing1 = false;
	public bool showing2 = false;
	public float timeShowing = 5f;
	public float currentTimeShowing = -1f;
	Animator animator;
	AudioSource audio;
	public Animator sketchbook;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
		soundCompleteClip = Resources.Load("Sound/es/" + soundComplete) as AudioClip;
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
		audio.clip = musicLoop;
		audio.Play ();
		audio.PlayOneShot (soundDuringClick);
	}

	public void onCharacter(){
		if (showing2)
			return;
		showing2 = true;
		if(resetObjectsShowingDuringClick)
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
		audio.Stop ();
		foreach (AudioClip a in soundDuringShowing)
			audio.PlayOneShot (a);
		StartCoroutine (playCompleteSound ());
	}

	IEnumerator playCompleteSound(){
		yield return new WaitForSeconds (1f);
		audio.PlayOneShot (soundCompleteClip);
	}

	public void openSketchbook(){
		sketchbook.gameObject.SetActive (true);
		sketchbook.SetTrigger ("open");
	}

	public void closeSketchbook(){
		sketchbook.SendMessage("closeSketckbook");
		sketchbook.SetTrigger ("close");
		StartCoroutine(completeTask ());
	}

	IEnumerator completeTask(){

		yield return new WaitForSeconds (0.5f);
		foreach (GameObject g in objectsShowingToCharacter) {
			g.SendMessage ("PlayReverse", SendMessageOptions.DontRequireReceiver);
		}
		yield return new WaitForSeconds (1f);
		foreach (GameObject g in objectsShowingDuringClick)
			g.SetActive (false);
		foreach (GameObject g in objectsShowingToCharacter)
			g.SetActive (false);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour {
	public bool paus = false;
	public GameObject panelpause;
	// Use this for initialization
	void Start () {
		panelpause.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void pauser(){

			panelpause.SetActive (true);
			paus = false;
			Time.timeScale = 0;
			return;
		
	}
	public void resume(){

		panelpause.SetActive (false);
			paus = true;
			Time.timeScale = 1;
			return;
		
			
		
	}
}

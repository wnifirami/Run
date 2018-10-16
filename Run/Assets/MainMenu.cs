using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void loadscene(){

		Time.timeScale = 1;
		SceneManager.LoadScene (1);
	}

	public void QuitGame(){

		Debug.Log ("Quit");
		Application.Quit();
	}


}

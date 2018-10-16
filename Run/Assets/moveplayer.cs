using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class moveplayer : MonoBehaviour {
	public Slider healthbar;
	public AudioSource audiogame;
	private float compt;
	public Image speedup;
	public GameObject build1;
	public GameObject build2;
	public GameObject build3;
	public GameObject build4;
	public GameObject build5;
	public GameObject build6;
	public GameObject build7;
	public GameObject build8;
	public GameObject coins;
	public Transform spawnpos;
	Animator animator;
	public Text compteurtext;
	public GameObject Panel;
	public GameObject Panelpause;
	public Text scoretext;
	public Text runfor;
	const int state_run = 0;
	public bool paus = false;
	public int score=0;
	const int state_slide = 5;
	const int state_sliding = 6;
	const int state_jump = 1;
	const int state_stumbing = 7;
	const int state_back  = 2;
	const int state_fall = 4;
	const int state_die = 3;
	public float speed = 5f;
	public AudioSource coinsound;

	public float jumpPower=1f;
	bool grounded=true;
	bool go = true;
	bool fall = false;
	bool jumping = false;
	float timer = 1;
	private float screenwidth;
	bool start = false;
	// Use this for initialization
	void Start () {
		//Time.timeScale = 1;
		audiogame.Play ();
		compt = 0f;
		screenwidth = Screen.width;
		speedup.enabled = false;
		Panel.SetActive (false);
		Panelpause.SetActive (false);
		InvokeRepeating ("spawn", 0.7f,0.7f);
		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		while (i < Input.touchCount) {
			if (Input.GetTouch (i).position.x > screenwidth / 2) {
				animator.SetInteger ("state", state_run);
				transform.Translate(Vector3.right*Time.deltaTime*speed);
			
			
			}
			if (Input.GetTouch (i).position.x < screenwidth / 2) {
				animator.SetInteger ("state", state_run);
				transform.Translate(Vector3.left*Time.deltaTime*speed);


			}

			i++;
		
		}
		if (go) {
			transform.Translate (Vector3.forward * Time.deltaTime * speed);
			compt += Time.deltaTime;
			compteurtext.text = ""+compt;
		}
	/*	if (this.gameObject.transform.position.y <1f) {
			animator.SetInteger ("state", state_fall);
			Destroy (this.gameObject,1f);


		}*/
		if (healthbar.value == 0) {
			animator.SetInteger ("state", state_die);
			//Destroy (this.gameObject, 4f);
			Time.timeScale = 0;
			runfor.text = "" + compt;
			//SceneManager.LoadScene (0);
			Panel.SetActive (true);

		
		}
		if (start== true) {

			timer += Time.deltaTime;

			if (timer > 2f)  {
				if (!grounded) {
					print ("done");
					go = false;
					animator.SetInteger ("state", state_fall);
					Time.timeScale = 0;
					runfor.text = "" + compt;
					Panel.SetActive (true);

				}
			}


		}
		if (Input.GetKey ("right")) {
			animator.SetInteger ("state", state_run);
			transform.Translate(Vector3.right*Time.deltaTime*speed);

		}
		else if (Input.GetKeyUp ("right")) {
			
		}
		if (Input.GetKey ("down")) {
			animator.SetInteger ("state", state_slide);
			transform.Translate(Vector3.right*Time.deltaTime*speed);

		}
		else if (Input.GetKeyUp ("right")) {
			animator.SetInteger ("state", state_run);
		}
		if (Input.GetKey ("left") ) {
			animator.SetInteger ("state", state_run);
			transform.Translate(Vector3.left*Time.deltaTime*speed);
		
		}
		else if (Input.GetKeyUp ("left")) {

		}
		if (Input.GetKeyDown ("up")) {
			if (grounded == true) {
				jumping = true;
				this.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 3.5f,0);
				animator.SetInteger ("state", state_jump);
				grounded = false;

			}
		}
		else if (Input.GetKeyUp ("up")) {

			animator.SetInteger ("state", state_run);
			StartCoroutine(wait());
			if (!grounded && !jumping) {
				fall = true;
			}
		/*	Vector2 v2=new Vector2(0,10f);
			this.GetComponent<Rigidbody>().AddForce(v2* jumpPower, ForceMode2D.Force);*/

		}
	}


	void OnCollisionEnter(Collision coll){


		//onground

		if (coll.gameObject.tag == "ground") {
			start = false;
			fall = false;
			timer = 1;
			grounded = true;
			animator.SetInteger ("state", state_run);
		}
	
		//3imara ya mw 
		if (coll.gameObject.tag == "obst") {

			go = false;
			grounded = true;
			animator.SetInteger ("state", state_die);
			Time.timeScale = 0;
			Panel.SetActive ( true);
			runfor.text = "" + compt;
		


		}
		//coin
		if (coll.gameObject.tag == "coin") {
			coinsound.Play ();
			Destroy (coll.gameObject);
			score += 1;
			scoretext.text = ""+ score;
		}
		if (coll.gameObject.tag == "slider") {
			start = false;
			timer = 1;
			fall = false;
			go = true;
			grounded = true;
			animator.SetInteger ("state", state_sliding);
		}

	}
	void OnTriggerEnter(Collider coll){





		if (coll.gameObject.tag == "boxes") {
			healthbar.value -= 0.05f;

			animator.SetInteger ("state", state_stumbing);
		}


		if (coll.gameObject.tag == "inst2") {
			build1.transform.position = new Vector3(build1.transform.position.x,build1.transform.position.y-2.74f,build8.transform.position.z+7.56f);
			speedup.enabled = false;

		}
		if (coll.gameObject.tag == "inst3") {
			build2.transform.position = new Vector3(build2.transform.position.x,build2.transform.position.y-2.74f,build1.transform.position.z+5.25f);

		}

		if (coll.gameObject.tag == "inst4") {
			build3.transform.position = new Vector3(build3.transform.position.x,build3.transform.position.y-2.74f,build2.transform.position.z+6.58f);

		}

		if (coll.gameObject.tag == "inst5") {
			build4.transform.position = new Vector3(build4.transform.position.x,build4.transform.position.y-2.74f,build3.transform.position.z+10.48f);

		}

		if (coll.gameObject.tag == "inst6") {
			build5.transform.position = new Vector3(build5.transform.position.x,build5.transform.position.y-2.74f,build4.transform.position.z+9.04f);

		}

		if (coll.gameObject.tag == "inst7") {
			build6.transform.position = new Vector3(build6.transform.position.x,build6.transform.position.y-2.74f,build5.transform.position.z+5.13f);

		}

		if (coll.gameObject.tag == "inst8") {
			build7.transform.position = new Vector3(build7.transform.position.x,build7.transform.position.y-2.74f,build6.transform.position.z+6.1f);



		}
		if (coll.gameObject.tag == "inst1") {
			build8.transform.position = new Vector3(build8.transform.position.x,build8.transform.position.y-2.74f,build7.transform.position.z+9.24f);
			speed += 0.25f;
			speedup.enabled = true;

		}

	}
	void OnTriggerExit(Collider coll){





		if (coll.gameObject.tag == "boxes") {

			animator.SetInteger ("state", state_run);
		}



	}
	void OnCollisionExit(Collision coll){




	
		if (coll.gameObject.tag == "slider") {
			start = true;
			go = true;
			grounded = true;

		}
		if (coll.gameObject.tag == "ground") {
			print ("collide exit");
			start = true;
			go = true;
			grounded = false;

		}
	}
	IEnumerator wait()
	{

		yield return new WaitForSeconds(2);
	
	}
	public void replay(){
		//Time.timeScale = 0;
		ShowRewardedAd ();

		audiogame.Stop ();
		SceneManager.LoadScene (0);

	}
	public void Mainmenu(){
		Time.timeScale = 1;
		SceneManager.LoadScene (0);

	}
	public void pauser(){

		Panelpause.SetActive (true);
		paus = false;
		Time.timeScale = 0;
		return;

	}
	public void resume(){

		Panelpause.SetActive (false);
		paus = true;
		Time.timeScale = 1;
		return;



	}
	public void spawn(){

		Instantiate (coins, new Vector3(spawnpos.position.x,spawnpos.position.y,spawnpos.position.z), coins.transform.rotation);
	}
	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Time.timeScale = 1;

			Debug.Log("The ad was successfully shown.");
			//
			// YOUR CODE TO REWARD THE GAMER
			// Give coins etc.
			break;
		case ShowResult.Skipped:
			Time.timeScale = 1;

			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Time.timeScale = 1;

			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHaractermove : MonoBehaviour {
	private Transform lookat;
	private Vector3 ofset;
	private Vector3 movevector;
	private float screenwidth;
	public GameObject character;
	private float transition=0.0f;
	private float animationduration=3.0f;
	private Vector3 animationoffset = new Vector3 (4f, 1.5f,-8f);
	bool move=true;
	   private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
	// Use this for initialization
	void Start () {
		lookat = character.transform;
		ofset = transform.position - lookat.position;
		screenwidth = Screen.width;
		 dragDistance = Screen.height * 15 / 100;
	}
	
	// Update is called once per frame
	void Update () {
		movevector = lookat.position + ofset;
		movevector.x = 4.3f;

		movevector.y = Mathf.Clamp (movevector.y,character.transform.position.y-10f,transform.position.y+6f);
		if (transition > 1.0f) {
			transform.position = movevector;
		} else {
		
			transform.position = Vector3.Lerp(movevector + animationoffset, movevector, transition);
			transition += Time.deltaTime * 1 / animationduration;
			transform.LookAt (lookat.position + Vector3.up);
		}


		if (Input.touchCount == 1) { // user is touching the screen with a single touch
			Touch touch = Input.GetTouch (0); // get the touch
			if (touch.phase == TouchPhase.Began) { //check for the first touch
				fp = touch.position;
				lp = touch.position;
			} else if (touch.phase == TouchPhase.Moved) { // update the last position based on where they moved
				lp = touch.position;
			} else if (touch.phase == TouchPhase.Ended) { //check if the finger is removed from the screen
				lp = touch.position;  //last touch position. Ommitted if you use list
 
				//Check if drag distance is greater than 20% of the screen height
				if (Mathf.Abs (lp.x - fp.x) > dragDistance || Mathf.Abs (lp.y - fp.y) > dragDistance) {//It's a drag
					//check if the drag is vertical or horizontal
					if (Mathf.Abs (lp.x - fp.x) > Mathf.Abs (lp.y - fp.y)) {   //If the horizontal movement is greater than the vertical movement...
						if ((lp.x > fp.x) && move) {  //If the movement was to the right)//Right swipe
							Debug.Log ("Right Swipe");
							character.GetComponent<Animator> ().SetInteger ("state", 0);
			
							character.transform.Translate (Vector3.right * Time.deltaTime * 2);

						} else {   //Left swipe
							Debug.Log ("Left Swipe");
							character.GetComponent<Animator> ().SetInteger ("state", 0);
			
							character.transform.Translate (Vector3.left * Time.deltaTime * 2);

						}
					} else {   //the vertical movement is greater than the horizontal movement
						if (lp.y > fp.y) {  //If the movement was up//Up swipe
							move=false;
							Debug.Log ("Up Swipe");
							character.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 3.5f, 0);
							move = true;
						} else {   //Down swipe
							Debug.Log ("Down Swipe");
						}
					}
				} else {   //It's a tap as the drag distance is less than 20% of the screen height
					Debug.Log ("Tap");


				}
			}
		}
	}
}

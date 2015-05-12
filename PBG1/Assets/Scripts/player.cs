using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player : MonoBehaviour {
	Vector3 position;
	bool jump;
	public Animator anim;
	public int Move;
	public Text scorePoint;

	public AudioClip jumpSound;
	public float speedmove=50;
	public float speedjump=300;


	public Vector2 jumpForce = new Vector2(20, 300);
	public Vector2 leftForce = new Vector2(-100, 0);
	public Vector2 rightForce = new Vector2(100, 0);
	void Start(){
	//	scorePoint = 0;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			//rigidbody.velocity = Vector2.zero;
			//rigidbody.AddForce (leftForce);

			Move = 1;
			transform.Rotate(0,0f,0);

			position= transform.position+(Vector3.left*2);
			this.gameObject.transform.position = Vector3.MoveTowards (transform.position, position, speedmove * Time.deltaTime);
		} else
		if (Input.GetKeyDown (KeyCode.D)) {
			//rigidbody.velocity = Vector2.zero;
			//rigidbody.AddForce (rightForce);
			Move = 1;
			transform.Rotate(0,180f,0);
			position= transform.position+(Vector3.right*2);
			this.gameObject.transform.position = Vector3.MoveTowards (transform.position, position, speedmove * Time.deltaTime);
		} else
		if (!jump) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
				GetComponent<Rigidbody> ().AddForce (Vector3.up * speedjump);		
				audio.clip = jumpSound;
				audio.Play ();
			}
		} else {
			Move = 0;
		}
		anim.SetInteger("Move", Move);

	}
	
	void OnCollisionEnter(Collision other){
		//jump = false;;
		if(other.gameObject.tag=="Point")
		{
			Destroy (GameObject.FindGameObjectWithTag("Point"));
			int Point = int.Parse(scorePoint.text)+100;
			scorePoint.text = Point.ToString();

			//this.gameObject.
		}
		Debug.Log ("Tersentuh");
	}
	
	void OnCollisionExit(Collision other){
		//jump = true;
		Debug.Log ("Terlepas");
	}
}

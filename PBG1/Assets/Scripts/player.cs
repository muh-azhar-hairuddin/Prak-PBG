using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	Vector3 position;
	bool jump;
	public AudioClip jumpSound;
	public float speedmove=50;
	public float speedjump=300;

	public Vector2 jumpForce = new Vector2(20, 300);
	public Vector2 leftForce = new Vector2(-100, 0);
	public Vector2 rightForce = new Vector2(100, 0);

	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			rigidbody.velocity = Vector2.zero;
			rigidbody.AddForce(leftForce);
			//position= transform.position+Vector3.left;
			//this.gameObject.transform.position = Vector3.MoveTowards (transform.position, position, speedmove * Time.deltaTime);
		}
		
		if (Input.GetKeyDown (KeyCode.D)) {
			rigidbody.velocity = Vector2.zero;
			rigidbody.AddForce(rightForce);
			//position= transform.position+Vector3.right;
			//this.gameObject.transform.position = Vector3.MoveTowards (transform.position, position, speedmove * Time.deltaTime);
		}
		if (!jump) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
				GetComponent<Rigidbody> ().AddForce (Vector3.up * speedjump);		
				audio.clip=jumpSound;
				audio.Play();
			}
		}
	}
	
	void OnCollisionEnter(Collision other){
		//jump = false;;
		Debug.Log ("Tersentuh");
	}
	
	void OnCollisionExit(Collision other){
		//jump = true;
		Debug.Log ("Terlepas");
	}
}

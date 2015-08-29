using UnityEngine;
using System.Collections;
//using System.Runtime ;

public class playerMovement : MonoBehaviour {

	public string input ;
	public float speed ;
	public int partsExposed ;
	//public Vector2 mouseScreenPosition ;
	//public Vector2 mouseWorldPosition ;


	// Update is called once per frame
	void FixedUpdate () {
		Rigidbody2D rbd = GetComponent<Rigidbody2D> ();
	
		float leftInput = Input.GetButton("Left") ? 1 : 0;
		float rightInput = Input.GetButton("Right") ? 1 : 0;
		float upInput = Input.GetButton("Up") ? 1 : 0;
		float downInput = Input.GetButton("Down") ? 1 : 0;
		//Debug.Log (Input.GetButtonDown ("Left"));
		//GetComponent<Rigidbody> ().MovePosition(transform.position+Vector3.left*speed*(leftInput-rightInput)+Vector3.up*speed*(upInput-downInput));
		//rbd.AddForce(Vector3.left*speed*(leftInput-rightInput)+Vector3.up*speed*(upInput-downInput));
		rbd.velocity = Vector2.Lerp(rbd.velocity, new Vector2 (speed * (rightInput - leftInput), speed * (upInput - downInput)),0.2f);
		while (rbd.velocity.magnitude > 13f) {
			rbd.velocity = rbd.velocity*0.9f ;
		}

		//mouseScreenPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
		//mouseWorldPosition = Camera.main.ScreenToWorldPoint (mouseScreenPosition);
		//transform.LookAt (mouseWorldPosition, Vector3.up);

		float h = Input.mousePosition.x - Screen.width / 2;
		float v = Input.mousePosition.y - Screen.height / 2;
		float angle = -Mathf.Atan2(h,v) * Mathf.Rad2Deg;
		
		transform.rotation = Quaternion.Euler (0, 0, angle);
		//Debug.Log (partsExposed);
		partsExposed = 0;
	}
}

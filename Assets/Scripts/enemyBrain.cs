using UnityEngine;
using System.Collections;

public class enemyBrain : MonoBehaviour {
	public int aiState ; //0 = stationary ; 1 = patrolling ; 2 = chasing
	public int patrolNodeAmount ;
	public int currentNode ;
	public float speed ;
	public GameObject patrolRoute ;
	public int pathDirection ;
	// Use this for initialization
	void Start () {
		aiState = 1;
		patrolNodeAmount = patrolRoute.transform.childCount;
		pathDirection = 1;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (aiState == 0) {
			Debug.Log ("SHIT");
		} else {
			transform.LookAt (transform.GetChild (currentNode).transform.position);
			Debug.Log ("Patrolling!");
			if (Vector3.Distance (transform.position, transform.GetChild (currentNode).transform.position) < 0.5f) {
				if (currentNode < patrolNodeAmount) {
					currentNode += 1;
				} else {
					currentNode = 0;
				}
			} 
			transform.Translate (new Vector3
			 (GetComponent<Rigidbody2D> ().position.x + (speed * Time.fixedDeltaTime * Mathf.Cos (transform.rotation.eulerAngles.z * Mathf.Deg2Rad)), 
			 GetComponent<Rigidbody2D> ().position.y + (speed * Time.fixedDeltaTime * Mathf.Sin (transform.rotation.eulerAngles.z * Mathf.Deg2Rad)), transform.position.z));
		}*/
		//transform.LookAt (transform.GetChild (currentNode).transform.position,Vector3.right);
		//Debug.Log ("Patrolling!");
		if (Vector3.Distance (transform.position, patrolRoute.transform.GetChild (currentNode).transform.position) < 0.5f) {
			if (patrolRoute.tag == "CircularPath") {
				if (currentNode < patrolNodeAmount-1) {
					currentNode += 1;
				} else {
					currentNode = 0;
				}
			} else if (patrolRoute.tag == "InvertPath")   {
				if (currentNode < patrolNodeAmount-1&&currentNode>0) {
					currentNode += pathDirection;
				} else {
					pathDirection = -pathDirection;
					currentNode += pathDirection;
				}
			}
		}
		//Debug.Log (currentNode);
		Vector3 dir = patrolRoute.transform.GetChild (currentNode).transform.position - transform.position;
		float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg)-90f;
		Quaternion intendedRotation = Quaternion.AngleAxis(angle, Vector3.forward) ;
		//transform.rotation = Quaternion.Euler(Vector3.Lerp (transform.rotation.eulerAngles,intendedRotation,0.05f));
		transform.rotation = Quaternion.Lerp (transform.rotation,intendedRotation, 0.05f);
		transform.position = Vector3.MoveTowards (transform.position, patrolRoute.transform.GetChild (currentNode).transform.position, speed);
	}
}

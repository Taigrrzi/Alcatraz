using UnityEngine;
using System.Collections;

public class lightBrain : MonoBehaviour {
	public GameObject player ;
	//Light lightPart ;
	public int partsSeen ;
	// Use this for initialization
	void Start () {
		//lightPart = transform.GetChild(0).GetComponent<Light> ();
		partsSeen = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () { 
		partsSeen = 0;
		if (Vector3.Distance (transform.position, player.transform.position) < gameObject.GetComponent<Light>().range*2/3) {
			//Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y),direction,distance,layerMask,minDepth,maxDepth);
			for (int i=0;i<4;i++) {
				if (!Physics.Linecast (new Vector3 (transform.position.x, transform.position.y, 1), new Vector3 (player.transform.GetChild(i).transform.position.x, player.transform.GetChild(i).transform.position.y, 1))) {
					if (Vector3.Distance(new Vector3 (transform.position.x, transform.position.y, 1), new Vector3 (player.transform.GetChild(i).transform.position.x, player.transform.GetChild(i).transform.position.y, 1)) < gameObject.GetComponent<Light>().range*2/3) {
						partsSeen ++;
					}
					//Debug.DrawLine(new Vector3 (transform.position.x, transform.position.y, 1), new Vector3 (player.transform.GetChild(i).transform.position.x, player.transform.GetChild(i).transform.position.y, 1), Color.red);
				}
			}
		}
		if (partsSeen > player.GetComponent<playerMovement>().partsExposed) {
			player.GetComponent<playerMovement>().partsExposed = partsSeen ;
		}
	}
	void OnDrawGizmos () {
		if (Vector3.Distance (transform.position, player.transform.position) < gameObject.GetComponent<Light>().range*2/3) {
			//Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y),direction,distance,layerMask,minDepth,maxDepth);
			for (int i=0;i<4;i++) {
				if (!Physics.Linecast (new Vector3 (transform.position.x, transform.position.y, 1), new Vector3 (player.transform.GetChild(i).transform.position.x, player.transform.GetChild(i).transform.position.y, 1))) {
					//Gizmos.color = Color.red ;
					//Gizmos.DrawSphere(new Vector3(player.transform.GetChild(i).transform.position.x,player.transform.GetChild(i).transform.position.y,0),0.07f) ;
					if (Vector3.Distance(new Vector3 (transform.position.x, transform.position.y, 1), new Vector3 (player.transform.GetChild(i).transform.position.x, player.transform.GetChild(i).transform.position.y, 1)) < gameObject.GetComponent<Light>().range*2/3) {					
						Gizmos.color = Color.red;
						Gizmos.DrawLine(new Vector3 (transform.position.x, transform.position.y, 1), new Vector3 (player.transform.GetChild(i).transform.position.x, player.transform.GetChild(i).transform.position.y, 1));
					}
				}
			}
		}
	}
}

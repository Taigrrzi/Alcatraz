using UnityEngine;
using System.Collections;

public class lightBrain : MonoBehaviour {
	public GameObject player ;
	Light lightPart ;
	public int partsSeen ;
	// Use this for initialization
	void Start () {
		lightPart = transform.GetChild(0).GetComponent<Light> ();
		partsSeen = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () { 
		partsSeen = 0;
		if (Vector3.Distance (transform.position, player.transform.position) < lightPart.range*2/3) {
			//Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y),direction,distance,layerMask,minDepth,maxDepth);
			for (int i=0;i<4;i++) {
				if (!Physics.Linecast (new Vector3 (transform.position.x, transform.position.y, 1), new Vector3 (player.transform.GetChild(i).transform.position.x, player.transform.GetChild(i).transform.position.y, 1))) {
					partsSeen ++;
				}
			}
			/*if (!Physics.Linecast (new Vector3 (transform.position.x, transform.position.y, 1), new Vector3 (player.transform.position.x + 0.6f, player.transform.position.y, 1))) {
				partsSeen ++;
			}
			if (!Physics.Linecast (new Vector3 (transform.position.x, transform.position.y, 1), new Vector3 (player.transform.position.x - 0.6f, player.transform.position.y, 1))) {
				partsSeen ++;
			}
			if (!Physics.Linecast (new Vector3 (transform.position.x, transform.position.y, 1), new Vector3 (player.transform.position.x, player.transform.position.y + 0.4f, 1))) {
				partsSeen ++;
			}*/
		} else {
			//Debug.Log (Vector3.Distance (transform.position, player.transform.position)) ;
		}
		if (partsSeen > player.GetComponent<playerMovement>().partsExposed) {
			player.GetComponent<playerMovement>().partsExposed = partsSeen ;
		}
	}
}

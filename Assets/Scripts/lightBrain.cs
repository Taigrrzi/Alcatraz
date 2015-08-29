using UnityEngine;
using System.Collections;

public class lightBrain : MonoBehaviour {
	public GameObject player ;
	Light lightPart ;
	// Use this for initialization
	void Start () {
		lightPart = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () { 
		if (Vector3.Distance (transform.position, player.transform.position) < lightPart.range) {
			Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y),direction,distance,layerMask,minDepth,maxDepth);
		}
	}
}

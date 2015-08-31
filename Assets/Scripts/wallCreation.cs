using UnityEngine;
using System.Collections;

public class wallCreation : MonoBehaviour {

	GameObject Mask ;
	// Use this for initialization
	void Start () {
		Mask = new GameObject ();
		Mask.transform.parent = gameObject.transform;
		Mask.AddComponent<SpriteRenderer>() ;
		Mask.name = "2D Mask";
		Mask.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("grayPixel");
		Mask.transform.localScale = new Vector3(100,100,0);	
		//Mask.GetComponent<SpriteRenderer> ().material = Resources.Load<Material> ("DiffSprite");
		Mask.AddComponent<BoxCollider2D> ();
		Mask.GetComponent<BoxCollider2D> ().size = new Vector2 (0.01f,0.01f);
		transform.GetChild(0).transform.localPosition = new Vector3(0,0,0);
		Debug.Log ("Created!");

	}
}

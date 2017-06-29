using UnityEngine;
using System.Collections;

public class mgeffectScript : MonoBehaviour {
	public float POWER = 1f;
	const float  LENGTH = 1.5f;
	public MGTYPE mgtype;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D c){
		Vector3 dir = (transform.position - c.transform.position);
		float len = (LENGTH - dir.magnitude) / LENGTH;
		Vector3 mgpower=(dir.normalized * len * POWER);
		if (c.gameObject.GetComponent<gnetScript> ().mgtype != this.mgtype) {
			mgpower *= -1;
		}
		c.gameObject.GetComponent<Rigidbody2D> ().AddForce (mgpower);
	}

}

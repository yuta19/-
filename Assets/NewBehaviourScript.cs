using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool grounded = Physics2D.Linecast (
			transform.position + transform.up * 1,
			transform.position - transform.up * 0.1f

		);

		//Debug.Log ("grounded ->" + grounded);
		GetComponent<Animator>().SetBool("Grounded",grounded);

	}

	private bool facingRight = true;

	void FixedUpdate()
	{
		float h = Input.GetAxis ("Horizontal");

		//右を向いていて、左の入力があったとき、もしくは左を向いていて、右の入力があったとき
		if ((h > 0 && !facingRight) || (h < 0 && facingRight)) { 
			//右を向いているかどうかを、入力方向をみて決める
			facingRight = (h > 0);
			//localScale.xを、右を向いているかどうかで更新する
			transform.localScale = new Vector3 ((facingRight ? 1 : -1), 1, 1);
		}

		float v = Input.GetAxis ("Vertical");

		GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * 30f);

		if (v > 0) {
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * v * 50f);
		}
	
	}
}

using UnityEngine;
using System.Collections;

public class gnetScript : MonoBehaviour {
	bool mjump = false;
	public MGTYPE mgtype;

	public float speed = 4f; //歩くスピード
	private Rigidbody2D rigidbody2D;
	private Animator anim;

	public float jumpPower = 700; //ジャンプ力

	SpriteRenderer eye ;

	void Start () {
		//各コンポーネントをキャッシュしておく
		anim = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();

		eye = transform.FindChild ("eye").GetComponent<SpriteRenderer> ();
	
	}



	void Update () {

		//左キー: -1、右キー: 1
		float x = Input.GetAxisRaw ("Horizontal");

		//左か右を入力したら
		if (x != 0) {
			//入力方向へ移動
			GetComponent<Rigidbody2D>().velocity = new Vector2 (x * speed, GetComponent<Rigidbody2D>().velocity.y);
			//localScale.xを-1にすると画像が反転する
			Vector2 temp = transform.localScale;
			temp.x = x;
			transform.localScale = temp;
			//Wait→Dash
			anim.SetBool("boolWalk(S)", true);
			//左も右も入力していなかったら
		} else {
			//横移動の速度を0にしてピタッと止まるようにする
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0, GetComponent<Rigidbody2D>().velocity.y);
			//Dash→Wait
			anim.SetBool("boolWalk(S)", false);
		}

		if (Input.GetKeyDown (KeyCode.X) && mjump == false) {
			mjump = true;
			anim.SetBool ("boolWalk(S)", false);
			anim.SetTrigger("GoJump");
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpPower);
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			if (mgtype == MGTYPE.N){
				mgtype = MGTYPE.S;
				eye.color = Color.blue;
			}else{
				mgtype = MGTYPE.N;
				eye.color = Color.red;
			}
		}

	}
		
	void OnCollisionEnter2D(Collision2D c){
		GetComponent<Animator> ().SetTrigger ("GoRun(S)");
		mjump = false;
	}
	
		

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public float speed = 10;
	private float xVelocity;
	private Rigidbody2D playerRb;
	private Animator anim;
	private float epsilon = 0.001f;
	private bool facingLeft;
	public float dash = 10;
	public float threshVelocity = 1;
	private bool isAttacking;
	private BoxCollider2D box2d;
	private bool dashing;
	private bool lastStage;
	private AudioSource source;

    // Start is called before the first frame update
    void Start() {
		playerRb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		box2d = GetComponent<BoxCollider2D>();
		source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
		xVelocity = Input.GetAxis("Horizontal");

		if (Mathf.Abs(xVelocity) > epsilon) {
			if (xVelocity > 0) {
				anim.SetBool("Walk", true);
				facingLeft = false;
				anim.SetBool("Walk left", false);
				anim.SetBool("facingLeft", false);		
			}
			if (xVelocity < 0) {
				anim.SetBool("Walk left", true);
				facingLeft = true;
				anim.SetBool("Walk", false);
				anim.SetBool("facingLeft", true);
			}
		}
		if (Mathf.Abs(xVelocity) < epsilon) {
			anim.SetBool("Walk", false);
			anim.SetBool("Walk left", false);
		}
		if (Input.GetButtonDown("Attack")) {
			isAttacking = true;
			source.Play();
			if (!facingLeft) {
				anim.SetTrigger("Attack right");
			}
			if (facingLeft) {
				anim.SetTrigger("Attack left");
			}

		}

		if (GameObject.Find("Stage count").GetComponent<StageCount>().stageNr + 2 == 7) {
			lastStage = true;
		}
	}

	private void FixedUpdate() {
		if (Mathf.Abs(playerRb.velocity.x) < threshVelocity) {
			playerRb.velocity = Vector2.right * xVelocity * Time.fixedDeltaTime * speed;
			dashing = false;

			if (isAttacking) {
				dashing = true;
				if (facingLeft) {
					playerRb.velocity = Vector2.left * dash * Time.fixedDeltaTime;
				} else {
					playerRb.velocity = Vector2.right * dash * Time.fixedDeltaTime;
				}
				isAttacking = false;
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D col) {
		if (dashing && col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<Enemy>().Kill();
		}
		if (!dashing && col.gameObject.tag == "Enemy" && !lastStage) {
			Die();
		}
		if (lastStage && col.gameObject.tag == "Enemy") {
			Physics2D.IgnoreCollision(box2d, col.gameObject.GetComponent<BoxCollider2D>());
		}

		if (dashing && col.gameObject.tag == "Story") {
			SceneManager.LoadScene("Story" + " " + (GameObject.Find("Stage count").GetComponent<StageCount>().stageNr+2).ToString());
		}
	}

	void Die() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}

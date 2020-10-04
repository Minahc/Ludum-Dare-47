using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public GameObject player;
	private BoxCollider2D box2D;
	public float speed;
	private Rigidbody2D rb;
	private float origX;
	public float dist = 5;
	private bool facingLeft;
	private Animator anim;
    // Start is called before the first frame update
    void Start() {
		box2D = gameObject.GetComponent<BoxCollider2D>();
		rb = gameObject.GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		
		for (int i = 0; i < 100; i++) {
			transform.position = Vector3.right * Random.Range(-4, 37) + transform.position.y * Vector3.up + transform.position.z * Vector3.forward;
			Collider2D[] results = new Collider2D[1];
			if (Physics2D.OverlapCollider(box2D, new ContactFilter2D().NoFilter(), results) == 0) break;
		}

		origX = transform.position.x;

		if(Random.value < 0.5f) {
			speed *= -1;
		} else {
			speed *= 1;
		}
	}

    // Update is called once per frame
    void Update() {
		if (speed > 0) {
			anim.SetBool("walk left", false);
			anim.SetBool("facing left", false);
			anim.SetBool("walk right", true);
			facingLeft = false;
		} else if (speed < 0) {
			anim.SetBool("walk left", true);
			anim.SetBool("facing left", true);
			anim.SetBool("walk right", false);
			facingLeft = true;
		}
    }

	private void FixedUpdate() {
		rb.velocity = Vector2.right * speed * Time.fixedDeltaTime;
		if (origX + dist < transform.position.x && !facingLeft) {
			speed *= -1;
		}
		if (origX - dist > transform.position.x && facingLeft) {
			speed *= -1;
		}
	}

	private void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Story") {
			speed *= -1;
		}
	}

	public void Kill () {
		//play kill animation
		Physics2D.IgnoreCollision(box2D, player.GetComponent<BoxCollider2D>());
		
		Destroy(gameObject);
	}
}
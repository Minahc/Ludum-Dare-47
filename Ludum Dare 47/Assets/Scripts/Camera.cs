using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
	public GameObject player;
	private float offsetz;

    // Start is called before the first frame update
    void Start() {
		offsetz = transform.position.z - player.transform.position.z;
    }

    // Update is called once per frame
    void Update() {
		transform.position = player.transform.position.x * Vector3.right + player.transform.position.y * Vector3.up + transform.position.z * Vector3.forward;
    }
}

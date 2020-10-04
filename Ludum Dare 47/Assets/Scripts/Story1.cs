using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story1 : MonoBehaviour {
	public GameObject text;
    // Start is called before the first frame update
    void Start() {
		text.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Submit")) {
			if (text.activeInHierarchy) {
				SceneManager.LoadScene("Stage");
			}
			text.SetActive(true);
		}
    }
}
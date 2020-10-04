using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story3 : MonoBehaviour {
	public GameObject why;
	// Start is called before the first frame update
	void Start() {
		why.SetActive(false);
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetButtonDown("Submit")) {
			if (why.activeInHierarchy) {
				GameObject.Find("Stage count").GetComponent<StageCount>().Stagecount();
				SceneManager.LoadScene("Stage");
			}
			why.SetActive(true);
		}
	}
}
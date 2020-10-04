using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story2 : MonoBehaviour {
	public GameObject img;
	public GameObject witch;
    // Start is called before the first frame update
    void Start() {
		img.SetActive(false);
		witch.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
		if (Input.GetButtonDown("Submit")) {
			if (img.activeInHierarchy && witch.activeInHierarchy) {
				GameObject.Find("Stage count").GetComponent<StageCount>().Stagecount();
				SceneManager.LoadScene("Stage");
			}
			if(!img.activeInHierarchy && !witch.activeInHierarchy) {
				img.SetActive(true);
			} else if (img.activeInHierarchy && !witch.activeInHierarchy) {
				witch.SetActive(true);
			}
		}

	}
}

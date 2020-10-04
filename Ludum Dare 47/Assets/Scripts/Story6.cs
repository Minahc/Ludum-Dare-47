using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story6 : MonoBehaviour {
	public GameObject family;
	public GameObject noKill;
    // Start is called before the first frame update
    void Start() {
		family.SetActive(false);
		noKill.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
		if (Input.GetButtonDown("Submit")) {
			if (family.activeInHierarchy && noKill.activeInHierarchy) {
				GameObject.Find("Stage count").GetComponent<StageCount>().Stagecount();
				SceneManager.LoadScene("Stage");
			}
			if (!family.activeInHierarchy && !noKill.activeInHierarchy) {
				family.SetActive(true);
			} else if (family.activeInHierarchy && !noKill.activeInHierarchy) {
				noKill.SetActive(true);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story5 : MonoBehaviour {
	public GameObject reason;
	public GameObject anger;
	public GameObject reasonable;
	public GameObject never;
    // Start is called before the first frame update
    void Start() {
		reason.SetActive(false);
		anger.SetActive(false);
		reasonable.SetActive(false);
		never.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
		if (Input.GetButtonDown("Submit")) {
			if (reason.activeInHierarchy && anger.activeInHierarchy && reasonable.activeInHierarchy && never.activeInHierarchy) {
				GameObject.Find("Stage count").GetComponent<StageCount>().Stagecount();
				SceneManager.LoadScene("Stage");
			}
			if (!reason.activeInHierarchy && !anger.activeInHierarchy && !reasonable.activeInHierarchy && !never.activeInHierarchy) {
				reason.SetActive(true);
			} else if (reason.activeInHierarchy && !anger.activeInHierarchy && !reasonable.activeInHierarchy && !never.activeInHierarchy) {
				anger.SetActive(true);
			} else if (reason.activeInHierarchy && anger.activeInHierarchy && !reasonable.activeInHierarchy && !never.activeInHierarchy) {
				reasonable.SetActive(true);
			} else if (reason.activeInHierarchy && anger.activeInHierarchy && reasonable.activeInHierarchy && !never.activeInHierarchy) {
				never.SetActive(true);
			}
		}
	}
}

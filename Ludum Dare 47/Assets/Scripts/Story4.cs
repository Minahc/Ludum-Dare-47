using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story4 : MonoBehaviour {
	public GameObject murder;
	public GameObject sheathed;
	public GameObject sliding;
	public GameObject revenge;
	public GameObject vengence;
	private AudioSource source;
	public AudioClip katana;
    // Start is called before the first frame update
    void Start() {
		source = GetComponent<AudioSource>();
		murder.SetActive(false);
		sheathed.SetActive(false);
		sliding.SetActive(false);
		revenge.SetActive(false);
		vengence.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
		if (Input.GetButtonDown("Submit")) {
			if (murder.activeInHierarchy && sheathed.activeInHierarchy && sliding.activeInHierarchy && revenge.activeInHierarchy && vengence.activeInHierarchy) {
				GameObject.Find("Stage count").GetComponent<StageCount>().Stagecount();
				SceneManager.LoadScene("Stage");
			}
			if(!murder.activeInHierarchy && !sheathed.activeInHierarchy && !sliding.activeInHierarchy && !revenge.activeInHierarchy && !vengence.activeInHierarchy) {
				murder.SetActive(true);
			} else if (murder.activeInHierarchy && !sheathed.activeInHierarchy && !sliding.activeInHierarchy && !revenge.activeInHierarchy && !vengence.activeInHierarchy) {
				sheathed.SetActive(true);
			} else if (murder.activeInHierarchy && sheathed.activeInHierarchy && !sliding.activeInHierarchy && !revenge.activeInHierarchy && !vengence.activeInHierarchy) {
				sliding.SetActive(true);
			} else if (murder.activeInHierarchy && sheathed.activeInHierarchy && sliding.activeInHierarchy && !revenge.activeInHierarchy && !vengence.activeInHierarchy) {
				source.PlayOneShot(katana);
				revenge.SetActive(true);
			} else if (murder.activeInHierarchy && sheathed.activeInHierarchy && sliding.activeInHierarchy && revenge.activeInHierarchy && !vengence.activeInHierarchy) {
				vengence.SetActive(true);
			}
		}

	}
}

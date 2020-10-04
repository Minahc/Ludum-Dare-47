using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story7 : MonoBehaviour{
	public GameObject swordimg;
	public GameObject myLove;
	public GameObject tears;
	public GameObject home;
	public GameObject kill;
	public GameObject theEnd;
	private AudioSource source;
    // Start is called before the first frame update
    void Start() {
		source = GetComponent<AudioSource>();
		swordimg.SetActive(false);
		myLove.SetActive(false);
		tears.SetActive(false);
		home.SetActive(false);
		kill.SetActive(false);
		theEnd.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
		if (Input.GetButtonDown("Submit")) {
			if (swordimg.activeInHierarchy && myLove.activeInHierarchy && tears.activeInHierarchy && home.activeInHierarchy && kill.activeInHierarchy && theEnd.activeInHierarchy) {
				SceneManager.LoadScene("Start menu");
			}
			if (!swordimg.activeInHierarchy && !myLove.activeInHierarchy && !tears.activeInHierarchy && !home.activeInHierarchy && !kill.activeInHierarchy && !theEnd.activeInHierarchy) {
				swordimg.SetActive(true);
			} else if (swordimg.activeInHierarchy && !myLove.activeInHierarchy && !tears.activeInHierarchy && !home.activeInHierarchy && !kill.activeInHierarchy && !theEnd.activeInHierarchy) {
				myLove.SetActive(true);
			} else if (swordimg.activeInHierarchy && myLove.activeInHierarchy && !tears.activeInHierarchy && !home.activeInHierarchy && !kill.activeInHierarchy && !theEnd.activeInHierarchy) {
				tears.SetActive(true);
			} else if (swordimg.activeInHierarchy && myLove.activeInHierarchy && tears.activeInHierarchy && !home.activeInHierarchy && !kill.activeInHierarchy && !theEnd.activeInHierarchy) {
				home.SetActive(true);
			} else if (swordimg.activeInHierarchy && myLove.activeInHierarchy && tears.activeInHierarchy && home.activeInHierarchy && !kill.activeInHierarchy && !theEnd.activeInHierarchy) {
				source.Play();
				kill.SetActive(true);
			} else if (swordimg.activeInHierarchy && myLove.activeInHierarchy && tears.activeInHierarchy && home.activeInHierarchy && kill.activeInHierarchy && !theEnd.activeInHierarchy) {
				theEnd.SetActive(true);
			}
		}

	}
}

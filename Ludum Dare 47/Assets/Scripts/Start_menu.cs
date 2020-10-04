using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_menu : MonoBehaviour {
	public GameObject htp;
    // Start is called before the first frame update
    void Start() {
		htp.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        
    }

	public void Startgame() {
		SceneManager.LoadScene("Story 1");
	}

	public void Exit() {
		Application.Quit();
	}

	public void Htp () {
		htp.SetActive(true);
	}

	public void Closehtp() {
		htp.SetActive(false);
	}
}

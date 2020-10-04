using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCount : MonoBehaviour {
	public int stageNr;
    // Start is called before the first frame update
    void Start() {
		
    }

	private void Awake() {
		GameObject[] objs = GameObject.FindGameObjectsWithTag("stagecount");

		if (objs.Length > 1) {
			Destroy(this.gameObject);
		}
		Object.DontDestroyOnLoad(this.gameObject);
	}

	// Update is called once per frame
	void Update() {
        
    }

	public void Stagecount() {
		stageNr++;
	}
}

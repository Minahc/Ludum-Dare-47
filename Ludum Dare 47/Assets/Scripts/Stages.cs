using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stages : MonoBehaviour {
	public int nrEnemy;
	public GameObject enemy;
    // Start is called before the first frame update
    void Start() {
		nrEnemy = 2 + (GameObject.Find("Stage count").GetComponent<StageCount>().stageNr + 1);

		for (int i = 0; i < nrEnemy; i++) {
			Instantiate(enemy);
		}
	}

    // Update is called once per frame
    void Update() {

	}
}

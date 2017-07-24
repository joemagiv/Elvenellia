using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPrayerButton : MonoBehaviour {

    private LevelController levelController;

	// Use this for initialization
	void Start () {
        levelController = FindObjectOfType<LevelController>().GetComponent<LevelController>();
	}

    private void OnMouseDown()
    {
        levelController.StartGame();

    }

    // Update is called once per frame
    void Update () {
		
	}
}

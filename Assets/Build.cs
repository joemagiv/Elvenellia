using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Build : MonoBehaviour {

	private GameController gameController;

	public string nameOfBuilding;

	public int numberOfBuildings;

	public float currentCostOfBuilding;
	public float costMultiplier;

	public float populationModifier;

	public float magicModifier;

	private Text buttonText;

	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<GameController> ().GetComponent<GameController> ();
		buttonText = GetComponentInChildren<Text> ();
		buttonText.text = nameOfBuilding;
	}

	public void BuyBuilding(){
		if (gameController.currentMagic > currentCostOfBuilding){
			numberOfBuildings++;
			gameController.currentMagic -= currentCostOfBuilding;
			gameController.currentMagicGrowthRate += magicModifier;
			gameController.populationGrowthRate += populationModifier;

			currentCostOfBuilding += currentCostOfBuilding * costMultiplier;
		}

	}

	
	// Update is called once per frame
	void Update () {
		
	}
}

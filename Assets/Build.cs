using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Build : MonoBehaviour {

	private GameController gameController;

	public string nameOfBuilding;

	public int numberOfBuildings;

    public int maxPopIncrease;

    public float populationSpeedIncrease;

	public float currentCostOfBuilding;
	public float costMultiplier;


	public float populationModifier;

	public float magicModifier;

	private Text buttonText;
    public Text labelText;

	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<GameController> ().GetComponent<GameController> ();
		buttonText = GetComponentInChildren<Text> ();
		buttonText.text = nameOfBuilding;
        labelText.text = "Cost: " + currentCostOfBuilding.ToString();
    }

	public void BuyBuilding(){
		if (gameController.currentMagic > currentCostOfBuilding){
			numberOfBuildings++;
			gameController.currentMagic -= currentCostOfBuilding;
			gameController.currentMagicGrowthRate += magicModifier;
			gameController.populationGrowthRate += populationModifier;
            gameController.maxPopulation += maxPopIncrease;
            gameController.populationGrowthRate = gameController.populationGrowthRate - (gameController.populationGrowthRate * populationSpeedIncrease);

			currentCostOfBuilding += currentCostOfBuilding * costMultiplier;
            labelText.text = "Cost: " + currentCostOfBuilding.ToString("0");
		}

	}

	
	// Update is called once per frame
	void Update () {
		
	}
}

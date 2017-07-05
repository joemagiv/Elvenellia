using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int currentPopulation;
	public double currentMagic;
	public float currentMagicGrowthRate;
	public float prayerStrengthRate;
	public float populationGrowthRate;
	public float growthTimer;

	public Text currentMagicText;
	public Text currentMagicGrowthRateText;
	public Text currentPopulationText;

	// Use this for initialization
	void Start () {
		
	}

	public void Pray (){
		currentMagic += (currentMagicGrowthRate * prayerStrengthRate);
	}
	
	// Update is called once per frame
	void Update () {
		currentMagic += currentMagicGrowthRate;
		Debug.Log ("Current magic is: " + currentPopulation);
		currentMagicText.text = "Magic: " + currentMagic.ToString ("0.##");
		currentMagicGrowthRateText.text = "Magic Growth Rate: " + currentMagicGrowthRate.ToString ("0.###");
		currentPopulationText.text = "Population: " + currentPopulation.ToString (); 

		//Tracking population growth
		growthTimer++;
		if (growthTimer > populationGrowthRate){
			currentPopulation++;
			growthTimer = 0;
		}
	}
}

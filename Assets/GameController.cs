using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int currentPopulation;
	public int maxPopulation;
	public float populationMultiplier;
	public float populationBonus;
	public double currentMagic;
	public float currentMagicGrowthRate;
	public float prayerStrengthRate;
	public float populationGrowthRate;
	public float growthTimer;

	public Text currentMagicText;
	public Text currentMagicGrowthRateText;
	public Text currentPopulationText;

    //Debugging values
    public float prayerMultiplier;

	// Use this for initialization
	void Start () {
		
	}

	public void Pray (){
		currentMagic += 1 + (currentMagicGrowthRate * prayerStrengthRate);
	}
	
	// Update is called once per frame
	void Update () {
		populationBonus = currentPopulation * populationMultiplier;
        prayerStrengthRate = currentPopulation * prayerMultiplier;

		currentMagic += + currentMagicGrowthRate + populationBonus;
        currentMagicText.text = "Magic: " + currentMagic.ToString("0");
		currentMagicGrowthRateText.text = "Magic Growth Rate: " + currentMagicGrowthRate.ToString ("0.###");
		currentPopulationText.text = "Population: " + currentPopulation.ToString () + " / " + maxPopulation.ToString(); 



		//Tracking population growth
		growthTimer++;
		if (growthTimer > populationGrowthRate){
			if (currentPopulation < maxPopulation) {
				currentPopulation++;
				growthTimer = 0;
			}
		}
	}
}

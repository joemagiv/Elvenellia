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



    //values for spawning elves
    public GameObject elfPrefab;
    public int totalElves;
    public int elfSpawnTimer;
    public int currentElfSpawnTimer;

    public Transform peopleParent;
    public Transform buildingsParent;

    public Animator parentsAnimator;


    //Debugging values
    public float prayerMultiplier;



	// Use this for initialization
	void Start () {
		
	}

	public void Pray (){
		currentMagic += 1 + (currentMagicGrowthRate * prayerStrengthRate);
	}

    //Controlling Build buttons
    public bool buttonsActive;

    public void ShowHideBuildToggle()
    {
        if (!buttonsActive)
        {
            ShowAllBuildOptions();
            buttonsActive = true;
        } else
        {
            HideAllBuildOptions();
        }
    }

    public void ShowAllBuildOptions()
    {
        Build[] buildButtons = FindObjectsOfType<Build>();
        foreach (Build buildButton in buildButtons)
        {
            if (buildButton.isActive)
            {
                buildButton.ShowButton();
            }
        }
    }

    public void HideAllBuildOptions()
    {
        Build[] buildButtons = FindObjectsOfType<Build>();
        foreach (Build buildButton in buildButtons)
        {
            buildButton.HideButton();
        }
        buttonsActive = false;
    }

    private bool scaleIncreased;

    public void IncreaseScale()
    {
        if (!scaleIncreased)
        {
            scaleIncreased = true;
            parentsAnimator.SetTrigger("Zoom");


        }

        
    }

    private bool scaleIncreased2;

    public void IncreaseScale2()
    {
        if (!scaleIncreased2)
        {
            scaleIncreased2 = true;
            parentsAnimator.SetTrigger("Zoom");


        }


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

        //Tracking elf spawning
        currentElfSpawnTimer++;
        if (currentElfSpawnTimer > elfSpawnTimer)
        {
            if (totalElves < currentPopulation)
            {
                Building[] buildings = FindObjectsOfType<Building>();
                if (buildings.Length > 1)
                {
                    totalElves++;
                    Building randomSpawnBuilding = buildings[Mathf.RoundToInt(Random.Range(0, buildings.Length))];
                    Vector3 buildingEntrance = randomSpawnBuilding.entrance.transform.position;

                    GameObject newElf = Instantiate(elfPrefab, buildingEntrance, Quaternion.identity, peopleParent);
                    Elf elfScript = newElf.GetComponent<Elf>();
                    Building randomDestinationBuilding = buildings[Mathf.RoundToInt(Random.Range(0, buildings.Length))];
                    elfScript.spawnVector = buildingEntrance;
                    elfScript.destinationVector = randomDestinationBuilding.entrance.transform.position;
                    currentElfSpawnTimer = 0;
                }
            
              
            }
        }

        if (currentPopulation > 150)
        {
            IncreaseScale();
        }

        if (currentPopulation > 700)
        {
            IncreaseScale2();
        }




	}
}

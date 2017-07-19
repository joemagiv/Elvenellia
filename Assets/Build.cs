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

	public double currentCostOfBuilding;
	public float costMultiplier;



	public float populationModifier;

	public float magicModifier;

	private Text buttonText;
    public Text labelText;

    private Animator animator;

    public bool isActive;

    public GameObject buildingPrefab;
    public Sprite buildingSprite;

    public Transform buildingsParent;

    private SoundManager soundManager;

    public AudioClip buildingSound;

	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<GameController> ().GetComponent<GameController> ();
		buttonText = GetComponentInChildren<Text> ();
        animator = GetComponent<Animator>();
        soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
		buttonText.text = nameOfBuilding;
        labelText.text = "Cost: " + currentCostOfBuilding.ToString();
        this.name = nameOfBuilding;
        HideButton();
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
            BuildBuilding();
            

            
		} else
        {
            soundManager.GenericErrorSound();
        }


	}

    public void BuildBuilding()
    {
        Vector2 buildingPlacement = new Vector2(Random.Range(-6.36f ,6.49f ),Random.Range(-4.05f , -0.07f ));
        GameObject newBuilding = Instantiate(buildingPrefab, buildingPlacement, Quaternion.identity, buildingsParent);
        SpriteRenderer buildingSpriteRenderer = newBuilding.GetComponent<SpriteRenderer>();
        buildingSpriteRenderer.sprite = buildingSprite;
        soundManager.PlaySound(buildingSound);

    }

    public void ShowButton()
    {
        animator.SetBool("Onscreen", true);
    }

    public void HideButton()
    {
        animator.SetBool("Onscreen", false);
    }


	
	// Update is called once per frame
	void Update () {
		if ((gameController.currentMagic  > currentCostOfBuilding - (currentCostOfBuilding * 0.1)))
        {
            if (!isActive)
            {
                isActive = true;
                if (gameController.buttonsActive)
                {
                    ShowButton();
                }
            }
        }
	}
}

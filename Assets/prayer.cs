using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prayer : MonoBehaviour {

    private GameController gameController;
    private SpriteRenderer spriteRenderer;

    private Color initialColor;

    public AudioClip prayingSound;

    private SoundManager soundManager;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
        soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
        initialColor = spriteRenderer.color;
		
	}

    private void OnMouseOver()
    {
     //   Debug.Log("Mouseover on Pray detected");
    }

    private void OnMouseDown()
    {
        gameController.Pray();
        spriteRenderer.color = Color.gray;
        soundManager.PlaySound(prayingSound);


    }

    private void OnMouseUp()
    {
        gameController.Pray();
        spriteRenderer.color = initialColor;

    }



    // Update is called once per frame
    void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroText : MonoBehaviour {

    public string[] introTextLines;
    public int currentLine;

    public Text lineText;

    public Animator textAnimator;
    public Animator environmentAnimator;
    public Animator titlesAnimator;

    public float timeToNextLine;
    public float currentTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if (currentTime > timeToNextLine)
        {
            if (currentLine < introTextLines.Length)
            {
                currentTime = 0;
                lineText.text = introTextLines[currentLine];
                currentLine++;
                textAnimator.SetTrigger("Update Text");
            }

            if (currentLine == 4)
            {
             //   timeToNextLine = 40;
                environmentAnimator.SetTrigger("TreeApproach");
            }

            if (currentLine == introTextLines.Length)
            {
                currentTime = 0;
                timeToNextLine = 20;
                currentLine++;
            }

            if (currentLine > introTextLines.Length)
            {
                titlesAnimator.SetTrigger("CallTitles");
            }
           
            
        }
		
	}
}

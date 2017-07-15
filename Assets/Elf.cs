using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : MonoBehaviour {

    public Vector3 spawnVector;
    public Vector3 destinationVector;
    public float walkSpeed;

    public Vector2 velocity;

    private Rigidbody2D rb;

    private GameController gameController;

	// Use this for initialization
	void Start () {
        gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
        rb = GetComponent<Rigidbody2D>();
	}

    private bool elfKilled;

    void ElfDestroy()
    {
        if (!elfKilled)
        {
            gameController.totalElves--;
            elfKilled = true;
            Destroy(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        float step = walkSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destinationVector, step);

        if (transform.position == destinationVector)
        {
            ElfDestroy();
        }

        if (spawnVector == destinationVector)
        {
            ElfDestroy();
        }
	}
}

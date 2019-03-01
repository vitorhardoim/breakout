using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Defines an Item: a collectable object that will add some kind of power to its users (the actors which collected it).
public class Item : MonoBehaviour {
	//Instance variables.
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isActive { get; set; } = false;
    public float totalTime { get; set; }
    public float timeLeft, blinkCooldown;
    public GameObject[] users;
    public Rigidbody2D rb;

    // Start is called before the first frame update.
    public void Start() { rb = GetComponent<Rigidbody2D>(); }

    // Update is called once per frame. Must be complemented by the use of modifier 'new' in the child classes.
    public void Update() {
    	if (isActive) {
    		blinkCooldown -= Time.deltaTime;
    		timeLeft -= Time.deltaTime;
    		if ((timeLeft <= 1) && (blinkCooldown <= 0)) {
                blinkCooldown = 0.1f;
                Blink();
        	}
    	}
    }

    //Makes the item's icon blinks on the screen.
    public void Blink() {
        if (gameObject.GetComponent<SpriteRenderer>().enabled == false) 
        	gameObject.GetComponent<SpriteRenderer>().enabled = true;
        else if (gameObject.GetComponent<SpriteRenderer>().enabled == true) 
        	gameObject.GetComponent<SpriteRenderer>().enabled = false;        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Defines the Power-up which destroys the entire lowest row of bricks.
public class BurstPUp : Item, IPowerUp {
    // Update is called once per frame
    new void Update() {
        base.Update();
        if (isActive) {
            Activate();
            if (timeLeft <= 0) Deactivate(); //If the time's up, deactivate this power-up overall effect.
        }
    }

    //Destroys the lowest row of bricks on the screen.
    public void Activate() {
        PlayerManager.instance.inventory.RedefinePosition(gameObject);
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
        if (bricks.Length > 0) {
        	float minY = bricks[0].transform.position.y;
        	foreach (GameObject brk in bricks) {
        		if (brk.transform.position.y < minY) minY = brk.transform.position.y;
        	}
        	foreach (GameObject brk in bricks) if (brk.transform.position.y == minY) Destroy(brk);
        }
        Deactivate();    
    }

    //Deactivates the power-up and destroy its related game object. Also, removes the power-up from the inventory list.
    public void Deactivate() {
        //PlayerManager.instance.inventory.qtdItems--;
        PlayerManager.instance.inventory.Remove(gameObject);
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Paddle") {
            timeLeft = 3f;
            isActive = true;
            PlayerManager.instance.inventory.Add(gameObject);
        }
    }

    public void RefillTime() { timeLeft = 3f; }
}
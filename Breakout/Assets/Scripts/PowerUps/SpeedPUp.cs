using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Defines the Power-up which enhances the speed of every ball present on the screen at its activation time.
public class SpeedPUp : Item, IPowerUp {
    // Update is called once per frame
    new void Update() {
        base.Update();
        if (isActive) {
            Activate();
            if (timeLeft <= 0) Deactivate(); //If the time's up, deactivate this power-up overall effect.
        }
    }

    //Enchances the speed of every ball on screen.
    public void Activate() {
        PlayerManager.instance.RedefinePosition(gameObject);
        users = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in users)
            ball.GetComponent<Ball>().constantSpeed = GameObject.Find("Ball").GetComponent<Ball>().originalSpeed + 5;    
    }

    //Deactivates the power-up and destroy its related game object. Also, removes the power-up from the inventory list.
    public void Deactivate() {
    	foreach (GameObject ball in users)
            ball.GetComponent<Ball>().constantSpeed = GameObject.Find("Ball").GetComponent<Ball>().originalSpeed;
        PlayerManager.instance.qtdBuffs--;
        PlayerManager.instance.RemoveBuffFromList(gameObject);
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Paddle") {
            timeLeft = 3f;
            isActive = true;
            PlayerManager.instance.SetBuffInList(gameObject);
        }
    }

    public void RefillTime() { timeLeft = 3f; }
}
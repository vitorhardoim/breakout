using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TazerPUp : Item, IPowerUp {
	public GameObject tazerPrefab;

    // Update is called once per frame
    new void Update() {
        base.Update();
        if (isActive) {
            Activate();
            if (timeLeft <= 0) Deactivate(); //If the time's up, deactivate this power-up overall effect.
        }
    }

    //Reorganize the object's position on the inventory.
    public void Activate() {
        PlayerManager.instance.inventory.RedefinePosition(gameObject);
    }

    //Deactivates the power-up and destroy its related game object. Also, removes the power-up from the inventory list.
    public void Deactivate() {
        PlayerManager.instance.inventory.qtdItems--;
        PlayerManager.instance.inventory.Remove(gameObject);
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Paddle") {
            StartCoroutine(tazerPrefab.GetComponent<Tazer>().DispenseTazer(gameObject));
            timeLeft = 10f;
            isActive = true;
            PlayerManager.instance.inventory.Add(gameObject);
        }
    }

    public void RefillTime() {
    	StopCoroutine(tazerPrefab.GetComponent<Tazer>().DispenseTazer(gameObject));
        timeLeft = 10f;
        StartCoroutine(tazerPrefab.GetComponent<Tazer>().DispenseTazer(gameObject));
    }
}

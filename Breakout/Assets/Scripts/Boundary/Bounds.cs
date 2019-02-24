using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Ball")
        {
            other.GetComponent<Ball>().Respawn();
            GameObject.Find("PlayerManager").GetComponent<PlayerManager>().streak = 0;
            GameObject.Find("PlayerManager").GetComponent<PlayerManager>().lifes--;
        }
        
    }
}

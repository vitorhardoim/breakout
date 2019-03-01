using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	public List<Item> powerUps = new List<Item>();

    // Start is called before the first frame update
    void Add(Item it) {
    	/*if (!powerUps.Any(p => p.tag == it.tag)) powerUps.Add(it);
    	else {
    		foreach(GameObject pUp in powerUps) {
            	if (pUp != null) {
                	if (pUp.tag == it.tag) {
                    	if (buff.tag == "SpeedUp") pUp.GetComponent<Item>().RefillTime();
                	}
            	}
        	}
    	}*/
        
    }

    // Update is called once per frame
    void Remove(Item it) {
        powerUps.Remove(it);
    }
}

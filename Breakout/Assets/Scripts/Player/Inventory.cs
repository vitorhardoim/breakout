using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public int qtdItems;
    GameObject[] activeItems = new GameObject[9];
    List<Vector2> itemsPositions = new List<Vector2>();
    public bool[] usedSlots = new bool[9];


    public void Add(GameObject it) {
        it.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        if (ItemIsInList(it)) Destroy(it);
        else {
            activeItems[qtdItems] = it;
            it.transform.position = itemsPositions[qtdItems];
            usedSlots[qtdItems] = true;
            qtdItems++;
        }
        
    }

    public void RedefinePosition(GameObject it) {
        int position = System.Array.IndexOf(activeItems, it);
        for (int i = 0; i < position; i++) {
            if(usedSlots[i] == false) {
                it.transform.position = itemsPositions[i];
                usedSlots[i] = true;
                usedSlots[position] = false;
                return;
            }
        }
    }

    public bool ItemIsInList(GameObject it) {
        foreach (GameObject itm in activeItems) {
            if (itm != null) {
                if (itm.tag == it.tag) {
                    if (it.tag == "SpeedUp") itm.GetComponent<SpeedPUp>().RefillTime();
                    if (it.name == "TazerUp") itm.GetComponent<TazerPUp>().RefillTime();
                    return true;
                }
            }
        }
        return false;
    }

    public void Remove(GameObject it) {
        foreach (GameObject itm in activeItems) {
            if (itm != null) {
                if (itm.tag == it.tag) {
                    int temp = System.Array.IndexOf(activeItems, itm);
                    activeItems[temp] = null;
                    usedSlots[temp] = false;
                }
            }
        }
    }

    public void FillPositions() { for (int i = 0; i < 9; i++) itemsPositions.Add(new Vector2(8.33f, 4.22f - (0.7f*i))); }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour {

    public List<InventoryItems> inventoryItem = new List<InventoryItems>();
    private InventoryDB db;

	// Use this for initialization
	void Start () {

        /// Initial database 

        db = GameObject.FindGameObjectWithTag("InventoryTag").GetComponent<InventoryDB>();
        inventoryItem.Add(db.inventoryItems[1]);
        inventoryItem.Add(db.inventoryItems[2]);
        inventoryItem.Add(db.inventoryItems[3]);
        inventoryItem.Add(db.inventoryItems[4]);
        
        print(inventoryItem.Count);

    }
	
	// Update is called once per frame
	public void OnGUI () {

        for (int i = 0; i < inventoryItem.Count; i++) {
            GUI.Label(new Rect(10, 10*i, 100, 50), inventoryItem[i].name);
            print(db.inventoryItems[i]);
        }
	}
}

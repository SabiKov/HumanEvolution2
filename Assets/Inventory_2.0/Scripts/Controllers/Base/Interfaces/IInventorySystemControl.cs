using UnityEngine;
using System.Collections.Generic;

public interface IInventorySystemControl  {

    List<GameObject> GetInventoryItems();

    void AddInventoryItem(GameObject item);

    void RemoveInventoryItem(int itemIndex);

    void OpenInventory();

    void CloseInventory();


}

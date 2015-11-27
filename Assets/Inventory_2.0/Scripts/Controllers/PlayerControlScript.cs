using System;
using UnityEngine;

/// <summary>
/// This controller controlls the healtBar system, scorePanel system and player data
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerControlScript : MonoBehaviour, IPlayerControl
{


    private IInventorySystemControl inventorySystem;

    public static IPlayerControl Instance;


    public GameObject InventoryPanel;
    public GameObject HealthPanel;
    public GameObject ScorePanel;


    public void Awake()
    {
        Instance = this;
        this.Init();
    }

    private void Init()
    {

        if (this.InventoryPanel != null)
            this.inventorySystem = this.InventoryPanel.GetComponent<IInventorySystemControl>();
    }

    public void AddInventoryItem(GameObject inventoryItem)
    {
        throw new NotImplementedException();
    }

    public void RemoveInventoryItem(GameObject inventoryItem)
    {
        throw new NotImplementedException();
    }
}
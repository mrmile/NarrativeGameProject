using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsCloseBehavior : MonoBehaviour
{
    public GameObject[] doorGroups;
    int randomDoorGroup = 0;

    public AudioClip doorsOpenSound;
    AudioSource audioSource;

    MapEventsManager mapEventsManager_;

    Time_Manager time_Manager_;

    private float elapsedTime = 0;
    private float startTime = 0;

    public Inventory inventory;
    private bool TarjetaAccesoUsed = false;

    private InventoryUI inventoryUI;

    void Start()
    {
        mapEventsManager_ = FindObjectOfType<MapEventsManager>();
        time_Manager_ = FindObjectOfType<Time_Manager>();
        audioSource = GetComponent<AudioSource>();

        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        inventoryUI = FindObjectOfType<InventoryUI>();
    }

    void Update()
    {
        elapsedTime = Time.time - startTime;

        if (mapEventsManager_.shutDoorGroup == false && mapEventsManager_.doorsShutEventPhase == 0)
        {
            startTime = Time.time;
        }

        if (mapEventsManager_.shutDoorGroup == true && mapEventsManager_.doorsShutEventPhase == 1)
        {
            mapEventsManager_.doorsShutEventPhase = 2;

            randomDoorGroup = Random.Range(0, doorGroups.Length);

            doorGroups[randomDoorGroup].SetActive(true);
            startTime = Time.time;

            Debug.Log("SHUT DOOR GROUP:" + randomDoorGroup);
        }

        if (mapEventsManager_.doorsShutEventPhase == 2 && elapsedTime >= mapEventsManager_.doorsShutEventDuration)
        {
            mapEventsManager_.shutDoorGroup = false;
            mapEventsManager_.doorsShutEventPhase = 3;
        }

        if (mapEventsManager_.shutDoorGroup == false && mapEventsManager_.doorsShutEventPhase == 3)
        {
            mapEventsManager_.doorsShutEventPhase = 0;

            audioSource.PlayOneShot(doorsOpenSound);

            doorGroups[randomDoorGroup].SetActive(false);
            mapEventsManager_.shutDoorGroup = false;

            Debug.Log("DOORS OPENING BACK");

            time_Manager_.PauseGameTime(false);
        }

        if (mapEventsManager_.doorsShutEventPhase == 2 && !TarjetaAccesoUsed && Input.GetKeyDown(KeyCode.E))
        {
            UseTarjetaAcceso();
        }
    }

    private void UseTarjetaAcceso()
    {
        if (inventory.HasTarjetaAcceso())
        {
            TarjetaAccesoUsed = true;
            inventory.UseTarjetaAcceso();
            mapEventsManager_.doorsShutEventPhase = 0;
            audioSource.PlayOneShot(doorsOpenSound);
            doorGroups[randomDoorGroup].SetActive(false);
            mapEventsManager_.shutDoorGroup = false;

            // Update the UI
            inventoryUI.RemoveItemFromUI(Inventory.ItemType.TarjetaAcceso);

            Debug.Log("TarjetaAcceso USED TO OPEN DOOR");

            time_Manager_.PauseGameTime(false);
        }
        else
        {
            Debug.Log("NO TarjetaAcceso AVAILABLE");
        }
    }
}

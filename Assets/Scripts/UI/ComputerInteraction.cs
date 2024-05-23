using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerInteraction : MonoBehaviour
{
    [SerializeField] GameObject pickupCanvasPrefab;  // Reference to the Canvas prefab
    [SerializeField] GameObject interactionWindow;  // Reference to the interaction window
    private GameObject canvasInstance;
    private bool isPlayerNearby = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
            ShowPickupCanvas();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
            HidePickupCanvas();
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            OpenInteractionWindow();
        }
    }

    private void ShowPickupCanvas()
    {
        if (pickupCanvasPrefab != null && canvasInstance == null)
        {
            canvasInstance = Instantiate(pickupCanvasPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            canvasInstance.transform.SetParent(transform);  // Make the Canvas a child of the computer
        }
    }

    private void HidePickupCanvas()
    {
        if (canvasInstance != null)
        {
            Destroy(canvasInstance);  // Destroy the Canvas instance
            canvasInstance = null;
        }
    }

    private void OpenInteractionWindow()
    {
        if (interactionWindow != null)
        {
            interactionWindow.SetActive(true);  // Show the interaction window
        }
    }

    public void CloseInteractionWindow()
    {
        if (interactionWindow != null)
        {
            interactionWindow.SetActive(false);  // Hide the interaction window
        }
    }
}

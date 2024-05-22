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
        Debug.Log("Trigger Enter");  // Log for debugging
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player is nearby");  // Log for debugging
            isPlayerNearby = true;
            ShowPickupCanvas();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger Exit");  // Log for debugging
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player left");  // Log for debugging
            isPlayerNearby = false;
            HidePickupCanvas();
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed");  // Log for debugging
            OpenInteractionWindow();
        }
    }

    private void ShowPickupCanvas()
    {
        if (pickupCanvasPrefab != null && canvasInstance == null)
        {
            Debug.Log("Showing pickup canvas");  // Log for debugging
            canvasInstance = Instantiate(pickupCanvasPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            canvasInstance.transform.SetParent(transform);  // Make the Canvas a child of the computer
        }
    }

    private void HidePickupCanvas()
    {
        if (canvasInstance != null)
        {
            Debug.Log("Hiding pickup canvas");  // Log for debugging
            Destroy(canvasInstance);  // Destroy the Canvas instance
            canvasInstance = null;
        }
    }

    private void OpenInteractionWindow()
    {
        if (interactionWindow != null)
        {
            Debug.Log("Opening interaction window");  // Log for debugging
            interactionWindow.SetActive(true);  // Show the interaction window
        }
    }
}

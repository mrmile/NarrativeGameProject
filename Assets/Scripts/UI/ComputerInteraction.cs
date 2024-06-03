using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComputerInteraction : MonoBehaviour
{
    [SerializeField] GameObject pickupCanvasPrefab;  // Reference to the Canvas prefab
    [SerializeField] GameObject interactionWindow;  // Reference to the interaction window
    [SerializeField] GameObject dayPanel;  // Reference to the day panel
    [SerializeField] GameObject nightPanel;  // Reference to the night panel
    [SerializeField] TMP_InputField codeInputField;  // Reference to the code input field
    [SerializeField] TextMeshProUGUI feedbackText;  // Reference to the feedback text
    [SerializeField] Button submitButton;  // Reference to the submit button
    [SerializeField] Button closeButton;  // Reference to the close button
    [SerializeField] Button nightCreateButton;  // Reference to the create button on night panel
    [SerializeField] GameObject itemPrefab;  // Reference to the item prefab to be dropped
    [SerializeField] Transform dropLocation;  // Reference to the location where the item should be dropped
    [SerializeField] string correctCode = "1234";  // The correct code to access the PC

    private GameObject canvasInstance;
    private bool isPlayerNearby = false;
    private Time_Manager timeManager;  // Reference to the time manager

    private void Awake()
    {
        timeManager = FindObjectOfType<Time_Manager>();  // Find the Time_Manager instance

        // Ensure buttons have the correct listeners attached
        if (submitButton != null)
        {
            submitButton.onClick.AddListener(OnSubmitButtonClicked);
        }
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseInteractionWindow);
        }
        if (nightCreateButton != null)
        {
            nightCreateButton.onClick.AddListener(CreateItem);
        }
    }

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
            feedbackText.text = "";  // Clear feedback text
            codeInputField.text = "";  // Clear input field
        }
    }

    public void CloseInteractionWindow()
    {
        Debug.Log("CloseInteractionWindow called.");  // Add this line for debugging
        if (interactionWindow != null)
        {
            Debug.Log("Hiding interaction window.");  // Add this line for debugging
            interactionWindow.SetActive(false);  // Hide the interaction window
            nightPanel.SetActive(false);
            dayPanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("interactionWindow is not assigned.");  // Add this line for debugging
        }
    }

    public void OnSubmitButtonClicked()
    {
        if (codeInputField.text == correctCode)
        {
            feedbackText.text = "Access Granted";
            // Hide the current interaction window
            interactionWindow.SetActive(false);
         

            // Determine which panel to show based on the time
            ShowAppropriatePanel();
        }
        else
        {
            feedbackText.text = "Incorrect Code";
        }
    }

    private void ShowAppropriatePanel()
    {
        if (timeManager != null)
        {
            int currentHour = timeManager.GetTimeGameHours();  // Get the current hour
            
            if (IsDayTime(currentHour))
            {
                dayPanel.SetActive(true);
                nightPanel.SetActive(false);
            }
            else
            {
                dayPanel.SetActive(false);
                nightPanel.SetActive(true);
            }
        }
    }

    private bool IsDayTime(int currentHour)
    {
        // Define day time range (e.g., 6:00 AM to 6:00 PM)
        return currentHour >= 6 && currentHour < 18;
    }

    private void CreateItem()
    {
        if (itemPrefab == null)
        {
            Debug.LogError("Item prefab is not assigned.");
            return;
        }

        if (dropLocation == null)
        {
            Debug.LogError("Drop location is not assigned.");
            return;
        }

        GameObject newItem = Instantiate(itemPrefab, dropLocation.position, Quaternion.identity);
        if (newItem == null)
        {
            Debug.LogError("Failed to instantiate the item.");
        }
        else
        {
            Debug.Log("Item created successfully at " + dropLocation.position);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComputerInteraction : MonoBehaviour
{
    [SerializeField] GameObject pickupCanvasPrefab;
    [SerializeField] GameObject interactionWindow;
    [SerializeField] GameObject dayPanel;
    [SerializeField] GameObject nightPanel;
    [SerializeField] TMP_InputField codeInputField; 
    [SerializeField] TextMeshProUGUI feedbackText; 
    [SerializeField] Button submitButton;
    [SerializeField] Button closeButton;
    [SerializeField] Button nightCreateButton;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform dropLocation;
    [SerializeField] string correctCode = "1234";

    private GameObject canvasInstance;
    private bool isPlayerNearby = false;
    private bool itemCreated = false;
    private Time_Manager timeManager;

    private void Awake()
    {
        timeManager = FindObjectOfType<Time_Manager>(); 

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
            canvasInstance.transform.SetParent(transform);
        }
    }

    private void HidePickupCanvas()
    {
        if (canvasInstance != null)
        {
            Destroy(canvasInstance);
            canvasInstance = null;
        }
    }

    private void OpenInteractionWindow()
    {
        if (interactionWindow != null)
        {
            interactionWindow.SetActive(true);
            feedbackText.text = "";
            codeInputField.text = ""; 
        }
    }

    public void CloseInteractionWindow()
    {
        Debug.Log("CloseInteractionWindow called.");
        if (interactionWindow != null)
        {
            Debug.Log("Hiding interaction window.");
            interactionWindow.SetActive(false);
            nightPanel.SetActive(false);
            dayPanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("interactionWindow is not assigned.");
        }
    }

    public void OnSubmitButtonClicked()
    {
        if (codeInputField.text == correctCode)
        {
            feedbackText.text = "Access Granted";
            interactionWindow.SetActive(false);

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
            int currentHour = timeManager.GetTimeGameHours();
            
            if (IsDayTime(currentHour))
            {
                dayPanel.SetActive(true);
                nightPanel.SetActive(false);
            }
            else
            {
                dayPanel.SetActive(false);
                nightPanel.SetActive(true);

                if (itemCreated)
                {
                    nightCreateButton.interactable = false;
                }
            }
        }
    }

    private bool IsDayTime(int currentHour)
    {
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

        if (!itemCreated) 
        {
            GameObject newItem = Instantiate(itemPrefab, dropLocation.position, Quaternion.identity);
            if (newItem == null)
            {
                Debug.LogError("Failed to instantiate the item.");
            }
            else
            {
                Debug.Log("Item created successfully at " + dropLocation.position);
                itemCreated = true;
                nightCreateButton.interactable = false;
            }
        }
    }
}

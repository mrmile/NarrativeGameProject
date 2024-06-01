using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComputerInteraction : MonoBehaviour
{
    [SerializeField] GameObject pickupCanvasPrefab;
    [SerializeField] GameObject interactionWindow;
    [SerializeField] GameObject newPanel;
    [SerializeField] TMP_InputField codeInputField;
    [SerializeField] TextMeshProUGUI feedbackText;
    [SerializeField] Button submitButton;
    [SerializeField] Button closeButton;
    [SerializeField] string correctCode = "1234";

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
        if (interactionWindow != null)
        {
            interactionWindow.SetActive(false);
        }
    }

    public void OnSubmitButtonClicked()
    {
        if (codeInputField.text == correctCode)
        {
            feedbackText.text = "Access Granted";
            interactionWindow.SetActive(false);
            if (newPanel != null)
            {
                newPanel.SetActive(true);
            }
        }
        else
        {
            feedbackText.text = "Incorrect Code";
        }
    }

    private void Awake()
    {
        if (submitButton != null)
        {
            submitButton.onClick.AddListener(OnSubmitButtonClicked);
        }
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseInteractionWindow);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using DialogueEditor;

public class IrisMenu : MonoBehaviour
{
    [SerializeField] private GameObject notesPanel; // Reference to the notes panel

    // Method to load a scene by name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("Tribunal");
    }

    // Method to toggle the notes panel visibility
    public void ToggleNotesPanel()
    {
        if (notesPanel != null)
        {
            notesPanel.SetActive(!notesPanel.activeSelf); // Toggle the active state of the panel

            if (notesPanel.activeSelf)
                notesPanel.GetComponent<CheckNotes>().FillNoteJournal();

        }
        else
        {
            Debug.LogError("Notes panel is not assigned in the inspector.");
        }
    }

    // Method to close the notes panel
    public void CloseNotesPanel()
    {
        if (notesPanel != null)
        {

            notesPanel.SetActive(false); // Set the panel to inactive
        }
        else
        {
            Debug.LogError("Notes panel is not assigned in the inspector.");
        }
    }
}

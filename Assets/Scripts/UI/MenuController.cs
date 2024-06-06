using UnityEngine;
using DialogueEditor;
public class MenuController: MonoBehaviour
{
    public GameObject menu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !ConversationManager.Instance.DialoguePanel.gameObject.activeSelf)
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
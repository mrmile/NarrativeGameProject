using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CheckNotes : MonoBehaviour
{
    [SerializeField] Char_Inventory player;
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject noteHolder;
    // Start is called before the first frame update


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Char_Inventory>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        noteHolder = GameObject.Find("NoteHolder");
        if (player == null) Debug.LogError("No player inventory available");
    }

    public void FillNoteJournal()
    {
        Debug.Log("Filling journal");
        for (int i = 0; i < noteHolder.transform.childCount; i++)
        {
            Destroy(noteHolder.transform.GetChild(i).gameObject);
        }


        foreach (Inventory.Note note in player.notes)
        {
            GameObject n = Instantiate(inventory.notePrefab);
            n.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = note.identifier;
            n.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = note.content;

            n.transform.parent = noteHolder.transform;
            n.transform.localScale = new Vector3(1, 1, 1);
        }

    
    }


}

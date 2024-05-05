using UnityEngine;

public class MenuController: MonoBehaviour
{
    public GameObject menu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
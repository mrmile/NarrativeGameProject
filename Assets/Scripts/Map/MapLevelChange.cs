using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLevelChange : MonoBehaviour
{
    GameObject player;

    public string sceneName;
    public float scenePosition_X;
    public float scenePosition_Y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            PlayerPosition.newPosition = new Vector2(scenePosition_X, scenePosition_Y);

            SceneManager.LoadScene(sceneName);
        }
    }
}

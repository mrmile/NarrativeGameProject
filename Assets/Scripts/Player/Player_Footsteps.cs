using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Footsteps : MonoBehaviour
{
    public GameObject footstep;
<<<<<<< Updated upstream
    bool isWalking = false;
=======
    public GameObject footstep2;
    public GameObject footstep3;
    public GameObject footstep4;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
<<<<<<< Updated upstream
        isWalking = false;
=======
        footstep2.SetActive(false);
        footstep3.SetActive(false);
        footstep4.SetActive(false);
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) && isWalking == false)
=======
        if (Input.GetKey("w"))
        {
            footsteps();
        }

        if (Input.GetKeyDown("s"))
        {
            footsteps2();
        }

        if (Input.GetKeyDown("a"))
        {
            footsteps3();
        }

        if (Input.GetKeyDown("d"))
        {
            footsteps4();
        }

        if (Input.GetKeyUp("w"))
>>>>>>> Stashed changes
        {
            StopFootsteps();
        }

<<<<<<< Updated upstream
=======
        if (Input.GetKeyUp("s"))
        {
            StopFootsteps2();
        }
>>>>>>> Stashed changes

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
<<<<<<< Updated upstream
            footsteps();

            isWalking = true;
=======
            StopFootsteps3();
        }

        if (Input.GetKeyUp("d"))
        {
            StopFootsteps4();
>>>>>>> Stashed changes
        }
        else
        {
            isWalking = false;
        }
        

    }

    void footsteps()
    {
        footstep.SetActive(true);

    }
    void footsteps2()
    {
        footstep.SetActive(true);

    }
    void footsteps3()
    {
        footstep.SetActive(true);

    }
    void footsteps4()
    {
        footstep.SetActive(true);

    }

    void StopFootsteps()
    {
        footstep.SetActive(false);
    }
    void StopFootsteps2()
    {
        footstep.SetActive(false);
    }
    void StopFootsteps3()
    {
        footstep.SetActive(false);
    }
    void StopFootsteps4()
    {
        footstep.SetActive(false);
    }
}

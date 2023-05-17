using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public GameObject pannelloPausa;

    // Start is called before the first frame update
    void Start()
    {
        Pause(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause(bool pause)
    {
        if (!pause)
        {
            pannelloPausa.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            pannelloPausa.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

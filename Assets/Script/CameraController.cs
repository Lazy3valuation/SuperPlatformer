using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float camSens = 1.25f; //Sensibilità mouse
    float rotX = 0;
    float rotY = 0;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Nasconde il cursore e lo blocca al centro dello schermo (utile per le visuali in prima persona)
    }

    // Update is called once per frame
    void Update()
    {
        FreeMovementCamera();
    }


    public void FreeMovementCamera()
    {
        rotX = rotX + camSens * Input.GetAxis("Mouse X");
        rotY = rotY - camSens * Input.GetAxis("Mouse Y");

        rotY = Mathf.Clamp(rotY, -90, 90); //Blocca la rotazione verticale della camera

        transform.eulerAngles = new Vector3(rotY, rotX, 0.0f); //Applico la rotazione
        player.transform.eulerAngles = new Vector3(0.0f, rotX, 0.0f); //Applico la rotazione
    }

    public void ResetCamera()
    {
        rotX = 0;
        rotY = 0;
    }
}

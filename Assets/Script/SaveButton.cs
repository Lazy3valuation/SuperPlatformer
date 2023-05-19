using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(GameManager.instance.SalvaEdEsci);
        Debug.Log("Aggiornato il pulsante salva ed esci!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

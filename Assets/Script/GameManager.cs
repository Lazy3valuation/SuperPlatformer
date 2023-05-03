using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int livello;

    public static GameManager instance { get; private set; }

    public void SetInstance()
    {
        instance = this;
        //Other variables initialization
        Debug.Log("GameManager instance set.");
        DontDestroyOnLoad(this);
    }

    private void Awake()
    {
        SetInstance();
    }

    // Start is called before the first frame update
    void Start()
    {
        livello = 1;       
    }

    public void IncrementaLivello()
    {
        livello++;
        Debug.Log("Incrementato al livello " + livello);
        Debug.Log(gameObject.name);
    }

    /*
     * Ordine:

    Awake()
    
    Start()

    Update / FixedUpdate

    */
}

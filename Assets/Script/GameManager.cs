using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int livello;
    public int countLivelli;

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
        if (livello < countLivelli)
        {
            livello++;
            string nomeLivello = $"Livello {livello}";
            Debug.Log("Si va al livello " + nomeLivello);
            SceneManager.LoadScene(nomeLivello);
        }
        else
            Debug.Log("You win!!!");
    }

    public void CaricaLivello()
    {
        Debug.Log("Pulsante premuto!");
        SceneManager.LoadScene("Livello 1");
    }

    public void Save()
    {
        Debug.Log("Saving...");
        SceneManager.LoadScene("Menu");
    }
}

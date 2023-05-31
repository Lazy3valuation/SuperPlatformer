using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int countLivelli;
    private GameData save;
    private string pathToSave;
    public List<string> listaLivelli;

    public static GameManager instance { get; private set; }

    public void SetInstance()
    {
        instance = this;
        //Other variables initialization
        Debug.Log("GameManager instance set.");
        pathToSave = "Assets/Saves/";
        DontDestroyOnLoad(this);
    }

    private void Awake()
    {
        SetInstance();
    }

    // Start is called before the first frame update

    public void IncrementaLivello()
    {
        if (save.livello < countLivelli)
        {
            /*
            save.livello++;
            string nomeLivello = $"Livello {save.livello}";
            Debug.Log("Si va al livello " + nomeLivello);
            SceneManager.LoadScene(nomeLivello);
            */
            save.livello++;
            Debug.Log("Si va al livello " + save.livello);
            SceneManager.LoadScene(listaLivelli[save.livello - 1]);
        }
        else
            Debug.Log("You win!!!");
    }

    public void CaricaLivello()
    {
        string salvataggioAStringa = File.ReadAllText(pathToSave + "Salvataggio.json");
        save = JsonUtility.FromJson<GameData>(salvataggioAStringa);
        SceneManager.LoadScene(listaLivelli[save.livello - 1]);
    }

    public void NuovaPartita()
    {
        save = new GameData();
        SalvaDati();
        CaricaLivello();
    }

    public void SalvaEdEsci()
    {
        SalvaDati();
        SceneManager.LoadScene("Menu");
        Destroy(this.gameObject);
    }

    public void SalvaDati()
    {
        Debug.Log("Saving...");
        string salvataggioAStringa = JsonUtility.ToJson(save);
        File.WriteAllText(pathToSave + "Salvataggio.json", salvataggioAStringa);
    }
}

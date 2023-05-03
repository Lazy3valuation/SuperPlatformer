using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rock;
    public Transform posizioneDirezioneForza;
    public float forzaCaduta;

    private float countdown;
    public float secondiPerSpawnRoccia;

    // Start is called before the first frame update
    void Start()
    {
        countdown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        countdown += Time.deltaTime;
        if(countdown > secondiPerSpawnRoccia)
        {
            countdown = 0;
            var newRock = Instantiate(rock, transform.position, rock.transform.rotation, null);

            Vector3 direzioneForza = Vector3.Normalize(posizioneDirezioneForza.position - transform.position);

            newRock.GetComponent<Rigidbody>().AddForce(direzioneForza * forzaCaduta, ForceMode.Impulse);
        }
    }
}

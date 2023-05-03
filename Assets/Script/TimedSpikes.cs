using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpikes : MonoBehaviour
{
    [SerializeField]
    private float secondsToTrigger;
    [SerializeField]
    private float secondsToUntrigger;
    private float cooldown;

    [SerializeField]
    public GameObject spikeContainer;

    public GameObject triggerPosition;
    public GameObject startingPosition;

    public DamageDealer dm;

    // Start is called before the first frame update
    void Start()
    {
        dm.SetActive(true);
        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        if(dm.GetActive())
        {
            //Spike are up, updating to lower them
            if (cooldown >= secondsToUntrigger)
            {
                spikeContainer.transform.position = startingPosition.transform.position;
                cooldown = 0;
                dm.SetActive(false);
                //
            }
        }
        else
        {
            //Spikes are down, updating them to rise them
            if(cooldown >= secondsToTrigger)
            {
                spikeContainer.transform.position = triggerPosition.transform.position;
                cooldown = 0;
                dm.SetActive(true);
                //
            }
        }
    }
}

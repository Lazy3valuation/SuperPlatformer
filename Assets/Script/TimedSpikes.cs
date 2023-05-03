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
    private bool isUp;

    public GameObject triggerPosition;
    public GameObject startingPosition;

    // Start is called before the first frame update
    void Start()
    { 
        isUp = true;
        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        if(isUp)
        {
            //Spike are up, updating to lower them
            if (cooldown >= secondsToUntrigger)
            {
                transform.position = startingPosition.transform.position;
                cooldown = 0;
                isUp = false;
                //
            }
        }
        else
        {
            //Spikes are down, updating them to rise them
            if(cooldown >= secondsToTrigger)
            {
                transform.position = triggerPosition.transform.position;
                cooldown = 0;
                isUp = true;
                //
            }
        }
    }

    public bool GetIsUp()
    {
        return isUp;
    }
}

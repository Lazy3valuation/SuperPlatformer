using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float secondsBeforeChangingDirection;
    private float cooldown;
    private int goingRight;

    // Start is called before the first frame update
    void Start()
    { 
        goingRight = 1;
        cooldown = secondsBeforeChangingDirection / 2;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        if(cooldown >= secondsBeforeChangingDirection)
        {
            cooldown = 0;
            goingRight *= -1;
        }

        transform.position = transform.position + (transform.right * speed * Time.deltaTime * goingRight);
    }
}

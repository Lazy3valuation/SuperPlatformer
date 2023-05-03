using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnWhenFalling : MonoBehaviour
{
    private float bottomBorder;
    void Start()
    {
        bottomBorder = -20;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= bottomBorder)
            Destroy(this.gameObject);
    }
}

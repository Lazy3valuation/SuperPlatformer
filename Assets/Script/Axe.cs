using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("animationSpeed", Random.Range(0.8f, 1.6f));
        animator.Play(0, -1, Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

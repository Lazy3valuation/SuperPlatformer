using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    private bool active;

    public bool GetActive()
    {
        return active;
    }

    public void SetActive(bool _isActive)
    { 
        active = _isActive;
    }
}

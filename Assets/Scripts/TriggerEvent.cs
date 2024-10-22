using System;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public event Action OnActivate;

    
    private void OnTriggerEnter(Collider other)
    {
        OnActivate?.Invoke();
    }
}

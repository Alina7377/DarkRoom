using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivate : MonoBehaviour
{    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<IActivationObjects>(out IActivationObjects activateObject))
        {
            activateObject.OnActivate();
        }
    }    

}

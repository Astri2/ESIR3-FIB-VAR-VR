using System;
using UnityEngine;

public class MovementSelector : MonoBehaviour
{
    public Settings settings;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Passe");
        if (other.gameObject.CompareTag("FreeMoveToggle"))
        {
            settings.enableFreeMove();
        }

        else if (other.gameObject.CompareTag("TeleportationToggle"))
        {
            settings.enableTeleporation();
        }
    }
}

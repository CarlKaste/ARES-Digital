using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Powerband : MonoBehaviour
{
    [SerializeField] private UnityEvent myEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerHand"))
        {
            myEvent.Invoke();
        }
    }
}

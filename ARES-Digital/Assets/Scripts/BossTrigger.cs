using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private Boss bossScript;

    private void OnTriggerEnter(Collider other)
    {
        boss.SetActive(true);
        bossScript.AgroTowardsPlayer();
    }
}

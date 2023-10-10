using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(other != null)
            {
                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                enemy.BurnKill();
            }
        }
    }
}

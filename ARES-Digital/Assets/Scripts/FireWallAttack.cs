using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallAttack : MonoBehaviour
{
    [SerializeField] private float fireDamage;

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

        if (other.gameObject.CompareTag("Boss"))
        {
            Boss boss = other.gameObject.GetComponent<Boss>();
            Animator bossAnimator = other.gameObject.GetComponent<Animator>();

            if (boss != null && bossAnimator != null)
            {
                boss.TakeDamage(fireDamage);
            }
        }
    }
}

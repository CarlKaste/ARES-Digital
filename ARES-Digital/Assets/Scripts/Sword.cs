using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private float swordDamage = 100f;

    private string attackType = "Sword";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if(enemy != null)
            {
                enemy.SwordKill();
            }
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            Animator bossAnimator = collision.gameObject.GetComponent<Animator>();

            if(bossAnimator != null)
            {
                bossAnimator.SetTrigger("Hit");
                Boss bossScript = collision.gameObject.GetComponent<Boss>();
                if(bossScript != null)
                {
                    bossScript.agroTowardsPlayer = false;
                    bossScript.StopAllCoroutines();
                }
            }
        }
    }
}

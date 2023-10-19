using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private float swordDamage = 100f;
    [SerializeField] private GameObject hitSound;

    private string attackType = "Sword";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if(enemy != null)
            {
                hitSound.SetActive(true);
                enemy.SwordKill();
                hitSound.SetActive(false);
            }
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            Animator bossAnimator = collision.gameObject.GetComponent<Animator>();

            if(bossAnimator != null)
            {
                hitSound.SetActive(true);
                bossAnimator.SetTrigger("Hit");
                hitSound.SetActive(false);

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

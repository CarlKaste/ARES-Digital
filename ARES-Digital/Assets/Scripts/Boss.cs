using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;

    private bool agroTowardsPlayer = false;

    public void SwordKill()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        agroTowardsPlayer = false;
        animator.SetTrigger("Die");
    }

    IEnumerator AgroCoroutine()
    {
        animator.SetTrigger("ActivateBoss");
        yield return new WaitForSeconds(18f);
        agroTowardsPlayer = true;
    }

    public void AgroTowardsPlayer()
    {
        StartCoroutine("AgroCoroutine");
    }

    private void Update()
    {
        if (agroTowardsPlayer)
        {
            gameObject.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed);
            this.transform.LookAt(player);
        }
    }
}

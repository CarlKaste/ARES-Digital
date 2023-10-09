using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] Animator animator;

    private bool agroTowardsPlayer = false;

    public void Die()
    {
        agroTowardsPlayer = false;
        animator.SetTrigger("SlashDeath");
    }

    public void WalkTowardsPlayer()
    {
        agroTowardsPlayer = true;
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

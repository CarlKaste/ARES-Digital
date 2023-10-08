using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    private bool seesPlayer = false;

    public void Die()
    {
        this.gameObject.SetActive(false);
    }

    public void WalkTowardsPlayer()
    {
        seesPlayer = true;
    }

    private void Update()
    {
        if (seesPlayer)
        {
            gameObject.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed);
            this.transform.LookAt(player);
        }
    }
}

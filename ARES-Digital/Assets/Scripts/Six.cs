using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Six : MonoBehaviour
{
    private Transform player;
    private bool lookAtPlayer = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    private void Update()
    {
        if(lookAtPlayer)
        {
            this.transform.LookAt(player);
        }
    }

    public void StartLookingAtPlayer()
    {
        lookAtPlayer = true;
    }

    public void StopLookingAtPlayer()
    {
        lookAtPlayer = false;
    }
}

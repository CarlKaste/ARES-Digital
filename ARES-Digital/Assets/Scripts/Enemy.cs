using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private GameObject swordDeathSound;
    [SerializeField] private GameObject fireDeathSound;
    [SerializeField] private GameObject spawnSound;

    private Transform player;
    private EventManager eventManager;
    private bool agroTowardsPlayer = false;
    private Vector3 effectOffset = new Vector3(0, 1.5f, 0);

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
    }

    private void OnEnable()
    {
        AgroTowardsPlayer();
    }

    public void SwordKill()
    {
        StartCoroutine(Killed());
    }

    public void BurnKill()
    {
        StartCoroutine(Burned());
    }

    IEnumerator Burned()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        fireDeathSound.SetActive(true);
        StopCoroutine(AgroCoroutine());
        agroTowardsPlayer = false;
        animator.SetTrigger("BurnDeath");

        if (eventManager.firstWaveActive == true)
            eventManager.UpdateFirstArray();
        if (eventManager.secondWaveActive == true)
            eventManager.UpdateSecondArray();

        yield return new WaitForSeconds(3f);

        Destroy(this.gameObject);
        GameObject effect = Instantiate(deathEffect, this.transform.position + effectOffset, this.transform.rotation);

        yield return new WaitForSeconds(2f);

        Destroy(effect);
    }

    IEnumerator Killed()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        swordDeathSound.SetActive(true);
        StopCoroutine(AgroCoroutine());
        agroTowardsPlayer = false;
        animator.SetTrigger("SlashDeath");

        if (eventManager.firstWaveActive == true)
            eventManager.UpdateFirstArray();
        if (eventManager.secondWaveActive == true)
            eventManager.UpdateSecondArray();

        yield return new WaitForSeconds(3f);

        Destroy(this.gameObject);
        GameObject effect = Instantiate(deathEffect, this.transform.position + effectOffset, this.transform.rotation);

        yield return new WaitForSeconds(2f);

        Destroy(effect);
    }

    IEnumerator AgroCoroutine()
    {
        transform.LookAt(player);
        animator.SetTrigger("Roar");

        yield return new WaitForSeconds(5f);

        animator.SetBool("Walk", true);
        agroTowardsPlayer = true;
    }

    public void AgroTowardsPlayer()
    {
        StartCoroutine(AgroCoroutine());
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExplotion : MonoBehaviour
{
    [SerializeField] private GameObject explotionPrefab;
    [SerializeField] private GameObject fireWallSphereTrigger;
    [SerializeField] private GameObject explosionSound;

    private GameObject[] effects = new GameObject[3];
    private PlaySteps steps;
    private EventManager eventManager;

    public bool hasFiredOnes = true;

    private void Start()
    {
        steps = GameObject.FindGameObjectWithTag("NarrativeStoryManager").GetComponent<PlaySteps>();
        eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
    }

    public void SpawnExplotionEffect()
    {
        explosionSound.SetActive(true);
        effects[0] = Instantiate(explotionPrefab, this.transform.position, this.transform.rotation);
        explosionSound.SetActive(false);

        StartCoroutine(DespawnExplotionEffect());

        if (hasFiredOnes == false)
        {
            hasFiredOnes = true;
            StartCoroutine(DelayEnemySpawnAfterUse());
        }

    }

    IEnumerator DelayEnemySpawnAfterUse()
    {
        steps.PlayStepIndex(5);
        yield return new WaitForSeconds(10);
        eventManager.ActivateSecondEnemyWave();
    }

    IEnumerator DespawnExplotionEffect()
    {
        yield return new WaitForSeconds(1);
        fireWallSphereTrigger.SetActive(false);

        foreach (GameObject e in effects)
        {
            Destroy(e);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExplotion : MonoBehaviour
{
    [SerializeField] private GameObject explotionPrefab;
    [SerializeField] private GameObject fireWallSphereTrigger;

    private GameObject[] effects = new GameObject[3];
    private PlaySteps steps;
    private EventManager eventManager;

    public bool hasFiredOnes = false;

    private void Start()
    {
        steps = GameObject.FindGameObjectWithTag("NarrativeStoryManager").GetComponent<PlaySteps>();
        eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
    }

    public void SpawnExplotionEffect()
    {
        if(hasFiredOnes == false)
        {
            hasFiredOnes = true;
            StartCoroutine(DelayEnemySpawnAfterUse());
        }

        effects[0] = Instantiate(explotionPrefab, this.transform.position, this.transform.rotation);
        StartCoroutine(DespawnExplotionEffect());
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

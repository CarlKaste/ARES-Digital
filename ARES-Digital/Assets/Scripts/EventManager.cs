using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject[] firstEnemyWave;
    [SerializeField] private GameObject[] secondEnemyWave;

    private PlaySteps steps;
    public bool firstWaveActive = false;
    public bool secondWaveActive = false;

    private void Start()
    {
        steps = FindObjectOfType<EventManager>().GetComponent<PlaySteps>();
    }

    private void Update()
    {
        if (firstWaveActive && firstEnemyWave.Length == 0)
        {
            firstWaveActive = false;
            steps.PlayStepIndex(2);
        }

        if (secondWaveActive && secondEnemyWave.Length == 0)
        {
            secondWaveActive = false;
            steps.PlayStepIndex(6);
        }
    }

    public void UpdateFirstArray()
    {
        Destroy(firstEnemyWave[firstEnemyWave.Length - 1]);
    }

    public void UpdateSecondArray()
    {
        Destroy(secondEnemyWave[secondEnemyWave.Length - 1]);
    }

    public void ActivateFirstEnemyWave()
    {
        foreach (GameObject enemy in firstEnemyWave)
        {
            firstWaveActive = true;
            enemy.SetActive(true);
        }
    }

    public void ActivateSecondEnemyWave()
    {
        foreach (GameObject enemy in secondEnemyWave)
        {
            secondWaveActive = true;
            enemy.SetActive(true);
        }
    }
}

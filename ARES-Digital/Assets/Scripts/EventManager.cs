using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject[] firstEnemyWave;
    [SerializeField] private GameObject[] secondEnemyWave;
    [SerializeField] private GameObject[] thirdEnemyWave;

    private PlaySteps steps;
    public bool firstWaveActive = false;
    public bool secondWaveActive = false;
    public bool thirdWaveActive = false;

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

        }

        if (thirdWaveActive && thirdEnemyWave.Length == 0)
        {
            thirdWaveActive = false;

        }
    }

    private void OnEnable()
    {
        if(firstWaveActive)
            Enemy.enemyDies += UpdateFirstArray;

        if(secondWaveActive)
            Enemy.enemyDies += UpdateSecondArray;

        if(thirdWaveActive)
            Enemy.enemyDies += UpdateThirdArray;
    }

    private void OnDisable()
    {
        if (firstWaveActive)
            Enemy.enemyDies -= UpdateFirstArray;

        if (secondWaveActive)
            Enemy.enemyDies -= UpdateSecondArray;

        if (thirdWaveActive)
            Enemy.enemyDies -= UpdateThirdArray;
    }

    public void UpdateFirstArray()
    {
        Destroy(firstEnemyWave[firstEnemyWave.Length]);
    }

    public void UpdateSecondArray()
    {
        Destroy(secondEnemyWave[secondEnemyWave.Length]);
    }

    public void UpdateThirdArray()
    {
        Destroy(thirdEnemyWave[thirdEnemyWave.Length]);
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

    public void ActivateThirdEnemyWave()
    {
        foreach (GameObject enemy in thirdEnemyWave)
        {
            thirdWaveActive = true;
            enemy.SetActive(true);
        }
    }
}

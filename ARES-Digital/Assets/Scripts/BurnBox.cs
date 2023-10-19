using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnBox : MonoBehaviour
{
    [SerializeField] private GameObject corpseFireEffectPrefab;

    private Transform boss;
    private PlaySteps steps;

    private void Start()
    {
        boss = gameObject.GetComponentInParent<Transform>();
        steps = GameObject.FindGameObjectWithTag("NarrativeStoryManager").GetComponent<PlaySteps>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Explosion"))
        {
            Instantiate(corpseFireEffectPrefab, boss.transform);
            steps.PlayStepIndex(3);
        }
    }
}

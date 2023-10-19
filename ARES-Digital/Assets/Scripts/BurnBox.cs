using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnBox : MonoBehaviour
{
    [SerializeField] private GameObject corpseFireEffectPrefab;
    [SerializeField] private Vector3 fireOffset;

    private Transform boss;
    private PlaySteps steps;

    private void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();
        steps = GameObject.FindGameObjectWithTag("NarrativeStoryManager").GetComponent<PlaySteps>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHand"))
        {
            Instantiate(corpseFireEffectPrefab, boss.position + fireOffset, boss.rotation);
            steps.PlayStepIndex(3);
        }
    }
}

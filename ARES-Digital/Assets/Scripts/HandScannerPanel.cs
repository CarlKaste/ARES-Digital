using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScannerPanel : MonoBehaviour
{
    [SerializeField] private GameObject forceField;
    [SerializeField] private GameObject forceFieldSoundSource;
    [SerializeField] private GameObject panelSoundSource;

    IEnumerator ActivationCoroutine()
    {
        panelSoundSource.SetActive(true);
        yield return new WaitForSeconds(2);
        forceFieldSoundSource.SetActive(true);
        yield return new WaitForSeconds(3);
        forceField.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerHand"))
        {
            StartCoroutine(ActivationCoroutine());
        }
    }
}

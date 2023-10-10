using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExplotion : MonoBehaviour
{
    [SerializeField] private GameObject explotionPrefab;
    [SerializeField] private GameObject fireWallSphereTrigger;
    private GameObject[] effects = new GameObject[3];

    public void SpawnExplotionEffect()
    {
        effects[0] = Instantiate(explotionPrefab, this.transform.position, this.transform.rotation);
        StartCoroutine(DespawnExplotionEffect());
    }

    IEnumerator DespawnExplotionEffect()
    {
        yield return new WaitForSeconds(2);
        fireWallSphereTrigger.SetActive(false);

        foreach (GameObject e in effects)
        {
            Destroy(e);
        }
    }
}

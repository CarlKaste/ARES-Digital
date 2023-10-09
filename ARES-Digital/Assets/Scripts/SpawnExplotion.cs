using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExplotion : MonoBehaviour
{
    [SerializeField] private GameObject explotionPrefab;
    private GameObject[] effects;

    IEnumerator DespawnExplotionEffect()
    {
        yield return new WaitForSeconds(2);
        foreach(GameObject e in effects)
        {
            Destroy(e);
        }
    }

    public void SpawnExplotionEffect()
    {
        effects[0] = Instantiate(explotionPrefab, this.transform);
        StartCoroutine("DespawnExplotionEffect");
    }
}

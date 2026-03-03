using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private static WaitForSeconds _waitForSeconds = new(1.8f);
    private bool _canSpawn = true;

    void Start()
    {
        // Begin the spawning routine
        StartCoroutine(StartSpawnRoutine());
    }


    IEnumerator StartSpawnRoutine()
    {
        while (_canSpawn)
        {

            GameObject _blockContainer = ObjectPool.instance.GetBlockContainer();
            if (_blockContainer != null)
            {
                Vector3 blockPosition = new(12f, Random.Range(1.7f, -0.4f), 0);
                _blockContainer.transform.position = blockPosition;
                _blockContainer.SetActive(true);
            }
            yield return _waitForSeconds;
        }
    }
}

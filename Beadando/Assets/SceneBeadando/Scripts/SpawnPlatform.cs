using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private BoxCollider _spawnArea;
    [SerializeField] private float _timeBetweenSpawns;
    public bool _isSpawning = true;

    void Start()
    {
        StartCoroutine(SpawnObjectCoroutine());
    }

    private IEnumerator SpawnObjectCoroutine()
    {
        while (_isSpawning)
        {
            SpawnObject();
            yield return new WaitForSeconds(_timeBetweenSpawns);
        }
    }

    private void SpawnObject()
    {
        var randPos = new Vector3(Random.Range(_spawnArea.bounds.min.x, _spawnArea.bounds.max.x), Random.Range(_spawnArea.bounds.min.y, _spawnArea.bounds.max.y), Random.Range(_spawnArea.bounds.min.z, _spawnArea.bounds.max.z));
        Instantiate(_prefabToSpawn, randPos, Quaternion.identity);
    }
}

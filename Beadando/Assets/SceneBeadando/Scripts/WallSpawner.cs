using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private BoxCollider _spawnArea;
    [SerializeField] private float _timeBetweenSpawns;
    [SerializeField] private float _speed;
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
        Vector3 direction = Vector3.forward;
        Vector3 velocity = _speed * direction;
        var randPos = new Vector3(Random.Range(_spawnArea.bounds.min.x, _spawnArea.bounds.max.x), Random.Range(_spawnArea.bounds.min.y, _spawnArea.bounds.max.y), Random.Range(_spawnArea.bounds.min.z, _spawnArea.bounds.max.z));
        GameObject obj = (GameObject)Instantiate(_prefabToSpawn, randPos, Quaternion.identity);
        obj.GetComponent<Rigidbody>().velocity = velocity;
    }
}

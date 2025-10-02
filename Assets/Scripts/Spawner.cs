using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay = 2f;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private bool _isSpawn = true;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Target _target;

    private Coroutine _spawnRoutine;

    private void Start()
    {
        _spawnRoutine = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (_isSpawn)
        {
            var spawnPosition = new Vector3(_spawnPoint.position.x, _enemyPrefab.transform.localScale.y, _spawnPoint.position.z);

            var enemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.Euler(0, 0, 0));

            enemy.SetTarget(_target);

            yield return wait;
        }
    }
}

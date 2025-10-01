using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay = 2f;
    [SerializeField] private List<SpawnPoint> _spawnPoints = new();
    [SerializeField] private bool _isSpawn = true;

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
            var spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            var enemyPrefab = spawnPoint.EnemyPrefab;
            var spawnPosition = new Vector3(spawnPoint.transform.position.x, enemyPrefab.transform.localScale.y, spawnPoint.transform.position.z);
            var target = spawnPoint.Target;

            var enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0, 0, 0));

            enemy.SetTarget(target);

            yield return wait;
        }
    }
}

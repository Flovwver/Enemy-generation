using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Unity.VisualScripting;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _spawnDelay = 2f;
    [SerializeField] private List<Transform> _spawnPoints = new();
    [SerializeField] private bool _isSpawn = true;

    private Coroutine _spawnRoutine;

    private void Start()
    {
        _spawnRoutine = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (_isSpawn)
        {
            var spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            spawnPoint.position = new Vector3(spawnPoint.position.x, _enemy.transform.localScale.y, spawnPoint.position.z);
            spawnPoint.Rotate(0, Random.Range(-180, 180), 0);
            Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}

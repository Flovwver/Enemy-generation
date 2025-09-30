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
        var wait = new WaitForSeconds(_spawnDelay);

        while (_isSpawn)
        {
            var spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            spawnPoint.position = new Vector3(spawnPoint.position.x, _enemy.transform.localScale.y, spawnPoint.position.z);
            var maxAngle = 360;
            var randomRotation = new Vector3(0, Random.Range(0, maxAngle), 0);
            var randomDirection = Quaternion.Euler(randomRotation) * Vector3.forward;

            _enemy.MoveDirection = randomDirection;

            Instantiate(_enemy, spawnPoint.transform.position, Quaternion.Euler(randomRotation));
            yield return wait;
        }
    }
}

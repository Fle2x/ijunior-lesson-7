using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private float _maxLimitEnemyPositionX = 5;
    private float _spawnInterval = 2;

    private void Start()
    {
        StartCoroutine(SpawnRandomEnemy());
    }
    IEnumerator SpawnRandomEnemy()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-_maxLimitEnemyPositionX, _maxLimitEnemyPositionX), 5, 0);
            Instantiate(_enemyPrefab, spawnPosition, _enemyPrefab.transform.rotation);
            yield return new WaitForSeconds(_spawnInterval); 
        }
    }
}

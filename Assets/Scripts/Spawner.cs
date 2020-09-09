using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float spawnRate = 1f; // "How many times do you want to spawn a new object per second"
    private float _spawnRate;

    public GameObject[] EnemiesToSpawn;

    private Vector2 origin;
    private Vector2 range;
    private Vector2 randomRange;
    private Vector2 randomCoordinate;

    private void Start()
    {
        _spawnRate = spawnRate;

        origin = transform.position;
        range = transform.localScale / 2.0f;
        RerollRandom();
    }


    public Color GizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);
    private void OnDrawGizmos()
    {
        Gizmos.color = GizmosColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    private void Update()
    {
        _spawnRate -= Time.deltaTime;

        if (_spawnRate <= 0)
        {
            Instantiate(EnemiesToSpawn[0], randomCoordinate, Quaternion.identity);

            RerollRandom();
            _spawnRate = spawnRate;
        }
    }

    void RerollRandom()
    {
        randomRange = new Vector2(UnityEngine.Random.Range(-range.x, range.x),
                                  UnityEngine.Random.Range(-range.y, range.y));
        randomCoordinate = origin + randomRange;
    }
}

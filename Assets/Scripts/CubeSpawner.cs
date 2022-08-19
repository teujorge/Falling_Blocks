using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

    public GameObject fallingBlockPrefab;
    public Vector2 secondsBetweenSpawnsMinMax;
    public Vector2 spawnSizeMinMax;
    public float spawnAngleMinMax;
    float nextSpawnTime;
    Vector2 screenHalfSizeWorldUnits;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);

            float spawnAngleDeg = Random.Range(-spawnAngleMinMax, spawnAngleMinMax);
            Quaternion spawnAngle = Quaternion.Euler(Vector3.forward * spawnAngleDeg);

            float spawnPositionX = Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x);
            float spawnPositionY = screenHalfSizeWorldUnits.y + spawnSize;
            Vector2 spawnPosition = new(spawnPositionX, spawnPositionY);

            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, spawnAngle);
            newBlock.transform.localScale = Vector2.one * spawnSize;
        }
    }
}

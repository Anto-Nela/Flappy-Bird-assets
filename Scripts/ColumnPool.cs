using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    private GameObject[] columns;
    public GameObject columnPrefab;
    public int columnPoolSize = 5;
    public float spawnRate = 4f;
    public float columnMin = -1f;
    public float columnMax= 3.5f;
    private UnityEngine.Vector2 objectPoolPosition = new UnityEngine.Vector2(-15f,-25f);
    private float timeSinceLastSpawned;
    private float spawnXPos = 10f;
    private int currentColumn = 0;

    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i <columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, UnityEngine.Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver==false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPos = Random.Range(columnMin,columnMax);
            columns[currentColumn].transform.position = new UnityEngine.Vector2(spawnXPos,spawnYPos);
            currentColumn++;
        }
        if (currentColumn>=columnPoolSize) {
            currentColumn = 0;
        }
    }
}

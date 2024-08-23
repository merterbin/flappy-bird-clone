using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeSpawn : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnTime = 2f;
    private float minY = -0.25f;
    private float maxY = 0.6f;
    private GameObject playerObj;
    private Score score;
    private float timer = 0f;

    void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
        score = playerObj.GetComponent<Score>();
        SpawnPipe();    
    }
    void Update()
    {
        Debug.Log(score.score);
        if (timer >= spawnTime)
        {
            changePipes();
            SpawnPipe();
            timer = 0;
        }
        timer += Time.deltaTime;
    }
    public void SpawnPipe()
    {
        float y = Random.Range(minY, maxY);
        GameObject pipe = GameObject.Instantiate(pipePrefab, new Vector3(transform.position.x, y, transform.position.z), Quaternion.identity);
        Destroy(pipe, 10f);
    }
    public void changePipes()
    {
        if (score.score >= 15)
        {
            pipePrefab = Resources.Load<GameObject>("Prefabs/redPipePrefab");
            maxY = 1.06f;
            minY = 0.15f;
        }
    }
}

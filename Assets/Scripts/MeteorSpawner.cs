using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject[] meteors;
    public float xPosMin;
    public float xPosMax;
    public float spawnYPos;
    public float spawnTime = 2f;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnMeteor());
    }

    private IEnumerator SpawnMeteor()
    {
        int i = Random.Range(0, meteors.Length);
        GameObject meteor = Instantiate(
            meteors[i],
            new Vector3(Random.Range(xPosMin, xPosMax), spawnYPos, -5),
            Quaternion.Euler(0, 0, Random.Range(0, 360))
        );
        float scale = Random.Range(0.8f, 1.1f);
        meteor.transform.localScale = Vector3.one * scale;
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnTime){
            timer = 0;
            StartCoroutine(SpawnMeteor());
        }
    }
}

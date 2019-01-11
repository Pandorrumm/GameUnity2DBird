using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListokSpawner : MonoBehaviour
{
    public GameObject listok;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f; //частота появления
    float nextSpawn = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Time.time>nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-6.5f, 6.5f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(listok, whereToSpawn, Quaternion.identity); //Quaternion.identity -объект выровнен по осям
        }
	}
}

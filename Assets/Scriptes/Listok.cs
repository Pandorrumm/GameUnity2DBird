using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listok : MonoBehaviour
{
    float Napravlenie = 0.1f;
    float speed = 0.0001f;
    float rotateX = 0f;
    float rotateY = 3f;
    float rotateZ = -1f;
    Vector3 direction;
	
	void Start ()
    {
        //Destroy(gameObject, 15F);
        speed = Random.Range(0.0001f, 0.02f);
        rotateX = Random.Range(0f, 2f);
        rotateY = Random.Range(0f, 0.01f);
        rotateZ = Random.Range(0f, 0.01f);
        direction = new Vector3 (Napravlenie, +2);
    }
	
	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position - direction, speed + Time.deltaTime);
        transform.Rotate(new Vector3(rotateX, rotateY));
	}
    
}

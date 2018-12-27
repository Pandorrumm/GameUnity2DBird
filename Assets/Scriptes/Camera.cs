﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Transform who;//за кем двигается камера
    Vector3 position;
    
    private void Start()
    {
        transform.position = who.position;
    }
    void Update()
    {

        transform.position = new Vector3(who.transform.position.x, who.transform.position.y, -10f);// по z не надо
        position = who.position;
        position.z = -10f;//блокируем передвижение по оси
        position.x = -10f;//блокируем передвижение по оси
        transform.position = Vector3.Lerp(transform.position, position, 1f * Time.deltaTime);
    }
}

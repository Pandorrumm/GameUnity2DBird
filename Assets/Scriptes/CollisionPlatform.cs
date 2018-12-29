using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;

    [SerializeField]
    public float waitTime;

    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = 0.5f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            effector.rotationalOffset = 180;
        }
    }
}
	
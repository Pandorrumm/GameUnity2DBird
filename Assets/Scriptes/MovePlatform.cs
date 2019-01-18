using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float speed = 4f;
    bool moveRight = true;

	void Update ()
    {
		if(transform.position.x>2.5f)
        {
            moveRight = false;
        }
        if (transform.position.x <- 2.5f)
        {
            moveRight = true;
        }
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}

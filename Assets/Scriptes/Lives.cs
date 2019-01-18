using UnityEngine;

public class Lives : MonoBehaviour
{
    private Transform[] hearts = new Transform[5]; //массив сердечек
    private Bird bird;

    private void Awake()
    {
        bird = FindObjectOfType<Bird>();

        for(int i=0;i<hearts.Length;i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }

    public void Refresh() //активирует нужное кол-во сердечек
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < bird.Live)
            {
                hearts[i].gameObject.SetActive(true);//активны оставшиеся
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }

}

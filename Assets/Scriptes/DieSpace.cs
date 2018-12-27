using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSpace : MonoBehaviour {

    public GameObject begin;

    private void OnTriggerEnter2D(Collider2D other) //когда игрок попадает в триггер(DieSpace)
    {
        if (other.tag == "Untagged") //если в триггер попадает тот у кого тэк Untagged
        {
            other.transform.position = begin.transform.position; //идём на начальную позицию
        }
    }
}

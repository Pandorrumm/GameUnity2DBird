using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSpace : MonoBehaviour {

    public GameObject begin;
    public GameObject begin1;
    private void OnTriggerEnter2D(Collider2D other) //когда игрок попадает в триггер(DieSpace)
    {
        if (other.tag == "Untagged") //если в триггер попадает тот у кого тэг Untagged
        {
            other.transform.position = begin.transform.position; //идём на начальную позицию
        }

        //if (other.tag == "Listok") //если в триггер попадает тот у кого тэг Listok
        //{
        //    other.transform.position = begin1.transform.position*0.2f; //идём на позицию
            
        //}
    }
}

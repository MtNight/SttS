using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Cof : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Range")
        {
            if (other.transform.parent.tag == "Player")
            {
                other.GetComponent<PlayerBattle>().hp += 150;
                Destroy(this.gameObject);
            }
        }
    }
}


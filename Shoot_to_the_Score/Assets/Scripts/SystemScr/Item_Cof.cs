using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Cof : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Range")
        {
            if (other.transform.parent.tag == "Player" && other.gameObject.GetComponent<PlayerBattle>()!=null)
            {
                other.gameObject.GetComponent<PlayerBattle>().hp += 200;
                Destroy(this.gameObject);
            }
        }
    }
}


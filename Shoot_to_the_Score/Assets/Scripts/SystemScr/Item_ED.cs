using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_ED : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Range")
        {
            if (other.transform.parent.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerBattle>() != null) {
                other.gameObject.GetComponent<PlayerBattle>().hp += 150;
                other.transform.parent.gameObject.GetComponent<PlayerMove>().StartCoroutine("ED");
                Destroy(this.gameObject);
            }
        }
    }
}

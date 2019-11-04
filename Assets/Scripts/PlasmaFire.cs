using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaFire : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(FireLifeSpan());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Temperature>().NearFire(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Temperature>().NearFire(false);
        }
    }

    IEnumerator FireLifeSpan()
    {
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
    }
}
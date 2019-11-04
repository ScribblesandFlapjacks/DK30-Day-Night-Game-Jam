using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasol : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           Temperature temp = collision.gameObject.GetComponent<Temperature>();
           temp.UnderParasol(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Temperature>().UnderParasol(false);
        }
    }
}

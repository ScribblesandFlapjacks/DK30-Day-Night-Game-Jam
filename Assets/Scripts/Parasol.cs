using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasol : MonoBehaviour
{

    float buildingHealth = 100;
    [SerializeField] bool inSun = false;
    float buildingDamageRate = 3f;

    Renderer parasolRenderer;

    private void Start()
    {
        parasolRenderer = gameObject.GetComponent<Renderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           Temperature temp = collision.gameObject.GetComponent<Temperature>();
           temp.UnderParasol(true);
        }
        if (collision.gameObject.layer.Equals(8))
        {
            Debug.Log("in sun");
            inSun = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Temperature>().UnderParasol(false);
        }
        if (collision.gameObject.layer.Equals(8))
        {
            inSun = false;
        }
    }

    private void Update()
    {
        if (buildingHealth < 80)
        {
            byte alpha = (byte)Mathf.Clamp(Mathf.Round((3 * buildingHealth)), 60f, 255f);
            parasolRenderer.material.color = new Color32(255, 255, 255, alpha);
        }

        if (buildingHealth < 1)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (inSun)
        {
            DamageBuilding(buildingDamageRate * Time.deltaTime);
        }
    }

    private void DamageBuilding(float damage)
    {
        buildingHealth -= damage;
    }
}
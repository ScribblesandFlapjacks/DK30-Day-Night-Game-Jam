using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{
    [SerializeField] GameObject playerAvatar;
    [SerializeField] GameObject linkedTunnel;

    bool nextToTunnel = false;
    [SerializeField] float degreeOfPlacement;

    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerAvatar = GameObject.Find("PlayerAvatar");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            nextToTunnel = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            nextToTunnel = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (nextToTunnel)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(GoThroughTunnel());
            }
        }
    }

    public float GetRotation()
    {
        return degreeOfPlacement;
    }

    public void SetRotation(float rotation)
    {
        degreeOfPlacement = rotation;
    }

    public void SetTunnelLink(GameObject tunnel)
    {
        linkedTunnel = tunnel;
    }

    IEnumerator GoThroughTunnel()
    {
        playerAvatar.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        playerAvatar.transform.position = linkedTunnel.transform.position;
        playerAvatar.transform.rotation = linkedTunnel.transform.rotation;
        playerAvatar.gameObject.SetActive(true);
        playerMovement.SetDegree(linkedTunnel.GetComponent<Tunnel>().GetRotation());
    }
}
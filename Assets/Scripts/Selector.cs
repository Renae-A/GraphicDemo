using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selector : MonoBehaviour {

    public Material transparent;
    public Material rim;


    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
            this.GetComponent<Renderer>().material = rim;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            if (other.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Combat"))
            {
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
            this.GetComponent<Renderer>().material = transparent;
    }
}

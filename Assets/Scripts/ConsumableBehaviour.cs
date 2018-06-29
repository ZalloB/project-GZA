using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumablesBehaviour : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (this.gameObject.tag.Equals("AmmoBox"))
            {
                other.gameObject.GetComponent<PlayerBehaviour>().RefillAmmo();
            }
            else
            {
                other.gameObject.GetComponent<PlayerBehaviour>().RefillHealth();
            }

            Destroy(this.gameObject);
        }
    }
}
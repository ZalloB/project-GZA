using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour {

    public int health;



	void Start () {
        health = 10;

	}

    public void Hit()
    {
        health--;

        if (health <= 0)
        {
            StartCoroutine(DyingSequence());
        }
        else
        {
            //TODO damage sound
            //TODO damage animation
        }
    }

    IEnumerator DyingSequence()
    {
        //TODO dyingsound
        //TODO dyingAnimation
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }

}

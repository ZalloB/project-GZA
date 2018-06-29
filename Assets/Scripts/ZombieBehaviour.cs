using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour {

    private int health;
    public GameObject[] loot;

    void Start () {
        health = 100;

	}

    public void Hit(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Instantiate(loot[UnityEngine.Random.Range(0, loot.Length)], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            StartCoroutine(DyingSequence());
        }
        else
        {
            //TODO damage sound
            //TODO damage animation
        }
    }

    public void Kill(){
        StartCoroutine(DyingSequence());
    }

    IEnumerator DyingSequence()
    {
        //TODO dyingsound
        //TODO dyingAnimation
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }

}

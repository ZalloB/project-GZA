﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour {

    private int health;
    public GameObject[] loot;
    public AudioSource audioSource;
    public AudioClip hit;
    public AudioClip die;

    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        health = 100;

	}

    public void Hit(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Instantiate(loot[Random.Range(0, loot.Length)], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            StartCoroutine(DyingSequence());
        }
        else
        {
            audioSource.PlayOneShot(hit, 0.7f);
            //TODO damage animation
        }
    }

    public void Kill(){
        StartCoroutine(DyingSequence());
    }

    IEnumerator DyingSequence()
    {
        audioSource.PlayOneShot(die, 0.7f);
        //TODO dyingAnimation
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Car"))
            Kill();
    }
}

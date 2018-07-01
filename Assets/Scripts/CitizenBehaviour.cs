using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CitizenBehaviour : MonoBehaviour {

    private GameObject nearestZombie;
    private GameObject[] enemies;
    private float distance;
    private Transform startTransform;
    private NavMeshAgent myNMAgent;
    public GameObject zombie;
    private bool isZombified;

    public AudioSource audiosource;
    public AudioClip hurt;
    public AudioClip help;
    public bool yelling;


	void Start () {

        audiosource = gameObject.GetComponent<AudioSource>();
        isZombified = false;
        yelling = false;
        myNMAgent = this.GetComponent<NavMeshAgent>();

    }

    public void Hit()        //The Citizen gets hit by a bullet or car and dies.
    {
        //TODO Add Score (?)
        StartCoroutine(DyingSequence());
    }

    public void Zombified() //Zombie bites a citizen.
    {

        Destroy(this.gameObject);
        if (!isZombified)
        Instantiate(zombie, this.transform.position, this.transform.rotation);

        isZombified = true;


    }

    public void Flee()
    {
        nearestZombie = getClosestEnemy();

        if (!yelling)
        StartCoroutine(HelpMeSound());

        startTransform = transform;
        transform.rotation = Quaternion.LookRotation(transform.position - nearestZombie.transform.position);
        Vector3 runTo = transform.position + transform.forward;

        NavMeshHit hit;
        NavMesh.SamplePosition(runTo, out hit, 5, 1 << NavMesh.GetAreaFromName("Default"));
        transform.position = startTransform.position;
        transform.rotation = startTransform.rotation;

        myNMAgent.SetDestination(hit.position);


    }


    IEnumerator HelpMeSound()
    {
        audiosource.PlayOneShot(help, 0.7f);

        yelling = true;
        yield return new WaitForSeconds(2.0f);
        yelling = false;
    }

    private GameObject getClosestEnemy()
    {
        distance = Mathf.Infinity;
        enemies = GameObject.FindGameObjectsWithTag("Zombie");
        GameObject chosenZombie = null;

        foreach(GameObject z in enemies)
        {
            float dist = Vector3.Distance(z.transform.position, transform.position);

            if(dist < distance)
            {
                chosenZombie = z;
            }

        }

        return chosenZombie;
    }



    IEnumerator DyingSequence()
    {
        audiosource.PlayOneShot(hurt, 0.7f);

        //TODO Dying animation
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Bullet") || (other.gameObject.tag.Equals("Car")))
            Hit();

        if (other.gameObject.tag.Equals("Zombie"))
            Zombified();
    }

}

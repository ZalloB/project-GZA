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

	// Use this for initialization
	void Start () {

        myNMAgent = this.GetComponent<NavMeshAgent>();

    }

    public void Hit()        //The Citizen gets hit by a bullet or car and dies.
    {
        //TODO Add Score (?)
        StartCoroutine(DyingSequence());
    }

    public void Zombified() //Zombie bites a citizen.
    {
        StartCoroutine(DyingSequence());
        //TODO Instantiate a zombie in this position.
    }

    public void Flee()
    {
        Debug.Log("Corre pequeño, HUYE");
        nearestZombie = getClosestEnemy();


        startTransform = transform;
        transform.rotation = Quaternion.LookRotation(transform.position - nearestZombie.transform.position);
        Vector3 runTo = transform.position + transform.forward;

        NavMeshHit hit;
        NavMesh.SamplePosition(runTo, out hit, 5, 1 << NavMesh.GetAreaFromName("Default"));
        transform.position = startTransform.position;
        transform.rotation = startTransform.rotation;

        myNMAgent.SetDestination(hit.position);


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
        //TODO DyingSound
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

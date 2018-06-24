using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarBehaviour : MonoBehaviour {

    public NavMeshAgent navMeshAgent;
    public bool isPlayerinside;


	// Use this for initialization
	void Start () {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        isPlayerinside = false;


		
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayerinside)
        {
            //Player car controlls
        }
		
	}


    public void PlayerEnters()
    {
        isPlayerinside = true;
        navMeshAgent.enabled = false;
    }

    public void PlayerExits()
    {
        isPlayerinside = false;
        navMeshAgent.enabled = true;
    }

    public void Brake() //Car stops if there is something ahead.
    {

    }
}

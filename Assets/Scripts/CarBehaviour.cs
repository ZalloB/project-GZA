using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarBehaviour : MonoBehaviour {

    public NavMeshAgent navMeshAgent;
    public bool isPlayerinside;
    public Camera camera;
    public GameObject player;
    float speed = 10f;

    public float acceleration;
    public float maxSpeed = 40;

	// Use this for initialization
	void Start () {


        if (this.gameObject.tag.Equals("Car"))
        {
            camera = this.gameObject.GetComponentInChildren<Camera>();
            camera.enabled = false;
        }


        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        isPlayerinside = false;


		
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayerinside)
        {
            transform.Translate(0f, 0f,speed * Input.GetAxis("Vertical") * Time.deltaTime);
            Debug.Log("hue");

            if (Input.GetKey(KeyCode.A))
                transform.Rotate(Vector3.up * speed * Time.deltaTime * 20);

            if (Input.GetKey(KeyCode.D))
                transform.Rotate(-Vector3.up * speed * Time.deltaTime * 20);



            if (Input.GetKey(KeyCode.Q))
                PlayerExits();


        }
		
	}


    public void forward()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (acceleration < maxSpeed) { }
               
        }

    }

    public void PlayerEnters()
    {
        isPlayerinside = true;
        navMeshAgent.enabled = false;
        camera.enabled = true;
    }

    public void PlayerExits()
    {
        isPlayerinside = false;
        navMeshAgent.enabled = true;
        camera.enabled = false;
        Instantiate(player,new Vector3(this.gameObject.transform.position.x + 2, this.gameObject.transform.position.y, this.gameObject.transform.position.z), this.gameObject.transform.rotation);

    }

    public void Brake() //Car stops if there is something ahead.
    {

    }
}

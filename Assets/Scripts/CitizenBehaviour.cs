using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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

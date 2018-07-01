using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ManagePlayersData : NetworkBehaviour {

    public GameObject MyCamera;

	// Use this for initialization
	void Start () {
        if (!isLocalPlayer)
        {
            return;
        }

        MyCamera.SetActive(true);
        this.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
    }
}

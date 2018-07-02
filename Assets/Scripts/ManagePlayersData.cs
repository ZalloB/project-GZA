using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ManagePlayersData : NetworkBehaviour {

    public GameObject MyCamera;
    public Text bulletText;
    public Image healthBar;

	// Use this for initialization
	void Start () {
        if (!isLocalPlayer)
        {
            return;
        }

        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Image>();
        bulletText = GameObject.FindGameObjectWithTag("BulletText").GetComponent<Text>();
        this.GetComponent<PlayerBehaviour>().health = healthBar;
        this.GetComponent<PlayerBehaviour>().ammoText = bulletText;

        MyCamera.SetActive(true);
        //this.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
    }
}

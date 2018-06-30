using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public float life;

    private int magazine;
    private int maxMagazine;
    private int totalAmmo;
    private int damage;
    public new Camera camera;
    public AudioSource audioSource;

    public AudioClip reload;
    public AudioClip noAmmo;
    public AudioClip shot;
    public AudioClip melee;


	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        life = 100;
        magazine = 30;
        maxMagazine = 30;
        totalAmmo = 60;
        damage = 10;

	}

	void Update () {
        Shoot();
        Reload();
        Melee();
    }


    public void Hit()
    {
        life -= 10;
        if(life <= 0)
        {
            //Die.
        }else
        {
            //TODO  sound of damage
            //TODO animation damage

        }
    }

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            int layerMask = 1 << 8;
            layerMask = ~layerMask;

            if (magazine > 0)
            {
                audioSource.PlayOneShot(shot, 0.7f);
                magazine--;
                StartCoroutine(RangedAttack());

                Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.tag.Equals("Zombie") || hit.collider.gameObject.tag.Equals("Citizen")))
                {
                    if (hit.collider.gameObject.tag.Equals("Citizen"))
                        hit.collider.gameObject.GetComponent<CitizenBehaviour>().Hit();
                    if (hit.collider.gameObject.tag.Equals("Zombie"))
                        hit.collider.gameObject.GetComponent<ZombieBehaviour>().Hit(damage);
                }
            }else
            {
                audioSource.PlayOneShot(noAmmo, 0.7f);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (other.gameObject.tag.Equals("Citizen"))
            {
                other.gameObject.GetComponent<CitizenBehaviour>().Hit();
            }else if (other.gameObject.tag.Equals("Zombie"))
            {
                other.gameObject.GetComponent<ZombieBehaviour>().Kill();
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.tag.Equals("Car"))
            {
                other.gameObject.GetComponent<CarBehaviour>().PlayerEnters();
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Shotgun"))
        {
            //TODO añadir objeto escopeta al modelo.
            magazine = 2;
            maxMagazine = 2;
            totalAmmo = 6;
            damage = 100;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("Pistol"))
        {
            //TODO añadir objeto pistola al modelo
            magazine = 6;
            maxMagazine = 6;
            totalAmmo = 18;
            damage = 20;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("SMG"))
        {
            //TODO añadir objeto SMG al modelo
            magazine = 30;
            maxMagazine = 30;
            totalAmmo = 60;
            damage = 10;
        }
    }

    private void Melee()
    {
        if (Input.GetMouseButtonDown(1))
        {
            audioSource.PlayOneShot(melee, 0.7f);
            //TODO melee animation
        }
    }


    public void Reload()
    {
        if (Input.GetKeyDown("r"))
        {
            if (magazine < maxMagazine  && totalAmmo > 0)
            {
                audioSource.PlayOneShot(reload, 0.7f);
                totalAmmo += magazine;
                magazine = 0;
                if (totalAmmo <= maxMagazine)
                {
                    magazine = totalAmmo;
                    totalAmmo = 0;
                }
                else
                {
                    totalAmmo -= maxMagazine;
                    magazine = maxMagazine;
                }
            }
        }
    }

    public void RefillAmmo()
    {
        totalAmmo += maxMagazine;
    }

    public void RefillHealth()
    {
        life += 20;
        if (life > 100)
            life = 100;

    }

    IEnumerator RangedAttack()
    {
        //TODO Start animation
        yield return new WaitForSeconds(2.0f);
        //TODO end animation
    }

}

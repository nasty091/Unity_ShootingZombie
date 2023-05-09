using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    internal int damge = 1;
    public float fireTime = 0.2f;
    private float lastFireTime;
    public Animator anim;

    //public GameObject smoke;
    //public GameObject gunHead;

    private AudioSource audioSource;
    public float playerHealth = 10f;
    internal float playerCurrentHealth = 10f;
    private GameObject gameController;
    public AudioClip playerDeath;

    public Slider healthBar;

    public GameObject gunSound;

    private GameObject blackPistol;

    void Start()
    {
        UpdateFireTime();
        anim = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        //playerHealth = playerCurrentHealth;
        
        //Handle HealthBar
        healthBar.maxValue= playerHealth;
        healthBar.value = playerCurrentHealth;
        healthBar.minValue = 0;

        //Gun Sound Effects
        gunSound = GameObject.FindGameObjectWithTag("Pistol");

    }


    void UpdateFireTime()
    {
        lastFireTime = Time.time;
    }

    void SetFireAnim(bool isFire)
    {
        anim.SetBool("isShoot", isFire);
    }

    void Fire()
    {
        if (Time.time > lastFireTime + fireTime)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag.Equals("Zombie") || hit.transform.tag.Equals("Boss"))
                {
                    SetFireAnim(true);
                    gunSound.gameObject.GetComponent<AudioSource>().Play();
                    hit.transform.gameObject.GetComponent<ZombieController>().GetHit(damge);
                }
   
                else if (hit.transform.tag.Equals("Wall") || hit.transform.tag.Equals("Ground"))
                {
                    SetFireAnim(true);
                    gunSound.gameObject.GetComponent<AudioSource>().Play();
                }
            }
            UpdateFireTime();
        }
        else
        {
            SetFireAnim(false);
        }
    }

    //void InsSmoke()
    //{
    //    GameObject sm = Instantiate(smoke, gunHead.transform.position, gunHead.transform.rotation);
    //    Destroy(sm, 0.5f);
    //}

    int lostPlayerHealth = 0;
    public void GetHit(int damge)
    {
        playerCurrentHealth -= damge;
        lostPlayerHealth += 1;

        healthBar.value = playerCurrentHealth;

        if(lostPlayerHealth == 5)
        {
            audioSource.Play();
            lostPlayerHealth = 0;
        }
        if (playerCurrentHealth <= 0)
        {
            Die();
        }
    }


    //IEnumerator PlayerScream()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(6);
    //        audioSource.Play();
    //        playerCurrentHealth -= damge;
    //    }
    //}

    public void Die()
    {
        audioSource.clip = playerDeath;
        audioSource.Play();
        gameController.GetComponent<GameController>().EndGame();

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
        //playerHealth = playerCurrentHealth;

    }
}

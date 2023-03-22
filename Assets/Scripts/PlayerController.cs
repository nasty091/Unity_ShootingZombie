using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int damge = 1;
    public float fireTime = 0.3f;
    private float lastFireTime;
    public Animator anim;

    //public GameObject smoke;
    //public GameObject gunHead;

    private AudioSource audioSource;
    public float playerHealth = 10f;
    private float playerCurrentHealth = 10f;
    private GameObject gameController;
    public AudioClip playerDeath;

    // Start is called before the first frame update
    void Start()
    {
        UpdateFireTime();
        anim = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
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
                if (hit.transform.tag.Equals("Zombie"))
                {
                    SetFireAnim(true);
                    //InsSmoke();
                    hit.transform.gameObject.GetComponent<ZombieController>().GetHit(damge);
                }
                else if (hit.transform.tag.Equals("Wall") || hit.transform.tag.Equals("Ground"))
                {
                    //InsSmoke();
                    SetFireAnim(true);
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

    public void GetHit(int damge)
    {
        audioSource.Play();
        playerCurrentHealth -= damge;

        if(playerCurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        audioSource.clip = playerDeath;
        audioSource.Play();
        gameController.GetComponent<GameController>().EndGame();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
    }
}

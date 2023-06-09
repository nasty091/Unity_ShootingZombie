using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public int zombieHealth = 3;
    private Animator anim;
    protected bool isShooten;
    public float shootTime = 0.5f;

    public bool isAttack = false;
    private float attackTime = 3.5f;
    public float lastAttackTime = 0.0f;

    private AudioSource audioSource;
    public AudioClip zombieDeathSound;

    private GameObject player;
    private int zombieDamge = 1;
    private GameObject gameController;

    private PlayerController playerController;
    public bool IsShooten
    {
        get { return isShooten; }
        set { 
            isShooten = value;
            ShootenAnim(isShooten);
            UpdateShootenTime();
        }
    }

    private float lastShootenTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        IsShooten = false;
        anim.SetBool("isDead", false);
        audioSource = gameObject.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    protected void UpdateShootenTime()
    {
        lastShootenTime = Time.time;
    }

    void UpdateAttackTime()
    {
        lastAttackTime = Time.time;
    }
    protected void ShootenAnim(bool isShooten)
    {
        anim.SetBool("isShooten", isShooten);
    }

    void AttackAnim(bool isAttack)
    {
        anim.SetBool("isAttack", isAttack);
    }

    public void GetHit(int damge)
    {
        IsShooten = true;
        zombieHealth -= damge;
        audioSource.Play();

        if (zombieHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        audioSource.clip = zombieDeathSound;
        audioSource.Play();

        anim.SetBool("isDead", true);
        Destroy(gameObject, 1.0f);

        gameController.GetComponent<GameController>().GetPoint(1);
    }

    public float delayTime = 5.0f;
    void Attack()
    {
        if(Time.time >= lastAttackTime + attackTime)
        {
            StartCoroutine(DelayPlayerGetHit());
            //player.GetComponent<PlayerController>().GetHit(zombieDamge);

            //player.GetComponent<PlayerController>().GetHit(zombieDamge);
            AttackAnim(true);
            UpdateAttackTime();
            delayTime = 0.0f;
        }
        else
        {
            AttackAnim(false);
        }
    }

    IEnumerator DelayPlayerGetHit()
    {
        yield return new WaitForSeconds(delayTime);
        player.GetComponent<PlayerController>().GetHit(zombieDamge);
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsShooten && Time.time > lastShootenTime + shootTime)
        {
            IsShooten = false;           
        }
        if (isAttack)
        {
            Attack();
        }
    }
}

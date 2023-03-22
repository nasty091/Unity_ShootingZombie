using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private int zombieHealth = 3;
    private Animator anim;
    private bool isShooten;
    public float shootTime = 0.5f;
    public bool isAttack = false;
    public float attackTime = 1f;
    public float lastAttackTime = 0f;

    private AudioSource audioSource;
    public AudioClip zombieDeathSound;
    private GameObject player;
    private int zombieDamge = 1;

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
    }

    void UpdateShootenTime()
    {
        lastShootenTime = Time.time;
    }

    void UpdateAttackTime()
    {
        lastAttackTime = Time.time;
    }
    void ShootenAnim(bool isShooten)
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
        Destroy(gameObject, 1.5f);
    }

    void Attack()
    {
        if(Time.time >= lastAttackTime + attackTime)
        {
            player.GetComponent<PlayerController>().GetHit(zombieDamge);
            AttackAnim(true);
            UpdateAttackTime();
        }
        else
        {
            AttackAnim(false);
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public float moveSpeed;
    public float minMoveSpeed = 0.05f;
    public float maxMoveSpeed = 0.1f;
    public GameObject player;
    public GameObject lookAtTarget;
    public float attackRang = 1f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lookAtTarget = GameObject.FindGameObjectWithTag("LookTarget");
        UpdateMoveSpeed();
    }

    //Random speed
    void UpdateMoveSpeed()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    //Zombie move to player
    void Move()
    {
        if(player == null || lookAtTarget == null)
        {
            return;
        }

        if(Vector3.Distance(transform.position, player.transform.position) > attackRang)
        {
            transform.LookAt(lookAtTarget.transform.position);
            transform.position = Vector3.Lerp(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("isIdle", true);
            gameObject.GetComponent<ZombieController>().isAttack = true;
            gameObject.GetComponent<MoveToPlayer>().enabled = false;
        }
        
        //transform.LookAt(player.transform.position);
        //transform.Translate(transform.position * moveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}

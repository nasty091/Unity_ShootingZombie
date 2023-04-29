using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigZomController : ZombieController
{
    // Start is called before the first frame update

    public bool IsShooten
    {
        get { return IsShooten; }
        set
        {
            IsShooten= value;
            ShootenAnim(isShooten);
            UpdateShootenTime();
        }
    }

    void Start()
    {
        zombieHealth = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

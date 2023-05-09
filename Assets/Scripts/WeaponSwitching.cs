using System;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    private int selectedWeapon = 0;
    private GameObject gameController;

    private float startGameTime;
    private float startUnlockGunTime = 63;
    private void Start()
    {
        SelectWeapon();
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    private void Update()
    {
        int preSelectedWeapon = selectedWeapon;
        if(Time.time >= startGameTime + startUnlockGunTime)
        {
            if (Input.GetMouseButton(1))
            {
                if (selectedWeapon == 0)
                {
                    selectedWeapon = 1;
                }
                else
                {
                    selectedWeapon = 0;
                }
            }
            if (preSelectedWeapon != selectedWeapon)
            {
                SelectWeapon();
                GunDamge();
                GunSound();
            }
        }
    }

    private void GunDamge()
    {
        if(selectedWeapon == 0)
        {
            gameObject.GetComponent<PlayerController>().damge = 1;
        }
        else
        {
            gameObject.GetComponent<PlayerController>().damge = 3;
        }
    }

    private void GunSound()
    {
        if (selectedWeapon == 0)
        {
            gameObject.GetComponent<PlayerController>().gunSound = GameObject.FindGameObjectWithTag("Pistol");
        }
        else
        {
            gameObject.GetComponent<PlayerController>().gunSound = GameObject.FindGameObjectWithTag("BlackPistol");
        }
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}

using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    private ProjectileWeapon projectileWeapon;
    void Start()
    {
        projectileWeapon = GetComponent<ProjectileWeapon>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(projectileWeapon.WeaponAmmo.CurrentAmmoAvailable);
    }
}

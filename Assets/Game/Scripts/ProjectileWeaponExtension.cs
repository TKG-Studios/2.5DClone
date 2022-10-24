using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using System;

namespace MoreMountains.CorgiEngine
{
    public class ProjectileWeaponExtension : ProjectileWeapon
    {
        [MMInspectorGroup("Resource Management", true, 12)]
        public bool usesMana;

        protected override void WeaponUse()
        {
            DetermineSpawnPosition();

            if (usesMana && GetComponentInParent<Mana>().CurrentMana > 0)
            {
              
                 for (int i = 0; i < ProjectilesPerShot; i++)
                    {
                        SpawnProjectile(SpawnPosition, i, ProjectilesPerShot, true);
                    }
                
        

            } else if (GetComponentInParent<Mana>().CurrentMana <= 0)
            {
                Debug.Log("not enough mana");
            }
        }
    }

}

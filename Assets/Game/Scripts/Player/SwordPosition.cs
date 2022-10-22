using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using MoreMountains.CorgiEngine;

public class SwordPosition : MonoBehaviour
{
   public GameObject sword;
   private Health healthScript;



    void Start()
    {
        SetSwordPosition();
        healthScript = GetComponentInParent<Health>();
       
    }



    public void SetSwordPosition()
    {
       sword.transform.eulerAngles = new Vector3(
       sword.transform.eulerAngles.x,
        sword.transform.eulerAngles.y,
        sword.transform.eulerAngles.z + 90);
    }


    


}

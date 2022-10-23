using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;

public class InventoryTargetTransform : MonoBehaviour
{
    Transform playerTransform;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        GetComponent<Inventory>().TargetTransform = playerTransform;
    }
}
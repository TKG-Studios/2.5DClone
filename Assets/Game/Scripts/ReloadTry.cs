using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.InventoryEngine;
using System.Runtime.CompilerServices;

public class ReloadTry : MonoBehaviour
{

    public InventoryItem currentItem;

    private CharacterInventoryExtension characterInventory;


    private void Start()
    {
        characterInventory = GetComponent<CharacterInventoryExtension>();
    }

    private void Update()
    {
        Inventory weaponInventory = characterInventory.WeaponInventory;
        //weaponInventory.Content[0].
    }
}

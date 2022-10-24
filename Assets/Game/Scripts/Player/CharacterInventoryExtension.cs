using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.InventoryEngine;
public class CharacterInventoryExtension : CharacterInventory
{
    public override void OnMMEvent(MMInventoryEvent inventoryEvent)
    {
        base.OnMMEvent(inventoryEvent);

        if (WeaponInventory.Content[0] != null)
        {
            WeaponInventory.Content[0].Equip(PlayerID);
        }
    }
    

}

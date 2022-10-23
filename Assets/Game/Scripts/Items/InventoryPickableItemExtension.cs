using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.InventoryEngine;
using MoreMountains.Feedbacks;
using MoreMountains.CorgiEngine;
using System;

public class InventoryPickableItemExtension : InventoryPickableItem
{

    private InventoryItem currentlyHeldItem;

  

    private void Update() //TO DO --- CHANGE THIS FROM WORKING ON TICK
    {
       
    }
    public override bool Pickable()
    {
        base.Pickable();

        if (_targetInventory.Content != null)
        {
            if (_targetInventory.Content.Length > 0)
            {
                currentlyHeldItem = _targetInventory.Content[0];
            }
        }

     

        if (_targetInventory.NumberOfFreeSlots == 0 && currentlyHeldItem.ItemName != Item.ItemName)
        {
            _targetInventory.DropItem(currentlyHeldItem, 0);
            Pick(Item.TargetInventoryName);
        }
        return true;
    }

  
}

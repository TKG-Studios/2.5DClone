using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.InventoryEngine;
using MoreMountains.Feedbacks;
using MoreMountains.CorgiEngine;

public class InventoryPickableItemExtension : InventoryPickableItem
{

    private InventoryItem currentlyHeldItem;


    private void Update()
    {
        if (_targetInventory.Content != null)
        {
            currentlyHeldItem = _targetInventory.Content[0];
        }
    }
    public override bool Pickable()
    {
        base.Pickable();


        if (_targetInventory.NumberOfFreeSlots == 0)
        {
            StartCoroutine(DropPreviousItem());
        }
        return true;
    }

  
    IEnumerator DropPreviousItem()
    {
        _targetInventory.DropItem(currentlyHeldItem,0);
        yield return new WaitForSeconds(.5f);
        Pick(Item.TargetInventoryName);
    }
}

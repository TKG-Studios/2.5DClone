using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MoreMountains.CorgiEngine
{
    /// <summary>
    /// Gives mana  to the player who collects it
    /// </summary>
    [AddComponentMenu("Corgi Engine/Items/Manapack")]
    public class ManaPack : PickableItem
{
    /// the amount of mana to give the player when collected
    [Tooltip("the amount of manato give the player when collected")]
    public float ManaToGive = 10f;

    /// <summary>
    /// What happens when the object gets picked
    /// </summary>
    protected override void Pick(GameObject picker)
    {
        Mana characterMana = _pickingCollider.GetComponent<Mana>();
        // else, we give mana to the player
        characterMana.GetMana(ManaToGive, gameObject);
    }
}
}

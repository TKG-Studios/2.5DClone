using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using UnityEngine.PlayerLoop;

namespace MoreMountains.CorgiEngine
{

    public struct ManaChangeEvent
    {
        public Mana UsedMana;
        public float NewMana;

        public ManaChangeEvent(Mana usedMana, float newMana)
        {
            UsedMana = usedMana;
            NewMana = newMana;
        }

        static ManaChangeEvent e;
        public static void Trigger(Mana usedMana, float newMana)
        {
            e.UsedMana = usedMana;
            e.NewMana = newMana;
            MMEventManager.TriggerEvent(e);
        }

    }
    /// <summary>
    /// This class manages the players mana, pilots it's mana bar and handles what happens when it uses mana. This class is modeled after the corgi engine Health class
    /// </summary>

    [AddComponentMenu("Corgi Engine/Character/Core/Mana")]
    public class Mana : MonoBehaviour
    {
        [MMInspectorGroup("Status", true, 1)]
        [MMReadOnly]
        [Tooltip("the current mana level of the player character")]
        public float CurrentMana;

        [MMReadOnly]
        [Tooltip("If this is true, the player won't lose mana at the moment")]
        public bool TemporarilyInfiniteMana = false;

        [MMInformation(
            "Add this component to an object and it'll have mana that can be consumed by inventory level objects,",
            MoreMountains.Tools.MMInformationAttribute.InformationType.Info, false)]

        [MMInspectorGroup("Mana", true, 2)]

        //Initial Mana
        [Tooltip("the initial amount of mana the character has")]
        public float InitialMana = 10;
        //Maximum Mana
        [Tooltip("the maximum amount of mana the player can have")]
        public float MaximumMana = 10;

        //if true, the player can't lose mana
        [Tooltip("if this is true, the player can't lose mana")]
        public bool InfiniteMana = false;


        protected virtual void Start()
        {
            Initialization();
        }

        protected virtual void Initialization()
        {
            CurrentMana = InitialMana;
        }

    }
}
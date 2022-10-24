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


        protected Vector3 _initialPosition;
        protected Color _initialColor;
        protected Renderer _renderer;
        protected Character _character;
        protected CharacterPersistence _characterPersistence = null;
        protected bool _initialized = false;
        protected AutoRespawn _autoRespawn;
        protected Animator _animator;
        protected MMHealthBar _manaBar;
        protected virtual void Start()
        {
            Initialization();
          
        }

        protected virtual void Initialization()
        {
            if (!InfiniteMana)
            {
                CurrentMana = InitialMana;
             
            }

            if (InfiniteMana)
            {
                CurrentMana = MaximumMana;
             
            }
        

            _character = this.gameObject.GetComponent<Character>();
            _characterPersistence = this.gameObject.GetComponent<CharacterPersistence>();
            _initialized = true;
            if (_character != null)
            {
                if (_character.CharacterAnimator != null)
                {
                    _animator = _character.CharacterAnimator;
                }

                if (_character.CharacterModel != null)
                {
                    if (_character.CharacterModel.GetComponentInChildren<Renderer>() != null)
                    {
                        _renderer = _character.CharacterModel.GetComponentInChildren<Renderer>();
                    }
                }
            }
            _autoRespawn = this.gameObject.GetComponent<AutoRespawn>();
            _manaBar = this.gameObject.GetComponent<MMHealthBar>();

            StoreInitialPosition();
            UpdateManaBar(true);
        }


        public virtual void StoreInitialPosition()
        {
            _initialPosition = transform.position;
        }

        /// <summary>
        /// Called when the character uses mana by shooting projectiles
        /// </summary>
        /// <param name="mana">The mana the character gets.</param>
      
        /// 

        public virtual void UseMana(float mana)
        {
            if (mana > 0 && !InfiniteMana)
            {
                CurrentMana -= mana;
                UpdateManaBar(true);
            }
        }


        /// <summary>
        /// Called when the character gets mana (from a heart for example)
        /// </summary>
        /// <param name="mana">The mana the character gets.</param>
        /// <param name="instigator">The thing that gives the character mana.</param>
        /// 

        public virtual void GetMana(float mana, GameObject instigator)
        {
            CurrentMana = Mathf.Min(CurrentMana + mana, MaximumMana);
            UpdateManaBar(true);
        }

        /// <summary>
        /// Sets the health of the character to the one specified in parameters
        /// </summary>
        /// <param name="newMana"></param>
        /// <param name="instigator"></param>
        /// 
        public virtual void SetMana(float newMana, GameObject instigator)
        {
            CurrentMana = Mathf.Min(newMana, MaximumMana);
            UpdateManaBar(false);
        }


        public virtual void UpdateManaBar(bool show)
        {
            if (_manaBar != null)
            {
                _manaBar.UpdateBar(CurrentMana, 0f, MaximumMana, show);
            }

            if (_character != null)
            {
                if (_character.CharacterType == Character.CharacterTypes.Player)
                {//Update Mana Bar
                    if (GUIManager.HasInstance)
                    {
                        GUIManager.Instance.UpdateManaBar(CurrentMana, 0f, MaximumMana, _character.PlayerID);
                    }
                }
            }
        }

    }
}
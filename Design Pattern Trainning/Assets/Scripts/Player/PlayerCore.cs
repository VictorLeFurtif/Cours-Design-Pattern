using System.Collections.Generic;
using Controller;
using Fight.Factory_Pattern.Actor;
using Observer;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerCore : MonoBehaviour
    {
        #region Singleton
        
        public static PlayerCore instance;
        
        #endregion
        
        #region Fields

        public PlayerController playerController;
        public PlayerInput playerInput;

        public Pokemon pokemonPlayer = new Pokemon("Salamèche",200,10);

        public List<Pokemon> playerListPokemonCatch;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            
            InitComponent();
        }
        #endregion

        #region Init

        private void InitComponent()
        {
            if (playerController == null)
            {
                playerController = GetComponent<PlayerController>();
            }
            if (playerInput == null)
            {
                playerInput = GetComponent<PlayerInput>();
            }
        }

        #endregion

        #region Observer

        private void OnEnable()
        {
            EventManager.OnFightStart += () => playerInput.enabled = false;
            EventManager.OnFightEnd += () => playerInput.enabled = true;
        }

        private void OnDisable()
        {
            EventManager.OnFightStart -= () => playerInput.enabled = false;
            EventManager.OnFightEnd -= () => playerInput.enabled = true;
        }

        #endregion
    }
}
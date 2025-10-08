using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Fight.Factory_Pattern.Actor;
using Fight.Factory_Pattern.Enum;
using Observer;
using Player;
using UnityEngine;

namespace Fight.Factory_Pattern.Product
{
    public abstract class AbstractEncounter : MonoBehaviour
    {
        public List<string> ActionsList { get; set; }
        
        protected FightState _currentFightState = FightState.Player;

        protected Pokemon PokemonNmi;
        
        protected PlayerCore player;
        
        //[CallerMemberName] string _name = null! Debug.Log(_name);
        private void ChangeStateTurn()
        {
            switch (_currentFightState)
            {
                case FightState.Player:
                    _currentFightState = FightState.Ai;
                    break;
                case FightState.Ai:
                    _currentFightState = FightState.Player;
                    break;
            }

            Debug.Log($"New state = {_currentFightState}");
            
            if (_currentFightState == FightState.Ai)
            {
                EventManager.OnAiRoundStart.Invoke();
            }
        }
        
        public bool IsPlayerTurn()
        {
            return _currentFightState == FightState.Player;
        }
        
        protected virtual void EnemyAttack()
        {
            player.pokemonPlayer.Life -= PokemonNmi.Damage;
            EventManager.OnRoundEnd.Invoke();
        }

        protected virtual void Awake()
        {
            player = PlayerCore.instance;
        }

        #region Observer

        private void OnEnable()
        {
            EventManager.OnAiRoundStart += EnemyAttack;
            EventManager.OnRoundEnd += ChangeStateTurn;
        }

        private void OnDisable()
        {
            EventManager.OnAiRoundStart -= EnemyAttack;
            EventManager.OnRoundEnd -= ChangeStateTurn;
        }

        #endregion
    }
}
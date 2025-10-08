using System.Collections.Generic;
using Fight.Factory_Pattern.Actor;
using Fight.Factory_Pattern.Creator;
using Fight.Factory_Pattern.Enum;
using Fight.Factory_Pattern.Interface;
using Observer;
using Player;
using UnityEngine;

namespace Fight.Factory_Pattern.Product
{
    public class WildEncounter : AbstractEncounter
    {

        #region Fields
        
        private EncounterGeneratorWild encounterGeneratorWild;
        
        #endregion
        
        #region Action

        protected override void EnemyAttack()
        {
            Debug.Log($"{PokemonNmi.Name} attaque : damage({PokemonNmi.Damage})");
            base.EnemyAttack();
        }

        public void Attack()
        {
            if (!IsPlayerTurn()) return;
            
            Debug.Log($"Vous ordonnez {player.pokemonPlayer.Name} d'attaquer : damage({player.pokemonPlayer.Damage}) ");
            PokemonNmi.Life -= player.pokemonPlayer.Damage;
            EventManager.OnRoundEnd?.Invoke();
        }

        public void Heal()
        {
            if (!IsPlayerTurn()) return;
            
            Debug.Log($"Vous vous soignez de 5 ");
            player.pokemonPlayer.Life += 5;
            EventManager.OnRoundEnd?.Invoke();
        }

        public void Flee()
        {
            if (!IsPlayerTurn()) return;
            
            Debug.Log($"Vous prenez la fuite !!!");
            End();
        }

        public void Catch()
        {
            if (!IsPlayerTurn()) return;
            
            Debug.Log($"Vous attrapez le pokemon {PokemonNmi.Name}");
            player.playerListPokemonCatch.Add(PokemonNmi);
            End();
        }

        

        public void End()
        {
            EventManager.OnFightEnd.Invoke();
            Destroy(gameObject);
        }

        #endregion

        #region Unity Methods

        protected override void Awake()
        {
            base.Awake();
            
            ActionsList = new List<string>() { "Attack", "Heal", "Flee", "Catch" };

            PokemonNmi = new Pokemon("ToTo", 100,5);
            
        }

        #endregion

        #region Getter Setter

        public void GetRefGenerator(EncounterGeneratorWild target)
        {
            encounterGeneratorWild = target;
        }

        

        #endregion

        
    }
}
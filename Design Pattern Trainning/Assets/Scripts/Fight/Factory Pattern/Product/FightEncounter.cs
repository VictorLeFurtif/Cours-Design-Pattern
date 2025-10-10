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
    public class FightEncounter : AbstractEncounter
    {
        
        #region Fields
        
        public Trainer TrainerNmi;
        
        private EncounterGeneratorFight encounterGeneratorFight;
        
        #endregion
        
        #region Action

        protected override void EnemyAttack()
        {
            Debug.Log($"{TrainerNmi.Name} ordonne {PokemonNmi.Name} d'attaquer : damage({PokemonNmi.Damage})");
            base.EnemyAttack();
        }

        public void Attack()
        {
            if (!IsPlayerTurn()) return;
            
            Debug.Log($"Vous ordonnez {player.pokemonPlayer.Name} d'attaquer : damage({player.pokemonPlayer.Damage}) ");
            PokemonNmi.Life -= player.pokemonPlayer.Damage;
            CheckForDead();
            EventManager.OnRoundEnd?.Invoke();
        }

        public void Heal()
        {
            if (!IsPlayerTurn()) return;
            
            Debug.Log($"Vous vous soignez de 5 ");
            player.pokemonPlayer.Life += 5;
            EventManager.OnRoundEnd?.Invoke();
        }
        
        
        

        #endregion

        #region Unity Methods

        protected override void Awake()
        {
            base.Awake();
            
            ActionsList = new List<string>() { "Attack", "Heal" };

            PokemonNmi = new Pokemon("ToTo", 20,7);

            TrainerNmi = new Trainer("Victor");
            
            
        }

        #endregion

        #region Getter Setter

        public void GetRefGenerator(EncounterGeneratorFight target)
        {
            encounterGeneratorFight = target;
        }
        
        
        #endregion
        
        
        
       
    }
}
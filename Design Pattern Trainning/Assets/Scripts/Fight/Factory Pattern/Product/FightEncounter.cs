using System.Collections.Generic;
using Fight.Factory_Pattern.Actor;
using Fight.Factory_Pattern.Creator;
using Fight.Factory_Pattern.Enum;
using Fight.Factory_Pattern.Interface;
using Observer;
using Player;
using StatePattern;
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
            if (!PokemonNmi.currentStatePokemon.CanAttack())
            {
                Debug.Log($"L'ennemi échoue son attaque ");
                PokemonNmi.currentStatePokemon = new NormalState();
                EventManager.OnRoundEnd?.Invoke();
                return;
            }
            
            
            Debug.Log($"{TrainerNmi.Name} ordonne {PokemonNmi.Name} d'attaquer : damage({PokemonNmi.Damage})");
            
            if ( Random.Range(0, 6) >= 5)
            {
                player.pokemonPlayer.currentStatePokemon = new ParalyzedState();
                Debug.Log($"Le pokemon enemie vous paralyse");
            }
            
            PokemonNmi.currentStatePokemon = new NormalState();
            base.EnemyAttack();
        }

        public void Attack()
        {
            if (!IsPlayerTurn()) return;

            if (player.pokemonPlayer.currentStatePokemon.CanAttack())
            {
                Debug.Log($"Vous ordonnez {player.pokemonPlayer.Name} d'attaquer : damage({player.pokemonPlayer.Damage}) ");
                PokemonNmi.Life -= player.pokemonPlayer.Damage;
                CheckForDead();
            }
            else
            {
                Debug.Log($"Votre pokémon échoue son attaque ");
            }
            player.pokemonPlayer.currentStatePokemon = new NormalState();
            EventManager.OnRoundEnd?.Invoke();
        }

        public void Paralyzed()
        {
            if (player.pokemonPlayer.currentStatePokemon.CanAttack())
            {
                if ( Random.Range(0, 6) >= 5)
                {
                    PokemonNmi.currentStatePokemon = new ParalyzedState();
                    Debug.Log($"Votre pokémon réussie sa paralyzie ");
                }
                else
                {
                    Debug.Log($"Vous échouez votre paralyzation");
                }
                EventManager.OnRoundEnd?.Invoke();
            }
            else
            {
                Debug.Log($"Vous êtes paralysé");
                EventManager.OnRoundEnd?.Invoke();
            }
            
            
        }

        public void Heal()
        {
            if (!IsPlayerTurn()) return;
            
            Debug.Log($"Vous vous soignez de 5 ");

            if (!player.pokemonPlayer.currentStatePokemon.CanAttack())
            {
                player.pokemonPlayer.currentStatePokemon = new NormalState();
            }
            else
            {
                player.pokemonPlayer.Life += 5;
            }
            
            EventManager.OnRoundEnd?.Invoke();
        }
        
        protected override void End()
        {
            Destroy(encounterGeneratorFight.gameObject);
            
            base.End();
        }
        

        #endregion

        #region Unity Methods

        protected override void Awake()
        {
            base.Awake();
            
            ActionsList = new List<string>() { "Attack", "Heal", "Paralyzed" };

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
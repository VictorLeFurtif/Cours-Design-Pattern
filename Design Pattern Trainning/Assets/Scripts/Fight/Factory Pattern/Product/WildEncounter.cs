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
    public class WildEncounter : AbstractEncounter
    {

        #region Fields
        
        private EncounterGeneratorWild encounterGeneratorWild;
        
        #endregion
        
        #region Action

        protected override void EnemyAttack()
        {
            if (PokemonNmi.currentStatePokemon.TakeDamage())
            {
                PokemonNmi.currentStatePokemon = new NormalState();
                PokemonNmi.Life -= 5;
                CheckForDead();
                EventManager.OnRoundEnd?.Invoke();
                return;
            }
            
            Debug.Log($"{PokemonNmi.Name} attaque : damage({PokemonNmi.Damage})");
            
            
            if ( Random.Range(0, 6) >= 5)
            {
                player.pokemonPlayer.currentStatePokemon = new BleedingState();
                Debug.Log($"Votre souffrez de saignement ");
            }
            
            base.EnemyAttack();
        }

        public void Attack()
        {
            if (!IsPlayerTurn()) return;
            
            if (player.pokemonPlayer.currentStatePokemon.TakeDamage())
            {
                player.pokemonPlayer.currentStatePokemon = new NormalState();
                player.pokemonPlayer.Life -= 5;
                CheckForDead();
                EventManager.OnRoundEnd?.Invoke();
                return;
            }
            
            Debug.Log($"Vous ordonnez {player.pokemonPlayer.Name} d'attaquer : damage({player.pokemonPlayer.Damage}) ");
            
            if ( Random.Range(0, 6) >= 5)
            {
                PokemonNmi.currentStatePokemon = new BleedingState();
                Debug.Log($"Le pokemon ennemi souffre de saignement ");
            }
            
            PokemonNmi.Life -= player.pokemonPlayer.Damage;
            CheckForDead();
            EventManager.OnRoundEnd?.Invoke();
        }

        public void Heal()
        {
            if (!IsPlayerTurn()) return;
            
            if (player.pokemonPlayer.currentStatePokemon.TakeDamage())
            {
                Debug.Log($"Vous vous soignez de tout sort ");
                player.pokemonPlayer.currentStatePokemon = new NormalState();
            }
            else
            {
                Debug.Log($"Vous vous soignez de 5 ");
                player.pokemonPlayer.Life += 5;
            }
            
            EventManager.OnRoundEnd?.Invoke();
        }

        public void Flee()
        {
            if (!IsPlayerTurn()) return;
            
            
            if (player.pokemonPlayer.currentStatePokemon.TakeDamage())
            {
                Debug.Log($"Vous ne pouvez pas vous enfuir en étant blessé");
                player.pokemonPlayer.currentStatePokemon = new NormalState();
                EventManager.OnRoundEnd?.Invoke();
            }
            else
            {
                Debug.Log($"Vous prenez la fuite !!!");
                End();
            }
            
        }

        public void Catch()
        {
            if (!IsPlayerTurn()) return;
            
            Debug.Log($"Vous attrapez le pokemon {PokemonNmi.Name}");
            player.playerListPokemonCatch.Add(PokemonNmi);
            End();
        }

        protected override void End()
        {
            Destroy(encounterGeneratorWild.gameObject);
            
            base.End();
        }

        #endregion

        #region Unity Methods

        protected override void Awake()
        {
            base.Awake();
            
            ActionsList = new List<string>() { "Attack", "Heal", "Flee", "Catch" };

            PokemonNmi = new Pokemon("ToTo", 20,5);
            
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
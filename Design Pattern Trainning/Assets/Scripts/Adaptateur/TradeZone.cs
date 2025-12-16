using System;
using Controller;
using Player;
using UI;
using UnityEngine;

namespace Adaptateur
{
    public class TradeZone : MonoBehaviour
    {
        [SerializeField] private Gen1Pokemon pokemonToGetGen1;
        [SerializeField] private Gen2Pokemon pokemonToGetGen2;

        [SerializeField] private TradeType tradeType;

        private bool trade = false;
        enum TradeType
        {
            Gen2ToGen1,
            Gen1ToGen2,
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (trade) return;

            trade = true;
            switch (tradeType)
            {
                case TradeType.Gen2ToGen1:
                    
                    Gen2ToGen1 poke = ScriptableObject.CreateInstance<Gen2ToGen1>();
            
                    Gen2Pokemon pokemonToTradeTemp = collision.GetComponent<PlayerCore>().pokemonCurrentGen2;
            
                    poke.Init(pokemonToTradeTemp);

                    Gen1ToGen2 poke2 = ScriptableObject.CreateInstance<Gen1ToGen2>();
            
                    poke2.Init(pokemonToGetGen1);

                    collision.GetComponent<PlayerCore>().pokemonCurrentGen2 = poke2;
            
                    pokemonToGetGen1 = poke;
                    
                    LogEncounter.Instance.AddMessage($"You trade your pokemon {pokemonToGetGen1.namePokemon} from Gen 2 for" +
                                                     $" {pokemonToTradeTemp.namePokemon} from the Gen 1");
                    break;
                case TradeType.Gen1ToGen2:
                    Gen1ToGen2 pokemon = ScriptableObject.CreateInstance<Gen1ToGen2>();
                    
                    Gen1Pokemon pokemonTradeTemp = collision.GetComponent<PlayerCore>().pokemonCurrentGen1;
                    
                    pokemon.Init(pokemonTradeTemp);

                    Gen2ToGen1 pokemon2 = ScriptableObject.CreateInstance<Gen2ToGen1>();
                    
                    pokemon2.Init(pokemonToGetGen2);
                    
                    collision.GetComponent<PlayerCore>().pokemonCurrentGen1 = pokemon2;

                    pokemonToGetGen2 = pokemon;
                    
                    LogEncounter.Instance.AddMessage($"You trade your pokemon {pokemonToGetGen2.namePokemon} from Gen 1 for" +
                                                     $" {pokemonTradeTemp.namePokemon} from the Gen 2");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }
    }
}

using System;
using Controller;
using Player;
using UnityEngine;

namespace Adaptateur
{
    public class TradeZone : MonoBehaviour
    {
        [SerializeField] private Gen1Pokemon PokemonToGet;

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
            
                    Gen2Pokemon pokemonToTradeTemp = collision.GetComponent<PlayerCore>().pokemonCurrent;
            
                    poke.Init(pokemonToTradeTemp);

                    Gen1ToGen2 poke2 = ScriptableObject.CreateInstance<Gen1ToGen2>();
            
                    poke2.Init(PokemonToGet);

                    collision.GetComponent<PlayerCore>().pokemonCurrent = poke2;
            
                    PokemonToGet = poke;
                    break;
                case TradeType.Gen1ToGen2:
                    
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }
    }
}

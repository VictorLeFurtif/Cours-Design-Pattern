using UnityEngine;

namespace Adaptateur
{
    public class Gen1ToGen2 : Gen2Pokemon
    {
        public void Init(Gen1Pokemon pGen1Poke)
        {
            life = pGen1Poke.life *2;
            speed = pGen1Poke.speed *2;
            specialDamage = pGen1Poke.special / 2;
            specialAttack = pGen1Poke.special / 2;
            namePokemon = pGen1Poke.namePokemon;
        }
    }
}

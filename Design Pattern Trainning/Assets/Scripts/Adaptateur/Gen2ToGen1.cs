using UnityEngine;

namespace Adaptateur
{
    public class Gen2ToGen1 : Gen1Pokemon
    {
        public void Init(Gen2Pokemon pGen2Poke)
        {
            life = pGen2Poke.life/2;
            speed = pGen2Poke.speed/2;
            special = (pGen2Poke.specialDamage + pGen2Poke.specialAttack) / 4;
            namePokemon = pGen2Poke.namePokemon;
        }
    }
}

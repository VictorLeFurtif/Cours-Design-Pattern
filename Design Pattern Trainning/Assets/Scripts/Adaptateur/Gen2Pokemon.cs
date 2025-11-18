using UnityEngine;

namespace Adaptateur
{
    [CreateAssetMenu(fileName = "second_generation_pokemon", menuName = "Scriptable Objects/Pokemon/Gen2Pokemon")]
    public class Gen2Pokemon : ScriptableObject
    {
        public int life;
        public int speed;
        public int specialAttack;
        public int specialDamage;
        public string namePokemon;
    }
}

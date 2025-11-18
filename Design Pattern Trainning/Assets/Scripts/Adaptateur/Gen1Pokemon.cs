using UnityEngine;

namespace Adaptateur
{
    [CreateAssetMenu(fileName = "first_generation_pokemon", menuName = "Scriptable Objects/Pokemon/Gen1Pokemon")]
    public class Gen1Pokemon : ScriptableObject
    {
        public int life;
        public int speed;
        public int special;
        public string namePokemon;
    }
}

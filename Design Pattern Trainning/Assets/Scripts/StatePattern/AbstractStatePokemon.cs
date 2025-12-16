using UnityEngine;

namespace StatePattern
{
    public abstract class AbstractStatePokemon
    {
        public abstract bool CanAttack();
        public abstract bool TakeDamage();
    }
}

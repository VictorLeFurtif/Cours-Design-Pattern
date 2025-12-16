using UnityEngine;

namespace StatePattern
{
    public class ParalyzedState : AbstractStatePokemon
    {
        public override bool CanAttack()
        {
            return false;
        }

        public override bool TakeDamage()
        {
            return false;
        }
    }
}

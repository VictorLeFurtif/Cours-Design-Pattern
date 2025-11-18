using UnityEngine;

namespace StatePattern
{
    public class BleedingState : AbstractStatePokemon
    {
        public override bool CanAttack()
        {
            return true;
        }

        public override bool TakeDamage()
        {
            return true;
        }
    }
}

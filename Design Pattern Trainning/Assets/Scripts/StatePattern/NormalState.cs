using UnityEngine;

namespace StatePattern
{
    public class NormalState : AbstractStatePokemon
    {
        public override bool CanAttack()
        {
            return true;
        }

        public override bool TakeDamage()
        {
            return false;
        }
    }
}

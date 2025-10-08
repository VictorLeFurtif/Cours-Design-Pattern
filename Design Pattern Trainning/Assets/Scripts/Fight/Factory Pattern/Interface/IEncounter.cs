using System.Collections.Generic;

namespace Fight.Factory_Pattern.Interface
{
    public interface IEncounter
    {
        void Attack();

        void Heal();

        void End();
        
        List<string> ActionsList {get; set;}
    }
}
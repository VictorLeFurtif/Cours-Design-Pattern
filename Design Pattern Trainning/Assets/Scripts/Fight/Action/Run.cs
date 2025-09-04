using UnityEngine;

namespace Fight.Action
{
    public class Run : MonoBehaviour,IAction
    {
        public void Invoke()
        {
            Destroy(Encounter.instance.gameObject);
        }
    }
}
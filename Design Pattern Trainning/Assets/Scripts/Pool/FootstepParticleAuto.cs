using UnityEngine;
using Utility;

namespace Pool
{
    public class FootstepParticleAuto : MonoBehaviour
    {
        [SerializeField] private float lifetime = 0.5f;
        [SerializeField] private string poolKey = "Footsteps";
        
        [SerializeField] private ParticleSystem particle;
        private float timer;
        

        private void OnEnable()
        {
            timer = 0f;
        }

        private void Update()
        {
            timer += Time.deltaTime;
            
            if (timer >= lifetime)
            {
                ObjectPooler.EnqueueObject(particle, poolKey);
            }
        }
    }
}
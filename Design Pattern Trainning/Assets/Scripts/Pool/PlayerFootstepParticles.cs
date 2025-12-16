using Controller;
using UnityEngine;
using Utility;

namespace Pool
{
    public class PlayerFootstepParticles : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particlePrefab;
        [SerializeField] private int poolSize = 5;
        [SerializeField] private float spawnInterval = 0.15f;
        [SerializeField] private PlayerController pc;
    
        private string poolKey = "Footsteps";
        private float timer;

        private void Start()
        {
            ObjectPooler.SetupPool(particlePrefab, poolSize, poolKey);
        }

        private void Update()
        {
            CheckAndSpawnParticles();
        }

        private void CheckAndSpawnParticles()
        {
            timer += Time.deltaTime;

            if (!pc.isMoving || !(timer >= spawnInterval)) return;
            
            SpawnFootstepParticle();
            timer = 0f;
        }

        private void SpawnFootstepParticle()
        {
            ParticleSystem particle = ObjectPooler.DequeueObject<ParticleSystem>(poolKey);
            particle.transform.position = transform.position;
            particle.gameObject.SetActive(true);
            particle.Play();
        }
    }
}
using UnityEngine;

namespace Controller
{
    public class CameraController : MonoBehaviour
    {
        public float translationFactor = 20;
        public Transform target;

        void LateUpdate()
        {
            if(transform.position != target.position) 
            {
                transform.position += (target.position - transform.position) / translationFactor;           
            }

            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }
}
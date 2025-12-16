using System;
using System.Collections;
using Enum;
using UnityEngine;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float movingDistance = 1f;
        [SerializeField] private float moveDuration = 0.15f;

        private bool isMoving;

        public void MovePlayer(Direction direction)
        {
            if (isMoving)
                return;

            Vector2 dir = direction switch
            {
                Direction.Front => Vector2.up,
                Direction.Back  => Vector2.down,
                Direction.Left  => Vector2.left,
                Direction.Right => Vector2.right,
                _ => Vector2.zero
            };

            if (dir == Vector2.zero)
                return;

            Vector2 startPos = transform.position;
            Vector2 targetPos = startPos + dir * movingDistance;

            StartCoroutine(MoveRoutine(startPos, targetPos));
        }

        private IEnumerator MoveRoutine(Vector2 start, Vector2 target)
        {
            isMoving = true;
            float elapsed = 0f;

            while (elapsed < moveDuration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / moveDuration;

                transform.position = Vector2.Lerp(start, target, t);
                yield return null;
            }

            transform.position = target;
            isMoving = false;
        }
    }
}
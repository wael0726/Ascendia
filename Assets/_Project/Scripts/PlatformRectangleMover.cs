using UnityEngine;
using DG.Tweening;
using System.Collections;

namespace Platformer {
    public class PlatformMoverRectangle : MonoBehaviour {
        [SerializeField] float moveDistanceX = 3f;  
        [SerializeField] float moveDistanceY = 2f;  
        [SerializeField] float moveTime = 1f;
        [SerializeField] float pauseTime = 2f;
        [SerializeField] Ease ease = Ease.InOutQuad;

        Vector3 startPosition;

        void Start() {
            startPosition = transform.position;
            StartCoroutine(MoveCycle());
        }

        IEnumerator MoveCycle() {
            while (true) {
                yield return transform.DOMove(new Vector3(startPosition.x + moveDistanceX, startPosition.y, startPosition.z), moveTime).SetEase(ease).WaitForCompletion();
                yield return new WaitForSeconds(pauseTime);
                yield return transform.DOMove(new Vector3(startPosition.x + moveDistanceX, startPosition.y + moveDistanceY, startPosition.z), moveTime).SetEase(ease).WaitForCompletion();
                yield return new WaitForSeconds(pauseTime);
                yield return transform.DOMove(new Vector3(startPosition.x, startPosition.y + moveDistanceY, startPosition.z), moveTime).SetEase(ease).WaitForCompletion();
                yield return new WaitForSeconds(pauseTime);
                yield return transform.DOMove(startPosition, moveTime).SetEase(ease).WaitForCompletion();
                yield return new WaitForSeconds(pauseTime);
            }
        }
    }
}

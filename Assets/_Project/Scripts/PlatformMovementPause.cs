using UnityEngine;
using DG.Tweening;
using System.Collections;

namespace Platformer {
    public class PlatformMoverWithPause : MonoBehaviour {
        [SerializeField] Vector3 moveTo = Vector3.zero;
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
                // Monte
                yield return transform.DOMove(startPosition + moveTo, moveTime).SetEase(ease).WaitForCompletion();
                
                // Pause en haut
                yield return new WaitForSeconds(pauseTime);
                
                // Redescend
                yield return transform.DOMove(startPosition, moveTime).SetEase(ease).WaitForCompletion();
                
                // Pause en bas
                yield return new WaitForSeconds(pauseTime);
            }
        }
    }
}

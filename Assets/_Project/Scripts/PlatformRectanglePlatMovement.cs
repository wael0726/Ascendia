using UnityEngine;
using DG.Tweening;
using System.Collections;

namespace Platformer {
    public class PlatformMoverRectangleFlat : MonoBehaviour {
        [SerializeField] float moveDistanceX = 3f;  // Distance sur l'axe X
        [SerializeField] float moveDistanceZ = 2f;  // Distance sur l'axe Z
        [SerializeField] float moveTime = 1f;  // Temps pour chaque mouvement
        [SerializeField] float pauseTime = 2f; // Temps de pause à chaque coin
        [SerializeField] Ease ease = Ease.InOutQuad;

        Vector3 startPosition;

        void Start() {
            startPosition = transform.position;
            StartCoroutine(MoveCycle());
        }

        IEnumerator MoveCycle() {
            while (true) {
                // Aller à droite (X+)
                yield return transform.DOMove(new Vector3(startPosition.x + moveDistanceX, startPosition.y, startPosition.z), moveTime).SetEase(ease).WaitForCompletion();
                yield return new WaitForSeconds(pauseTime);

                // Aller en avant (Z+)
                yield return transform.DOMove(new Vector3(startPosition.x + moveDistanceX, startPosition.y, startPosition.z + moveDistanceZ), moveTime).SetEase(ease).WaitForCompletion();
                yield return new WaitForSeconds(pauseTime);

                // Aller à gauche (X-)
                yield return transform.DOMove(new Vector3(startPosition.x, startPosition.y, startPosition.z + moveDistanceZ), moveTime).SetEase(ease).WaitForCompletion();
                yield return new WaitForSeconds(pauseTime);

                // Revenir en arrière (Z-)
                yield return transform.DOMove(startPosition, moveTime).SetEase(ease).WaitForCompletion();
                yield return new WaitForSeconds(pauseTime);
            }
        }
    }
}

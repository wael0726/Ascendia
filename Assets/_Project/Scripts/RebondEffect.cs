using UnityEngine;
using System.Collections;

public class ButtonBoingEffect3D : MonoBehaviour
{
    [SerializeField] private float bounceForce = 10f;   // La force du rebond (trampoline)
    [SerializeField] private float bounceDuration = 0.2f; // Durée de l'effet visuel (compression)
    [SerializeField] private Vector3 scaleFactor = new Vector3(1.2f, 0.8f, 1f); // Effet visuel
    private Vector3 originalScale; // Taille d'origine du bouton

    void Start()
    {
        originalScale = transform.localScale; // Sauvegarde la taille d'origine
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Supprime toute vitesse verticale pour éviter des problèmes
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                
                // Applique une force verticale (rebond)
                rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }

            // Lance l'effet visuel de compression
            StartCoroutine(BoingEffect());
        }
    }

    private IEnumerator BoingEffect()
    {
        transform.localScale = scaleFactor; // Compression

        yield return new WaitForSeconds(bounceDuration);

        transform.localScale = originalScale; // Retour à la taille normale
    }
}

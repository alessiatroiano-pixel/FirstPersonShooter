using UnityEngine;

public class PlaySoundOnEnable : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clipToPlay;

    private void OnEnable()
    {
        // Se il gioco è appena partito (meno di 1 secondo), non suonare.
        // Questo evita il "glitch" audio al caricamento della scena.
        if (Time.timeSinceLevelLoad < 0.5f) return;

        if (audioSource != null && clipToPlay != null)
        {
            audioSource.PlayOneShot(clipToPlay);
        }
    }
}
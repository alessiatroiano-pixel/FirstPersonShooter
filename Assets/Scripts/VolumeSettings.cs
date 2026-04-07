using UnityEngine;
using UnityEngine.Audio; // Necessario per il Mixer
using UnityEngine.UI;    // Necessario per lo Slider

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer myMixer;
    public Slider volumeSlider;

    void Start()
    {
        // Imposta lo slider al valore attuale del mixer (opzionale)
        SetVolume();
    }

    public void SetVolume()
    {
        float volume = volumeSlider.value;

        /* Il volume del mixer va da -80 (muto) a 0 (massimo). 
           Usiamo il logaritmo per rendere la regolazione naturale per l'orecchio umano.
        */
        myMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }
}
using UnityEngine;
using UnityEngine.UI; // Obbligatorio per usare lo Slider

public class PlayerHealth : MonoBehaviour
{
    [Header("Parametri Vita")]
    public float health = 100f;
    public Slider healthSlider;
    private bool isDead = false; // Impedisce di morire più volte

    [Header("UI Game Over")]
    public GameObject panelSconfitta; // Trascina qui il tuo Canvas/Panel della morte

    [Header("Audio Danno")]
    public AudioSource audioSource;
    public AudioClip damageSound;

    void Start()
    {
        // Impostiamo lo slider al massimo all'inizio
        if (healthSlider != null)
        {
            healthSlider.maxValue = health;
            healthSlider.value = health;
        }

        // Assicuriamoci che il panel sia spento all'avvio
        if (panelSconfitta != null)
        {
            panelSconfitta.SetActive(false);
        }
    }

    public void TakeDamage(float amount)
    {
        // Se siamo già morti, non fare più nulla
        if (isDead) return;

        health -= amount;

        // Aggiorna lo slider (anche se va in negativo)
        if (healthSlider != null)
        {
            healthSlider.value = health;
        }

        // Audio del danno (suona solo se siamo ancora vivi o appena colpiti)
        if (audioSource != null && damageSound != null && health > 0)
        {
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.PlayOneShot(damageSound);
        }

        // CONTROLLO MORTE: se la vita è 0 o meno di 0
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        health = 0; // Forza lo slider a zero
        if (healthSlider != null) healthSlider.value = 0;

        Debug.Log("GAME OVER: Attivazione Panel...");

        if (panelSconfitta != null)
        {
            // ATTIVA IL PANEL (e quindi il suono se hai lo script OnEnable)
            panelSconfitta.SetActive(true);

            // FERMA IL GIOCO
            Time.timeScale = 0f;

            // SBLOCCA IL MOUSE (altrimenti non puoi premere i tasti del menu)
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Debug.LogError("ATTENZIONE: Non hai assegnato il Panel Sconfitta nell'Inspector del Player!");
        }
    }
}
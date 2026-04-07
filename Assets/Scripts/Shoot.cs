
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject impactPrefabWall;
    public GameObject impactPrefabEnemy;

    [Header("Audio")]
    public AudioSource audioSource; // Trascina qui l'AudioSource del Player
    public AudioClip shootClip;    // Il file audio dello sparo

    void Update()
    {
        if (Time.timeScale == 1f && Input.GetButtonDown("Fire1"))
        {
            PlayerShoot();
        }
    }

    void PlayerShoot()
    {
        // --- LOGICA AUDIO ---
        if (audioSource != null && shootClip != null)
        {
            audioSource.PlayOneShot(shootClip);
        }
        // --------------------

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f))
        {
            EnemyController enemy = hit.transform.GetComponentInParent<EnemyController>();

            Vector3 spawnPos = hit.point + hit.normal * 0.01f;
            Quaternion spawnRot = Quaternion.LookRotation(hit.normal);

            if (enemy != null)
            {
                if (impactPrefabEnemy != null)
                {
                    GameObject impact = Instantiate(impactPrefabEnemy, spawnPos, Quaternion.identity);
                    Destroy(impact, 2f);
                }

                enemy.TakeDamage(25f);
            }
            else
            {
                if (impactPrefabWall != null)
                {
                    GameObject impact = Instantiate(impactPrefabWall, spawnPos, spawnRot);
                    Destroy(impact, 5f);
                }

                Debug.Log("Hit wall: " + hit.transform.name);
            }
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject panelMain;      
    public GameObject panelPause;     
    public GameObject panelDeath;     
    public GameObject panelWin;       

    [Header("Win Settings")]
    public int enemiesToKill = 6;    
    private int enemiesKilled = 0;

    private bool isPaused = false;// Controllolo dello stato di pausa

    void Start()
    {
        // All'avvio viene mostrato solo il menu principale
        panelMain?.SetActive(true);
        panelPause?.SetActive(false);
        panelDeath?.SetActive(false);
        panelWin?.SetActive(false);  // Nascondi la schermata di vittoria inizialmente

        
        Time.timeScale = 0f;

        
        Cursor.lockState = CursorLockMode.None;//Cursore per cliccare i buttons
        Cursor.visible = true;
    }

    void Update()
    {
        // ESC per pausa
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1f && (panelDeath == null || !panelDeath.activeSelf))
        {
            TogglePause();
        }
    }

     
    public void StartGame()// START
    {
        panelMain?.SetActive(false);
        Time.timeScale = 1f;
        
        
        Cursor.lockState = CursorLockMode.Locked;//cursore bloccato al centro dello schermo per giocare
        Cursor.visible = false;

       
    }

    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Sei uscito dal gioco");
    }


    // ritorna al main menu dopo la morte
    public void GofromDeathtoMain()
    {
        panelDeath?.SetActive(false);        
        panelMain?.SetActive(true);          

         
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);// Ricarica la scena

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // ritorna al main menu dopo la vittoria
    public void GofromWintoMain()
    {
        panelWin?.SetActive(false);        
        panelMain?.SetActive(true);        

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    
    public void TogglePause()
    {
        if (isPaused)
        {
            panelPause?.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;

            // no cursore
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            panelPause?.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;

            // si cursore
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // ritorna al main menu dopo la pausa (senza ricaricare la scena, quindi senza resettare vita, nemici, ecc.)
    public void GofromPausetoMain()
    {
        panelPause?.SetActive(false);
        panelMain?.SetActive(true);

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

   
    public void GameOver() // GAME OVER / DEATH
    {
        panelDeath?.SetActive(true);
        Time.timeScale = 0f;

        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

       
    }

    
    public void EnemyKilled()
    {
        enemiesKilled++;
        Debug.Log("Nemici uccisi: " + enemiesKilled);

        if (enemiesKilled >= enemiesToKill)
        {
            WinGame();
        }
    }

    
    void WinGame()// VITTORIA
    {
        panelWin?.SetActive(true);
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

       
        Debug.Log("HAI VINTO!");

        
    }
}

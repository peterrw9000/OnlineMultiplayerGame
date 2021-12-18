using UnityEngine;
using Mirror;

public class GameOverManager : NetworkBehaviour
{
    public PlayerHealth playerHealth;
	public float restartDelay = 5f;


    Animator anim;
	float restartTimer;


    void Awake()
    {
        anim = GetComponent<Animator>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }


    void Update()
    {
        if (playerHealth == null)
        {
            if (FindObjectOfType<PlayerHealth>() != null)
            {
                playerHealth = FindObjectOfType<PlayerHealth>();
                if (playerHealth.currentHealth <= 0)
                {
                    anim.SetTrigger("GameOver");

                    restartTimer += Time.deltaTime;

                    if (restartTimer >= restartDelay)
                    {
                        Application.LoadLevel(Application.loadedLevel);
                    }
                }
            }
        }
    }
}

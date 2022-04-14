using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;

    public GameObject gameWonPanel;
    public GameObject pausedPanel;
    public GameObject gameLostPanel;

    public float speed;
    private bool levelStatus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelStatus)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                rigidbody2D.velocity = new Vector2(speed, 0f);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                rigidbody2D.velocity = new Vector2(-speed, 0f);
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                rigidbody2D.velocity = new Vector2(0f, speed);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                rigidbody2D.velocity = new Vector2(0f, -speed);
            }
            else if (Input.GetAxis("Cancel") > 0)
            {
                pausedPanel.SetActive(true);
            }
            else
            {
                rigidbody2D.velocity = new Vector2(0f, 0f);
            }
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0f, 0f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Astronaut")
        {
            Debug.Log("Level Complete!!");
            gameWonPanel.SetActive(true);
            levelStatus = true;
        }
        else if(other.tag == "Asteroid")
        {
            Debug.Log("Ship Destroyed");
            gameLostPanel.SetActive(true);
            levelStatus = true;
        }
    }

    public void RestartGame()
    {
        Debug.Log("Button Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}

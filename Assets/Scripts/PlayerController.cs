using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int score;
    public float speed;
    public Text countText;
    public Text winText;
    public GameObject pointParent;
    public AudioSource deathSoundSource;
    public AudioClip deathSound;
    public AudioSource backgroundMusicSource;
    public AudioClip backgroundMusic;
    public static bool dead;

    public GameObject camera1;
    public GameObject camera2;

    private AudioListener camera1Listener;
    private AudioListener camera2Listener;

    private void Start()
    {
        dead = false;
        camera1.SetActive(true);

        camera1Listener = camera1.GetComponent<AudioListener>();
        camera2Listener = camera2.GetComponent<AudioListener>();

        camera2Listener.enabled = false;
        camera2.SetActive(false);

        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScore();
        winText.text = "";
        pointParent = GameObject.FindGameObjectWithTag("Pick Up Folder");
        deathSoundSource.clip = deathSound;
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.Play();
    }
    private void FixedUpdate()
    {
        if (Time.timeScale > 0 && !dead)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed);
        }
    }

    private void SetScore()
    {
        countText.text = "Shroks: " + score.ToString();
    }

    private void SetWinText()
    {
        winText.text = "You Win!";
        backgroundMusicSource.Stop();
        Time.timeScale = 0;
    }

    private void Die()
    {
        Time.timeScale = 0;
        Destroy(gameObject);
        backgroundMusicSource.Stop();
        deathSoundSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            score += 1;
            SetScore();
        }
        else if (other.gameObject.CompareTag("Death"))
        {
            Die();
        }
        else if (other.gameObject.CompareTag("Camera Switch"))
        {
            camera1Listener.enabled = false;
            camera2.SetActive(true);
            camera2Listener.enabled = true;
            camera1.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Win"))
        {
            SetWinText();
        }
    }
}

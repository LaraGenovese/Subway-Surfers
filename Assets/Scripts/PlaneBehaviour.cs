using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneBehaviour : MonoBehaviour
{
    public float movementSpeed;
    public Coins coinsScript;
    private float remainingTime;

    public Text txt_time;
    public GameObject tiempo;
    public float currentTime;

    AudioSource fuenteAudio;
    public AudioClip countdown;

    public GameObject panel_menu;
    public bool menu;

    // Start is called before the first frame update
    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();

        menu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (menu)
        {
            tiempo.SetActive(true);

            currentTime += Time.deltaTime;

            remainingTime = 3 - Mathf.Floor(currentTime);

            txt_time.text = remainingTime.ToString();

            if (remainingTime <= 0)
            {
                transform.Translate(movementSpeed, 0, 0);
                tiempo.SetActive(false);
            }
        }

        if (coinsScript.monedas == 5)
        {
            movementSpeed = 0;
        }
    }

    public void jugar()
    {
        panel_menu.SetActive(false);
        menu = true;

        if (menu)
        {
            fuenteAudio.clip = countdown;
            fuenteAudio.Play();
        }
    }
}

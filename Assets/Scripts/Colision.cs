using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Colision : MonoBehaviour
{
    public GameObject Panel_perder;
    public PlaneBehaviour planeScript;
    public Text score;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "valla" || other.gameObject.name == "wall")
        {
            Panel_perder.SetActive(true);
            planeScript.movementSpeed = 0;
            gameObject.SetActive(false);
        }
    }

    public void jugarDeNuevo()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

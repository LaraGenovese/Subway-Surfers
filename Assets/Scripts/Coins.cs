using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Coins : MonoBehaviour
{
    public Text txt_monedas;
    public int monedas;

    public GameObject Panel_ganar;
    public GameObject Panel_perder;
    public Text score;

    public GameObject clone1;
    public GameObject clone2;
    int cantDeCubos = 0;
    public int cantidad;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "moneda")
        {
            Destroy(other.gameObject);
            monedas = monedas + 1;
        }
        txt_monedas.text = "Score: " + monedas;

        if (monedas == 5)
        {
            Panel_ganar.SetActive(true);
            gameObject.SetActive(false);

            while (cantDeCubos < cantidad)
            {
                Instantiate(clone1);
                Instantiate(clone2);
                cantDeCubos++;
            }
        }
    }

    public void jugarDeNuevo()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

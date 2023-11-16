using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appledSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject gameDirector;
    ParticleSystem particle;

    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        aud = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>();
        gameDirector = GameObject.Find("GameDirector");
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape)) 
            Application.Quit();

        if (gameDirector.GetComponent<GameDirector>().time <= 0)
            return; 

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0.0f, z);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Apple")
        {
            this.aud.PlayOneShot(this.appledSE);
            gameDirector.GetComponent<GameDirector>().GetApple();
            particle.startColor = Color.white;
            particle.Play();

        }
        else
        {
            this.aud.PlayOneShot(this.bombSE);
            gameDirector.GetComponent<GameDirector>().GetBomb();
            particle.startColor = Color.black;
            particle.Play();
        }
        Destroy(other.gameObject);

    }
}

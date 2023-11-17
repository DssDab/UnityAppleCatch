using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appledSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject gameDirector;
    ParticleSystem.MainModule particle;

    LayerMask m_StageMask = -1;

    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        aud = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>().main;
        gameDirector = GameObject.Find("GameDirector");

        m_StageMask = 1 << LayerMask.NameToLayer("Stage");
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
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, m_StageMask.value))
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

        }
        else
        {
            this.aud.PlayOneShot(this.bombSE);
            gameDirector.GetComponent<GameDirector>().GetBomb();
            particle.startColor = Color.black;
        }
        this.GetComponent<ParticleSystem>().Play();
        Destroy(other.gameObject);

    }
}

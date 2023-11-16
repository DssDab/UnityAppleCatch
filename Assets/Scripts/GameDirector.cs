using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject TimerText;
    GameObject PointText;
    public RawImage gameOverPanel;
    public Text ResultText;
    public Button ReplayBtn;
    [HideInInspector]public float time = 30.0f;
    int point = 0;
    GameObject ItemGen;
    // Start is called before the first frame update
    void Start()
    {
        this.TimerText = GameObject.Find("Timer");
        this.PointText = GameObject.Find("Point");
        ItemGen = GameObject.Find("ItemGenerator");

        if (ReplayBtn != null)
            ReplayBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("GameScene");
            });
    }

    void Update()
    {
        this.time -= Time.deltaTime;
        if(this.time<0)
        {
            this.time = 0;
            this.ItemGen.GetComponent<ItemGenerator>().SetParameter(10000.0f, 0, 0);
            gameOverPanel.gameObject.SetActive(true);
            ResultText.text = "È¹µæÁ¡¼ö : " + point.ToString();
        }
        else if(0 <= this.time && this.time < 5 )
            this.ItemGen.GetComponent<ItemGenerator>().SetParameter(0.9f, 3, -0.04f);
        else if (5 <= this.time && this.time < 10)
            this.ItemGen.GetComponent<ItemGenerator>().SetParameter(0.4f, 6, -0.06f);
        else if (10 <= this.time && this.time < 20)
            this.ItemGen.GetComponent<ItemGenerator>().SetParameter(0.7f, 4, -0.04f);
        else if (20 <= this.time && this.time < 30)
            this.ItemGen.GetComponent<ItemGenerator>().SetParameter(1.0f, 2, -0.03f);
        TimerText.GetComponent<Text>().text = this.time.ToString("F1");

        this.PointText.GetComponent<Text>().text = this.point.ToString() + " Point";
    }

    public void GetApple()
    {
        this.point += 100;
    }

    public void GetBomb()
    {
        this.point /= 2;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Music;
using static InstanceObject;
using UnityEngine.Experimental.GlobalIllumination;
using JetBrains.Annotations;
using Unity.Properties;
public class ControllPlayer : MonoBehaviour
{
    public Text ScoreText,BestText,OverText;
    public static int Score,lift = 5;
    public GameObject PanelOver ,Hand1,Hand2;
    public static bool IsOVer =true;
    public GameObject patical,NumScore;
    public GameObject[] BallFalse;
    public Animator PlusNum;
    public static ControllPlayer Instance;

    public void Awake()
    {
        Instance  = GetComponent<ControllPlayer>();
    }
    public void Start()
    {
        PanelOver.SetActive(false);
        NumScore.SetActive(false);
        BestBall = PlayerPrefs.GetInt("BestBall", 0);
    }
    private void Update()
    {
        ScoreText.text = Score.ToString();
        if (BestBall < Score)
        {
            BestBall = Score;
            // Save the best ball score to PlayerPrefs
            PlayerPrefs.SetInt("BestBall", BestBall);
            PlayerPrefs.Save();
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                print("Hleoo");
                 rb.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);
            }
            if (other.gameObject.CompareTag("Ball"))
            {
                patical.SetActive(true);
               // PlusPatical.SetActive(true);
                patical.GetComponent<ParticleSystem>().Play();
               // PlusPatical.GetComponent<ParticleSystem>().Play();
                StartCoroutine(wiatpaticla());
                NumScore.SetActive(true);
                PlusNum.Play("+1");
                Score++;
                music.Musics[1].Play();
                StartCoroutine(StartWait());
            }
        }
        

    }
    public void RestartGame()
    {
        Score = 0;
        lift = 5;
        PanelOver.SetActive(false);
        IsOVer = true;
        speedInstance = 0;
        foreach(var ball in BallFalse)
        {
            ball.SetActive(false);
        }
        
    }
    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(0.13f);
        NumScore.SetActive(false);
        PlusNum.Play("idle+1");
    }
    public static int BestBall { get; private set; } 
    IEnumerator wiatpaticla()
    {
        yield return new WaitForSeconds(3f);
        patical.SetActive(false);
       // PlusPatical.SetActive(false);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static ControllPlayer;
using static Music;

public class Destroy : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Weapone"))
        {
            Destroy(other.gameObject,0.3f);
           
            IsOVer = true;
            lift--;
            if (lift > 0)
            {
                if (lift == 4)
                    Instance.BallFalse[0].SetActive(true);
                else if (lift == 3)
                    Instance.BallFalse[1].SetActive(true);
                else if (lift == 2)
                    Instance.BallFalse[2].SetActive(true);
                else if (lift == 1)
                    Instance.BallFalse[3].SetActive(true);

                music.Musics[2].Play();
            }
            else 
            {
                Instance.BallFalse[4].SetActive(true);
                IsOVer = false;
                Instance.PanelOver.SetActive(true);
                
                Instance.BestText.text = "BEST : " + BestBall.ToString();
                Instance.OverText.text = "score :" + Score.ToString();
                music.Musics[3].Play();

            }
        }
    }
}

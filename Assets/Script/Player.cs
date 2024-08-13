using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using static Music;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator Player;
    private bool isMoving = false;
    private bool face = true;
    public Transform left_position, right_position;
    public GameObject Hand1, Hand2;
    public GameObject RunPatical;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = true;
            RunPatical.SetActive(true);
            RunPatical.GetComponent<ParticleSystem>().Play();
            Hand1.SetActive(false);
            Hand2.SetActive(false);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
            RunPatical.SetActive(false);
        }

        if (isMoving)
        {
            
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x < transform.position.x && transform.position.x > left_position.position.x)
            {
                MoveLeft();
                
                face = true;
            }
            else if (mousePos.x > transform.position.x && transform.position.x < right_position.position.x)
            {
                MoveRight();              
                face = false;
            }
        }
    }

    private void MoveLeft()
    {
        float targetX = Mathf.Max(transform.position.x + Vector3.left.x * moveSpeed * Time.deltaTime, left_position.position.x);
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }

    private void MoveRight()
    {
        float targetX = Mathf.Min(transform.position.x + Vector3.right.x * moveSpeed * Time.deltaTime, right_position.position.x);
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }

    public void Home()
    {
        SceneManager.LoadScene("Home");
    }
}

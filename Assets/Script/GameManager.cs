using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform Startpoint;
    public Transform Spawnpoint;
    public GameObject pinprefab;
    private Pinfly currentpin;
    private bool isGameOver = false;
    private int score = 0;
    public Text ScoreText;
    private Camera Maincamera;
    public float speed=3;
    void Start()
    {
        Spawnpin();
        Maincamera = Camera.main;
        
    }


    void Update()
    {
        if (isGameOver) return;
        
        if (Input.GetMouseButtonDown(0)|| Input.touchCount == 1)
        {
            score++;
            ScoreText.text = score.ToString();
            currentpin.StartFly();
            Spawnpin();
        }
    }

    void Spawnpin()
    {
        currentpin = GameObject.Instantiate(pinprefab, Spawnpoint.position, pinprefab.transform.rotation).GetComponent<Pinfly>();
    }
    public void Gameover()
    {
        if (isGameOver) return;
        GameObject.Find("Circle").GetComponent<rotatecircle>().enabled = false;
        StartCoroutine(GameOverAni());
        isGameOver = true;
    }

    IEnumerator GameOverAni()
    {
        while (true)
        {
            Maincamera.backgroundColor = Color.Lerp(Maincamera.backgroundColor, Color.red, speed * Time.deltaTime);
            Maincamera.orthographicSize = Mathf.Lerp(Maincamera.orthographicSize, 4, speed * Time.deltaTime);
            if (Mathf.Abs(Maincamera.orthographicSize - 4) < 0.01f)
            {
                break;
            }
            yield return (0);

        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

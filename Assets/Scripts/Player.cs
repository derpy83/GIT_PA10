using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public float jump = 100f;
    private Rigidbody birdrigid;
    [SerializeField] private Text Txt_Score = null;

    private int Score = 0;
   
    void Start()
    {
        Score = 0;
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        birdrigid = GetComponent<Rigidbody>();
        Txt_Score.text = "SCORE : 0";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            thisAnimation.Play();
        }
            
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bound")
        {
            SceneManager.LoadScene("Gameover");
        }
        if (other.gameObject.tag == "score")
        {
            Score += 1;
            Txt_Score.text = "SCORE : " + Score;
        }
        if (other.gameObject.tag == "block")
        {
            SceneManager.LoadScene("Gameover");
        }
    }
    public void Jump()
    {
        birdrigid.velocity = Vector3.up * jump;
    }
    
}

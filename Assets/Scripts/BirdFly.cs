using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    public float upForce = 200f;
    
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Fly();
        Die();
    }
    private void Fly()
    {
        if (GameManager.instance.IsDead)
            return;
        if(GameManager.instance.tipObject.activeSelf)
        {
            rb2d.gravityScale =0.0f;

        }
        else
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                rb2d.gravityScale =1.0f;
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.birdFlap,0.5f);
            }
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.instance.tipObject.SetActive(false);
        }
        
    }
    public void FlyWithTap()
    {
        Fly();
    }
    private void Die()
    {
        if(GameManager.instance.IsDead)
        {
            GameManager.instance.RankBoard.SetActive(true);
            GameManager.instance.currentText.text=GameManager.instance.score.ToString();
            if(GameManager.instance.score>GameManager.instance.bestScore)
            {
                PlayerPrefs.SetInt("bestScore", GameManager.instance.score);
                PlayerPrefs.Save();
            }
            GameManager.instance.bestScoreText.text=PlayerPrefs.GetInt("bestScore", 0).ToString();
        }
        else
        {
            return;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="PointScore")
        {
            GameManager.instance.AddScore();
            AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.audioPoint,0.5f);
            
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!GameManager.instance.IsDead)
        {
            if(other.gameObject.tag=="Pipe" || other.gameObject.tag=="Ground")
            {
                GameManager.instance.IsDead=true;
                AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.hitBird,0.5f);
                
                AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.birdDie,0.5f);
            }
        }
    }
    
}

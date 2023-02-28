using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool isAlive = true;
    [SerializeField] private static float Score = 0f;
    [SerializeField] private Collider2D standingCollider;
    public Text scoreTxt;
    public GameObject gameOverText;
    public GameObject gameOverButton;
    Animation anim;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Score = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        Press();
        IsAlive();
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(Shrink());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            isAlive = false;
            Time.timeScale = 0;
            gameOverButton.SetActive(true);
            gameOverText.SetActive(true);
            gameOverButton.SetActive(true);
        }
    }
    private void Press()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded == true)
            {
                rb.AddForce(Vector2.up * jumpForce);
                isGrounded = false;
            }

        } 
    }
    IEnumerator Shrink()
    {             
        if (isGrounded==true)
        {
            gameObject.transform.localScale = new Vector3(2 , 2, 0);
            isGrounded= false;
            yield return new WaitForSeconds(2f);
            gameObject.transform.localScale = new Vector3(4, 4, 0);

        }       
    }
     private void IsAlive()
    {
        if (isAlive)
        {
            Score += Time.deltaTime * 6;

            scoreTxt.text = "Score : " + Mathf.Round(Score) .ToString();
        }    
    }
    public static float AddScore()
    {
        return Score;
    }
}
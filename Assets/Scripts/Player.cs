using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public string currentColor;
    public Color colorCyan;
    public Color colorYellow;
    public Color colorPurple;
    public Color colorPink;
    public float score=0;
    public TextMeshProUGUI scoreText;
    public GameObject obstaclesPrefab;
    void Start()
    {
        SetRandomColor();
    }
    void ActivePlayer()
    {
        gameObject.SetActive(true);
    }

    void Update(){
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)){
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = Vector2.up * jumpForce;
        }
        scoreText.text = "" + score;
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "ColorChanger")
        {
            SetRandomColor();
            //Spawn();
            Destroy(col.gameObject);
            return;
        }
        if (col.tag == "Star")
        {
            score +=1;
            Destroy(col.gameObject);
        }
        else if (col.tag != currentColor || col.tag == "Ground")
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene(2);
        }
    }
    void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Purple";
                sr.color = colorPurple;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;            
        }
    }

    /*public void Spawn()
    {
        GameObject obstaclesPrefab = Instantiate(obstaclesPrefab, transform.position, transform.rotation);     
        obstaclesPrefab.transform.localScale = new Vector3(0, 2f, 0); 
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public int keys = 0;
    public TMPro.TextMeshProUGUI KeyAmount;
    public TMPro.TextMeshProUGUI WinText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime,0,0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime,0,0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0,speed * Time.deltaTime,0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0,-speed * Time.deltaTime,0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemies")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.gameObject.tag == "Door" && keys == 3)
        {
            Debug.Log("You win!");
            WinText.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "Keys")
        {
            keys++;
            KeyAmount.text = "Keys: " + keys.ToString();
            Destroy(collision.gameObject);
        }
    }   
}

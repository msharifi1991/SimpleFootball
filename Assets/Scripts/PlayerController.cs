using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public GameObject WinText;

    float xInput;
    float yInput;

    int CoinsCollected;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        if (transform.position.y < -5f)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void FixedUpdate()
    {
        rb.AddForce(xInput * moveSpeed, 0, yInput * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin") {

            CoinsCollected++;
            other.gameObject.SetActive(false);
        }
        if (CoinsCollected > 25) { 
        
            WinText.SetActive(true);
        }

    }

}

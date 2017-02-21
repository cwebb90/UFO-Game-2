using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int count;
    public Text countText;
    public Text winText;
    public float speed;

    private void Start()
    {
        //get and store a reference to the rigidbody2d component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        winText.text = "";
        SetCountText();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PickUp"))
        {
            collision.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 10)
        {
            winText.text = "You win!";
        }
    }
}

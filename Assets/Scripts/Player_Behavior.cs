using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class Player_Behavior : MonoBehaviour {
    public Text Text;
    public Text winText;

    private Rigidbody rb;
    private int score;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetText();
        Text.text = "Score: " + score.ToString ();
        winText.text = "";
    }
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name == "collectable")
        {
            score += 1;
            Destroy(col.gameObject);
            Text.text = "score: " + score.ToString();
            SetText();
        }
    }

    // Update is called once per frame
    void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
       
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement*2);
    }
    void SetText()
    {
        Text.text = "Score: " + score.ToString();
        if (score >= 6)
        {
            winText.text = "YOU WIN!";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public float speedH = 1.0f;
    public float speedV = 1.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public CharacterController controller;
    private float speed = 2f;

    Vector3 targetPos;

    public UIText uText; 

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        targetPos = transform.position;

        uText = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIText>(); // access UIText script
    }

    void MouseLook()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    void CameraMove() 
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("You got bitten!");
            ScoreMenu.resulttextstr = "YOU DIED!";
            ScoreMenu.finalscorestr = "SCORE: " + uText.score; // access score variable from UIText 
            SceneManager.LoadScene("ScoreMenu"); // loads ScoreMenu scene with the text 'YOU DIED!'
        } 
        else if (col.gameObject.tag == "Finish")
        {
            ScoreMenu.resulttextstr = "YOU WIN!";
            SceneManager.LoadScene("ScoreMenu"); // loads ScoreMenu scene with the text 'YOU WIN!'
        }
    }


    // Update is called once per frame
    void Update()
    {
        MouseLook();
        CameraMove();

        transform.position = new Vector3(transform.position.x, targetPos.y, transform.position.z); // lock y position

    }
}

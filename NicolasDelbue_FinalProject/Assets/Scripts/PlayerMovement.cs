using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float xInput, yInput;
    [SerializeField] private Transform playerPosition;
    public float playerSpeed = 5.0f;
    void Start()
    {
        if(SceneManage.GetSceneNum() == 1 && PlayerPrefs.GetInt("Saved") == 1)
        {
            gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("XPos"),PlayerPrefs.GetFloat("YPos"), PlayerPrefs.GetFloat("ZPos"));
        }
        else
        {
            gameObject.transform.position = new Vector3(0,0,0);
        }
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        CheckInput();
    }
    void FixedUpdate()
    {
        PlayerPhysics();
    }
    void PlayerPhysics()
    {
        if(xInput != 0 && yInput != 0)
        {
            xInput *= .7f;
            yInput *= .7f;
        }
        rb2d.velocity = new Vector2(xInput*playerSpeed, yInput*playerSpeed);
    }
    void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Door"))
        {
            if(col.gameObject.GetComponent<ShopInfo>().GetOpen())
            {
                SaveLocation();
                SceneManage.ChangeScene(2);
                Debug.Log("Change To Shop");
            }
        }
        if(col.CompareTag("ExitDoor"))
        {
            SceneManage.ChangeScene(1);
        }
    }
    void SaveLocation()
    {
        PlayerPrefs.SetFloat("XPos", (gameObject.transform.position.x));
        PlayerPrefs.SetFloat("YPos", (gameObject.transform.position.y - 0.5f));
        PlayerPrefs.SetFloat("ZPos", (gameObject.transform.position.z));
        PlayerPrefs.SetInt("Saved", 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour
{
    public GameObject Player;
    public GameObject Jumper;
    public GameObject Shooter;
    public GameObject jExplode;
    public GameObject sExplode;
    public GameObject Bullet;

    private Rigidbody rigid;

    public bool canJump;
    public bool inTheAir;
    public bool isJumper;
    public bool isShooter;
    public bool hasAmmo;
    public static bool isGod;

    public static bool isAlive;
    public static bool MusicOn;


    Vector3 startPos;

    public int ammo;
    public int tries;

    public delegate void OnDeath();
    public static event OnDeath onDeath;

    public Text deathText;

    void Awake()
    {
        Time.timeScale = 1.0f;
        Player = gameObject;
        rigid = gameObject.GetComponent<Rigidbody>();
        startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        tries = 0;
        hasAmmo = true;
      
        Die();
    }

   
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            if (isGod == true)
            {
                isGod = false;
                backgroundScroll.speed = -7f;

            }
            else
            {
                isGod = true;
                backgroundScroll.speed = -21f;
            }
        }

        if (isGod == true)
        {
            canJump = true;
        }

        if (isJumper == true)
        {
            if (canJump == true)
            {
                if (Input.GetKey(KeyCode.Space))
                {

                    rigid.velocity = new Vector3(0, 10f, 0);
                    Debug.Log(rigid.velocity);
                    canJump = false;
                    StartCoroutine(FasterFalling());


                }
            }
        }



        if (isShooter == true)
        {
            if (hasAmmo == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Instantiate(Bullet, new Vector3(Player.transform.position.x + 1.5f, Player.transform.position.y + 1f, Player.transform.position.z), Quaternion.identity);
                    ammo--;
                }
            }
        }

        /*if (ammo <= 0)
        {
            hasAmmo = false;
        }
        else
        {
            hasAmmo = true;
        }*/


        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isJumper == true)
            {
                playShooter();
            }
            else
            {
                playJumper();
            }
        }

        switch (tries)
        {
            case 0:
                deathText.text = "";
                break;

            case 1:
                deathText.GetComponent<Text>().resizeTextForBestFit = true;
                deathText.text = "First Try!";
                break;

            case 2:
                deathText.GetComponent<Text>().resizeTextForBestFit = true;
                deathText.text = "Second First Try!";
                break;

            case 3:
                deathText.GetComponent<Text>().resizeTextForBestFit = true;
                deathText.text = "Third times the Charm!";
                break;

            case 22:
                deathText.GetComponent<Text>().resizeTextForBestFit = true;
                deathText.text = "Im feeling " + tries;
                break;

            case 23:
                deathText.GetComponent<Text>().resizeTextForBestFit = true;
                deathText.text = "Jordan Attempt";
                break;

            case 42:
                deathText.GetComponent<Text>().resizeTextForBestFit = true;
                deathText.text = "The Ultimate Answer Attempt";
                break;

            case 69:
                deathText.GetComponent<Text>().resizeTextForBestFit = true;
                deathText.text = "Nice";
                break;

            case 100:
                deathText.GetComponent<Text>().resizeTextForBestFit = true;
                deathText.text = "Attempt: 1 hunnid";
                break;

            default:
                deathText.GetComponent<Text>().resizeTextForBestFit = false;
                deathText.text = "Attempt: " + tries;
                break;

        }


    }


    private void OnTriggerEnter(Collider other)
    {

        if (isGod != true)
        {

            if (other.gameObject.CompareTag("Jump"))
            {
                canJump = true;
                other.gameObject.SetActive(false);
            }

            if (other.gameObject.CompareTag("die"))
            {
                Die();

            }

            if (other.gameObject.CompareTag("text"))
            {
                deathText.enabled = false;
            }
        }

        if (other.gameObject.CompareTag("spring"))
        {
            rigid.velocity = Vector3.up * 20f;
            StartCoroutine(FasterFalling());
        }


        if (other.gameObject.CompareTag("switch"))
        {
            rigid.velocity = Vector3.down * 23f;
        }

        if (other.gameObject.CompareTag("End"))
        {
            deathText.GetComponent<Text>().resizeTextForBestFit = true;
            deathText.text = "YOU WON ON " + tries;
            deathText.enabled = true;
            backgroundScroll.speed = 0;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            inTheAir = false;
            canJump = true;

        }

        if (isGod != true)
        {
            if (collision.gameObject.CompareTag("enemy"))
            {
                Die();

            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            StartCoroutine(FasterFalling());
        }
    }

    void Die()
    {

        if (onDeath != null)
        {
            onDeath();
        }

        Debug.Log("You died");
        tries++;
        isAlive = false;
        Player.SetActive(false);

        Time.timeScale = .5f;
        if (isJumper == true)
        {
            Instantiate(jExplode, new Vector3(Player.transform.position.x + .5f, Player.transform.position.y, Player.transform.position.z), Quaternion.identity);

        }
        else if (isShooter == true)
        {
            Instantiate(sExplode, new Vector3(Player.transform.position.x + .5f, Player.transform.position.y, Player.transform.position.z), Quaternion.identity);
        }

        Invoke("Spawn", 1.0f);

    }

    void Spawn()
    {
        deathText.enabled = true;
        Player.transform.position = startPos;
        Time.timeScale = 1.0f;
        isAlive = true;
        MusicOn = true;
        playJumper();
        Player.SetActive(true);
        ammo = 5;

    }

    void playJumper()
    {
        Jumper.SetActive(true);
        isJumper = true;
        Shooter.SetActive(false);
        isShooter = false;
    }

    void playShooter()
    {
        Jumper.SetActive(false);
        isJumper = false;
        Shooter.SetActive(true);
        isShooter = true;
    }

    IEnumerator FasterFalling()
    {
        yield return new WaitForSeconds(.3f);
        rigid.velocity = Vector3.down * 5f;


    }


}

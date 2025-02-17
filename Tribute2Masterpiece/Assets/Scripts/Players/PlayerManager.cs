using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject PlayerA; // Using KEYBOARD
    public GameObject PlayerB; // Using MOUSE

    [HideInInspector]
    public Transform posA; // Get Coordinates for POSITION
    [HideInInspector]
    public Transform posB;

    Vector3 InitPosA = new Vector3(-4.5f, 0f, 0f); // Initial Positions of 2 Player
    Vector3 InitPosB = new Vector3(4.5f, 0f, 0f);

    SpriteRenderer sprdA;
    SpriteRenderer sprdB;

    [HideInInspector]
    public bool playerSmash = false;

    private Color greyColor = new Color(0.3f, 0.3f, 0.3f, 1f);
    private Color colorA;
    private Color colorB;

    public float delayTime = 0.5f;
    private float timer = 0f;

    public GameObject SoundManager;
    private SoundManager soundManager;
    //private Vector3 originalCameraPosition;

    void Start()
    {
        posA = PlayerA.GetComponent<Transform>();
        posB = PlayerB.GetComponent<Transform>();
        posA.position = InitPosA;
        posB.position = InitPosB;

        sprdA = PlayerA.GetComponent<SpriteRenderer>();
        sprdB = PlayerB.GetComponent<SpriteRenderer>();
        colorA = sprdA.color;
        colorB = sprdB.color;
        soundManager = SoundManager.GetComponent<SoundManager>();
        //originalCameraPosition = new Vector3(0f, 0f, -10f);
    }

    void Update()
    {
        if ((posB.position.x - posA.position.x == 2) && (posB.position.y == posA.position.y))
        {
            playerSmash = true;
            soundManager.PlayerBoom();//������
        }

        if (!playerSmash) timer = 0f;
        else
        {
            
            sprdA.color = greyColor;
            sprdB.color = greyColor;
            // Debug.Log(delayTime);
            if (timer <= delayTime) timer += Time.deltaTime;
            else
            {
                playerSmash = false;
                soundManager.Boom.SetActive(false);
                soundManager.reCarema();
                sprdA.color = colorA;
                sprdB.color = colorB;
            }
        }
    }
}

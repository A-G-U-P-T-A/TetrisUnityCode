﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetramino : MonoBehaviour
{
    float fall = 0;
    public float fall_speed = 1;
    public bool allowRotation = true;
    public bool limitRotation = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckUserInput();
    }

    void CheckUserInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.position += new Vector3(1, 0, 0);
            if (CheckIsValidPosition()){
                FindObjectOfType<Game>().updateGrid(this);
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.position += new Vector3(-1, 0, 0);
            if (CheckIsValidPosition()){ 
                FindObjectOfType<Game>().updateGrid(this); 
            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (allowRotation)
            {
                if (limitRotation)
                {
                    if (transform.rotation.eulerAngles.z >= 90)
                    {
                        transform.Rotate(0, 0, -90);
                    }
                    else
                    {
                        transform.Rotate(0, 0, 90);
                    }
                }
                else
                {
                    transform.Rotate(0, 0, 90);
                }
                if (CheckIsValidPosition()) {
                    FindObjectOfType<Game>().updateGrid(this);
                }
                else
                {
                    if (limitRotation)
                    {
                        if (transform.rotation.eulerAngles.z >= 90)
                            transform.Rotate(0, 0, -90);
                        else
                            transform.Rotate(0, 0, 90);
                    }
                    else
                    {
                        transform.Rotate(0, 0, -90);
                    }
                }
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)|| Time.time-fall >= fall_speed) {
            transform.position += new Vector3(0, -1, 0);
            if (CheckIsValidPosition()) {
                FindObjectOfType<Game>().updateGrid(this);
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                enabled = false;
                FindObjectOfType<Game>().SpawnNextTetramino();
            }
            fall = Time.time;
        }
    }

    bool CheckIsValidPosition()
    {
        foreach(Transform mino in transform)
        {
            Vector2 pos = FindObjectOfType<Game>().round(mino.position);
            if (!FindObjectOfType<Game>().CheckIsInsideGrid(pos))
            {
                return false;
            }
            else
            {

            }
        }
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLogic : MonoBehaviour
{
    public static BlockLogic Instance;

    GameLogic gameLogic;

    float timer = 0f;

    bool Moveable = true;

    public GameObject rig;


    public void Awake()
    {
        Instance = this;
        gameLogic = FindObjectOfType<GameLogic>();

    }

    void Update()
    {
        if (Moveable && GameManager.Instance.isGameActive == true)
        {
            timer += 1 * Time.deltaTime;

            gameLogic.ClearLines();

            for (int i = 1; i < ScoreManager.Instance.level; i++)
            {
                if(ScoreManager.Instance.level >= i)
                {
                    timer += ++i * Time.deltaTime;
                }
            }

            if (Input.GetKey(KeyCode.DownArrow) && timer > GameLogic.Instance.quickDropTime)
            {
                gameObject.transform.position -= new Vector3(0, 1, 0);

                timer = 0f;

                if (!CheckValid())
                {
                    

                    Moveable = false;

                    gameObject.transform.position += new Vector3(0, 1, 0);

                    RegisterBlock();

                    gameLogic.SpawnBlock();
                }

                
            }

            else if (timer > GameLogic.Instance.droptime)
            {
                gameObject.transform.position -= new Vector3(0, 1, 0);

                timer = 0f;

                if (!CheckValid())
                {
                    Moveable = false;

                    gameObject.transform.position += new Vector3(0, 1, 0);

                    RegisterBlock();

                    //gameLogic.ClearLines();

                    gameLogic.SpawnBlock();
                }
            }


            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                gameObject.transform.position -= new Vector3(1, 0, 0);

                if (!CheckValid())
                {
                    
                    gameObject.transform.position += new Vector3(1, 0, 0);
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                gameObject.transform.position += new Vector3(1, 0, 0);

                if (!CheckValid())
                {
                    
                    gameObject.transform.position -= new Vector3(1, 0, 0);
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rig.transform.eulerAngles -= new Vector3(0, 0, 90);

                if (!CheckValid())
                {

                    rig.transform.eulerAngles += new Vector3(0, 0, 90);
                }
            }
        }
    }

    void RegisterBlock()
    {
        foreach (Transform subBlock in rig.transform)
        {
            gameLogic.grid[Mathf.FloorToInt(subBlock.position.x), Mathf.FloorToInt(subBlock.position.y)] = subBlock;

        }
    }


    

    bool CheckValid()
    {
        foreach (Transform subBlock in rig.transform)
        {
            if (subBlock.transform.position.x >= GameLogic.width || subBlock.transform.position.x < 0 || subBlock.transform.position.y < 0)
            {
                return false;
            }

            if (subBlock.position.y < GameLogic.height && gameLogic.grid[Mathf.FloorToInt(subBlock.position.x), Mathf.FloorToInt(subBlock.position.y)] != null)
            {
                return false;
            }
        }

        return true;
    }

    

}


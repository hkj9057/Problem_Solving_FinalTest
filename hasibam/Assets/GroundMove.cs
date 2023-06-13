using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public SpriteRenderer[] tiles;
    public Sprite[] groundImg;
    public float speed;

    void Start()
    {
        temp = tiles[0];
    }
    SpriteRenderer temp;

    public void gMove()
    {
        if (GameManager.instance.isPlay)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tiles[i].transform.position.x <= -10.5f)
                {
                    for (int j = 0; j < tiles.Length; j++)
                    {
                        if (temp.transform.position.x < tiles[j].transform.position.x)
                            temp = tiles[j];
                    }
                    tiles[i].transform.position = new Vector2
                        (temp.transform.position.x + 2.3f, -3.6f);
                    tiles[i].sprite = groundImg[Random.Range(0, groundImg.Length)];
                }
            }
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].transform.Translate(new Vector2(-1, 0)
                    * Time.deltaTime * GameManager.instance.gameSpeed);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ManageScript : MonoBehaviour
{
    public int size_x;
    public int size_y;
    public TextMeshProUGUI text_x;
    public TextMeshProUGUI text_y;
    public GameObject sizes;
    public GameObject square_prefub;
    public GameObject next_round;
    public bool automation = true;
    public GameObject check_image;
    public GameObject[] squares;
    public bool first_click;

    void Update()
    {
        if(first_click == true & automation == true)
        {
            round();
        }
    }
    void Start()
    {
        next_round.SetActive(false);
    }
    public void down_x()
    {
        size_x = size_x -1;
        text_x.text = size_x.ToString();
    }
    public void up_x()
    {
        size_x++;
        text_x.text = size_x.ToString();
    }
    public void down_y()
    {
        size_y = size_y -1;
        text_y.text = size_y.ToString();
    }
    public void up_y()
    {
        size_y++;
        text_y.text = size_y.ToString();
    }
    public void Start_game()
    {
        sizes.SetActive(false);
        for(int x = 1; x <= size_x; x++)
        {
            for (int y =1; y<= size_y; y++)
            {
                Instantiate(square_prefub, new Vector3(x,y,0f), Quaternion.identity);
            }
        }
        next_round.SetActive(true);
    }
    public void change_automation()
    {
        if (automation == true)
        {
            automation = false;
            check_image.SetActive(false);
        }
        else
        {
            automation = true;
            check_image.SetActive(true);
        }
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.1f);
    }
    public void round()
    {
        first_click = true;
        for (int i = 0; i < squares.Length; i++)
        {
            squares[i].GetComponent<Square>().calculate();
        }
        for (int i = 0; i < squares.Length; i++)
        {
            squares[i].GetComponent<Square>().round_squ();
        }
        StartCoroutine(waiter());
    }
    public void check_squares()
    {
        squares = GameObject.FindGameObjectsWithTag("square");
    }
    public void random_alives()
    {
        for (int i = 0; i < squares.Length; i++)
        {
            int random = Random.Range(1, 3);
            if (random == 1)
            {
                squares[i].GetComponent<Square>().alive = true;
                squares[i].GetComponent<Square>().check_alive();
            }
            else
            {
                squares[i].GetComponent<Square>().alive = false;
                squares[i].GetComponent<Square>().check_alive();
            }
        }
    }
    public void Clear()
    {
        for (int i = 0; i < squares.Length; i++)
        {
            squares[i].GetComponent<Square>().death();
        }
    }
}

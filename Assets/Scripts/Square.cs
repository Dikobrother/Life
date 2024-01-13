using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Square : MonoBehaviour
{
    public bool alive = false;
    public int neighbours_ = 0;
    public string next_round = "nothing";

    void Start()
    {
        check_alive();
        neighbours_ = count_neighbours();
    }
    void Update() 
    { 
        
    }
    public int count_neighbours()
    {
        GameObject[] squares = GameObject.FindGameObjectsWithTag("square");
        int neighbours = 0;
        for(int i = 0; i < squares.Length; i++)
        {
            float margin_y = Mathf.Max(squares[i].transform.position.y, transform.position.y) - Mathf.Min(squares[i].transform.position.y, transform.position.y);
            float margin_x = Mathf.Max(squares[i].transform.position.x, transform.position.x) - Mathf.Min(squares[i].transform.position.x, transform.position.x);
            if (((margin_y == 1f & margin_x == 1f) | (margin_y == 1f & margin_x == 0f) | (margin_y == 0f & margin_x == 1f)) & squares[i].GetComponent<Square>().alive == true)
            {
                neighbours++;
            }
            
            
        }
        //if (alive == true)
        //{
        //    neighbours--;
        //}
        return (neighbours);
    }
    public void check_alive()
    {
        if (alive == true)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    public void OnMouseDown()
    {
       change_alive();
    }
    public void change_alive()
    {
        if (alive == true)
        {
            alive = false;
            check_alive();
        }
        else
        {
            alive = true;
            check_alive();
        }
    }
    public void death()
    {
        alive = false;
        check_alive();
    }
    public void born()
    {
        alive = true;
        check_alive();
    }
    public void round_squ()
    {
        if(next_round == "born")
        {
            born();
        }
        else if(next_round == "death")
        {
            death();
        }
        
    }
    public void calculate()
    {
        neighbours_ = count_neighbours();
        if (neighbours_ == 3 & alive == false)
        {
            next_round = "born";
        }
        else if (alive == true & (neighbours_ == 2 | neighbours_ == 3))
        { 
            next_round = "nothing";
        }
        else
        {
            next_round = "death";
        }
    }


}

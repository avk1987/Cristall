using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fall : MonoBehaviour
{
    public string color;
    private CreateGame obj;
    private bool makemove = false;
    private Vector3 firstStartPos;
    private Vector3 SecondStartPos;
    private GameObject first;
    private GameObject second;

    void Start()
    {
        obj = Camera.main.GetComponent<CreateGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (makemove)
        {

            first.GetComponent<Collider2D>().enabled  = false;
            second.GetComponent<Collider2D>().enabled = false;

            first.transform.position  = Vector2.MoveTowards(first.transform.position, SecondStartPos, Time.deltaTime * 2f);
            second.transform.position = Vector2.MoveTowards(second.transform.position, firstStartPos, Time.deltaTime * 2f);

            if (firstStartPos == second.transform.position)
            {
                first.GetComponent<Collider2D>().enabled  = true;
                second.GetComponent<Collider2D>().enabled = true;
                Debug.Log("HAva");
                makemove = false;
            }

           // makemove = false;
        } else  // gravity
        {/*
            Vector2 nw = transform.position;
            nw.y = nw.y - 0.5f;
            RaycastHit2D hit = Physics2D.Raycast(nw, Vector2.down);
            Vector2 dest = hit.transform.position;
            dest.y = dest.y + 1;
            dest.x = transform.position.x;
            transform.position = Vector2.MoveTowards(transform.position, dest, Time.deltaTime * 1);
            */
        }


    }

    private void OnMouseDown()
    {
       // Destroy(this.gameObject);
      //  CreateGame obj = Camera.main.GetComponent<CreateGame>();
       
        if (obj.firtst ==null)
        {
            obj.firtst = this.gameObject;
            obj.Status.color = Color.yellow;
            obj.Status.text = "WAITING...";

        } else
        {
            obj.second = this.gameObject;

            if(isnear(obj.firtst, obj.second)) // need clean
            {
                obj.Status.color = Color.green;
                obj.Status.text = "true";
                makemove = true;
                first  = obj.firtst;
                second = obj.second;

                firstStartPos  = obj.firtst.transform.position;
                SecondStartPos = obj.second.transform.position;

            } else
            {
                obj.Status.color = Color.red;
                obj.Status.text = "false";
            }

            obj.firtst = null;
            obj.second = null;
        } 
    }

    private bool isnear(GameObject first, GameObject second)
    {

        int fx = (int)first.transform.position.x;
        int sx = (int)second.transform.position.x;
        int fy = (int)first.transform.position.y;
        int sy = (int)second.transform.position.y;


        if (((fx-sx == 1)|| (fx-sx == -1)) & (fy == sy)) // проверка по горизонтали
        {
            return true;   // значит по x они рядом

        }

        if (((fy - sy == 1) || (fy - sy == -1)) & (fx == sx)) // проверка по вертикали
        {
            return true;   // значит по y они рядом
        }

        return false;
    }
}

//Destroy(gameObject);
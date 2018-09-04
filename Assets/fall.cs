using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{
    public string color;

    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 nw = transform.position;
        nw.y = nw.y - 0.5f;
        RaycastHit2D hit = Physics2D.Raycast(nw, Vector2.down);
        Vector2 dest = hit.transform.position;
        dest.y = dest.y + 1;
        dest.x = transform.position.x;
        transform.position = Vector2.MoveTowards(transform.position, dest, Time.deltaTime * 20);
    }

    private void OnMouseDown()
    {
        CreateGame obj = Camera.main.GetComponent<CreateGame>();
        
        if (obj.firtst ==null)
        {
            obj.firtst = this.gameObject;
        } else
        {
            obj.second = this.gameObject;
            if(isnear(obj.firtst, obj.second))
            {
                //сделать ход
            }
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
            return true;   // значит по иксу они рядом
        }

        return false;
    }
}

//Destroy(gameObject);
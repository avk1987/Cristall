using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGame : MonoBehaviour {

    public GameObject firtst;
    public GameObject second;

    public GameObject prefab;
    private float y =  0.5f;


    void Start () {

        while(y < 19) {
           float x = -12.5f;

            while (x < 13.5f)
            {
               GameObject go = Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);  
               GerRndColor(go, x, y);
                x++;
             }
             y++;
           
        }
    }
	
    void GerRndColor(GameObject go, float x, float y)
    {
        SpriteRenderer SprRen = go.GetComponent<SpriteRenderer>();
        int rnd = (int)Random.Range(1, 5);


        switch (rnd)
        {
            case 1:
                SprRen.color = Color.red;
                break;
            case 2:
                SprRen.color = Color.green;
                break;
            case 3:
                SprRen.color = Color.blue;
                break;
            case 4:
                SprRen.color = Color.yellow;
                break;
        }

        go.GetComponent<fall>().color = rnd.ToString();
        go.name = x.ToString() + "|" + y.ToString();

    }
}

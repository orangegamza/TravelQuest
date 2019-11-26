using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour {

    public GPS gps;
    public GameObject[] mascots;

    public GameObject grid;

    public GameObject rabbit;
    public GameObject turtle;
    public GameObject penguin;

    public void SetBook()
    {
        Debug.Log("Turtle: " + gps.HasTurtle);
        Debug.Log("Rabbit: " + gps.HasRabbit);
        Debug.Log("Penguin: " + gps.HasPenguin);
        if (gps.HasTurtle)
        {
            var turt = Instantiate(turtle);
            turt.transform.SetParent(grid.transform);
        }
        if (gps.HasRabbit)
        {
            var rab = Instantiate(rabbit);
            rab.transform.SetParent(grid.transform);
        }
        if (gps.HasPenguin)
        {
            var pen = Instantiate(penguin);
            pen.transform.SetParent(grid.transform);
        }

        // myNewSmoke.transform.parent = gameObject.transform;
        //player.transform.SetParent(newParent);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isEmpty = true;
    public Unit unit;
    // Start is called before the first frame update

    public Tile() {
        unit = null;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Place(Unit unit)
    {
        this.unit = unit;
        if (unit != null)
        {   
            unit.unitSelected = false;
            isEmpty = false;
        }
    }

    public Unit Lift()
    {
        var ret = this.unit;
        if (this.unit != null)
        {
            ret.unitSelected = true;
            isEmpty = true;
            this.unit = null;
        }
        return ret;

    }
}

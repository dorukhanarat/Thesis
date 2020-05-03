using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier : MonoBehaviour
{

    [SerializeField] public string target;
    [SerializeField] public string key;
    [SerializeField] public string method;
    [SerializeField] public float value;


    // Start is called before the first frame update

    public Modifier(string target,string key, string method, float value) {
        this.target = target;
        this.key = key;
        this.method = method;
        this.value = value;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

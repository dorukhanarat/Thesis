using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Modifier modifier;
    public string nodeName;
    public bool isStart;
    public bool isSelected;
    protected string description;

    public List<Node> neighbors = new List<Node>();

    public Node(string nodeName, string description, string nodeType, bool isStart, Modifier modifier)
    {
        this.nodeName = nodeName;
        this.description = description;
        isSelected = false;
        this.isStart = isStart;
        this.modifier = modifier;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddNeighbor(Node node)
    {
        neighbors.Add(node);
    }
}

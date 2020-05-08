using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveTree : MonoBehaviour
{

    public bool newNodeSelected = false;
    public List<Node> selectedNodes = new List<Node>();
    public List<Node> nodes = new List<Node>();
    public bool isEligable = false;

    public PassiveTree() {
        
    }

    public void SelectNode(Node node)
    {
        if (node.isStart) {
            selectedNodes.Add(node);
            newNodeSelected = true;
        }
        else {
            foreach (Node selects in node.neighbors) {
                if (selects.isSelected) {
                    isEligable = true;
                }
            }
            if (isEligable) {
                selectedNodes.Add(node);
                newNodeSelected = true;
            }
        }
    }
}

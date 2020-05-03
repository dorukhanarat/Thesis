using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Tile[,] tiles = new Tile[8, 8];
    public Unit selectedPiece;
    public int boardX;
    public int boardY;

    public Board() {
        for(int i = 0; i < 8; i++) {
            for(int j = 0; j < 8; j++) {
                tiles[i,j] = new Tile(); 
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlacePiece(Tile tile)
    {
        if(selectedPiece != null) {
            var piece = selectedPiece;
            if (boardY > 4)
            {
                if (!tile.isEmpty)
                {
                selectedPiece = tile.Lift();
                }
                tiles[boardX, boardY].Place(piece);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] public int roundNumber = 1;
    [SerializeField] public int heroDamage;
    [SerializeField] public int minionDamage;
    [SerializeField] public bool minionRound = false;
    [SerializeField] public bool roundEnded = false;
    [SerializeField] public int neutralMinionCount = 1;
    [SerializeField] public float dropRate = 5f;
    public List<Unit> enemies = new List<Unit>();
    public Board board;
    public Player enemyPlayer;

    public RoundManager() {
        board = new Board();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextRound()
    {
        if (roundNumber < 4)
        {
            minionRound = true;
            neutralMinionCount++;
        }
        if ((roundNumber % 5 == 3) && (roundNumber > 3))
        {
            minionRound = true;
            heroDamage++;
            minionDamage++;
            neutralMinionCount++;
        }
        roundNumber++;
        ClearBoard();
    }

    public void ClearBoard() {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                board.tiles[i, j] = null;
            }
        }
    }


    public void StartRound()
    {    
        if (minionRound)
        {
            minionRound = false;
            for (int i = 0; i < neutralMinionCount; i++)
            {
                enemies.Add(new NeutralMinion());
                if(roundNumber > 3) {
                    foreach(NeutralMinion nm in enemies) {
                    nm.Empower();
                    }
                }               
            }
        }
        else
        {
            foreach (Unit enemy in enemyPlayer.units)
            {
                enemies.Add(enemy);
            }
        }
        PlaceEnemies();
    }

    public void PlaceEnemies()
    {
        if (minionRound)
        {
            foreach (Unit enemy in enemies)
            {
                int x = Random.Range(0, 8);
                int y = Random.Range(0, 4);
                if (board.tiles[x, y] == null)
                {
                    board.tiles[x, y].unit = enemy;
                }
                else
                {
                    while (board.tiles[x, y] != null)
                    {
                        x = Random.Range(0, 8);
                        y = Random.Range(0, 4);
                    }
                    board.tiles[x, y].unit = enemy;
                }
            }
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    board.tiles[7 - i, 7 - j] = enemyPlayer.board.tiles[i, j];
                }
            }
        }
    }
}

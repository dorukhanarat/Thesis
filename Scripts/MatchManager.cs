using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{

    public List<Player> players = new List<Player>();
    public int roundNumber = 1;
    public float roundTime = 25f;
    public float restTime = 15f;
    public bool gameOver = false;

    public MatchManager() {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(players.Count == 1) {
            MatchEnd();
        }
        
    }
    public void MatchEnd() {
    
            // Print win screeen for player.
            // End the match.
        
    }

    public void RoundStart() {
        foreach(Player player in players) {
            MatchPlayer(player);
            player.roundManager.StartRound();
        }
        Wait(roundTime);
        RoundEnd();
    }

    public void RoundEnd() {
        foreach(Player player in players) {
            player.roundManager.enemies.Clear();
            if(roundNumber % 10 == 0) {
                player.ascendancyPoints++;
            }
            player.isMatched = false;
            player.skillPoints++; 
            player.roundManager.NextRound();
        }
        Wait(restTime);
        roundNumber++;
        roundTime += 3;
        restTime += 3;
        RoundStart();
    }

    public void MatchPlayer(Player player) {
        players.Remove(player);
        int index = (int)(Random.Range(0,players.Count));
        while(players[index].isMatched) {
            index = (int)(Random.Range(0,players.Count));
        }
        players[index].isMatched = true;
        player.roundManager.enemyPlayer = players[index];
        players.Add(player);
    }

    public void PlayerRemove() {
        foreach(Player player in players) {
            if(player.health <= 0) {
                players.Remove(player);
                // Show game end screen for the spesific player.
                // Destroy player instances
            }
        }
    }

    public void PlayerAdd(Player player) {
        players.Add(player);
    }

    IEnumerator Wait(float length) {
        yield return new WaitForSeconds(length);
    }
}
   
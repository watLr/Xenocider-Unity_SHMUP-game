using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public int ScoreValue;
    private GameController gameController;

    private void Start()
    {
        /*If gameControllerObject can find the Game Controller in the inspector, then
         * get the GameController class components. Else, if it can't be found then
         * debug.log a message*/
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }else if(gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy")){
            return;
        }else{
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            PauseMenu.gameOver = true;
        }
        else
        {
            gameController.AddScore(ScoreValue);
        }
    }
}

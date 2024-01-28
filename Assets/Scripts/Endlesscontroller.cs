using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace CrazyDriver{


public class Endlesscontroller : MonoBehaviour
{public GameObject Player;
    public Transform pauseCanvas;
    public Transform gameOverCanvas;
     public Transform distanceCanvas;
     


      Vector3 originalPos;

        [Tooltip("How long to wait before starting the game. Ready? GO! time")]
        public float startDelay = 1;
        internal bool gameStarted = false;
        
        [Tooltip("The score of the player")]
        public int score;

        [Tooltip("How many points we get per second")]
        public int scorePerSecond = 1;

        [Tooltip("The score text object which displays the current score of the player")]
        public Transform scoreText;

        [Tooltip("Text that is appended to the score value. We use this to add a money sign to the score")]
        public string scoreTextSuffix = "$";

        [Tooltip("The player prefs record of the total score we have ( not high score, but total score we collected in all games which is used as money )")]
        public string moneyPlayerPrefs = "Money";

        public int highScore;
		internal int scoreMultiplier = 1;
        // The button that pauses the game. Clicking on the pause button in the UI also pauses the game
		public string pauseButton = "Cancel";
		internal bool  isPaused = false;

		// Is the game over?
		internal bool  isGameOver = false;

		 void Awake()
		{
            Time.timeScale = 1;

            // Activate the pause canvas early on, so it can detect info about sound volume state
            //if ( pauseCanvas )    pauseCanvas.gameObject.SetActive(true);

            //Get the number of the current item
            //GameObject.FindObjectOfType<ECCShop>().gameObject.SetActive(true);
          
gameOverCanvas.Find("Window/Content/Base/TextScore").GetComponent<Text>().text = "SCORE " + score.ToString();
        }

        void Start()
		{
            
            Player = GameObject.FindGameObjectWithTag ("Car");
            //Application.targetFrameRate = 30;

            // Update the score at 0
            ChangeScore(0);

          
                originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

            //Get the highscore for the player
            highScore = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "HighScore", 0);

        }
       public void reloadCars(){
            gameObject.transform.position = originalPos;
        }
        public void StartGame()
        {
         
            
            // The game has started
            gameStarted = true;
            

            // Add to the player's score every second
            if (scorePerSecond > 0)    InvokeRepeating("ScorePerSecond", startDelay, 1);

            
        }

      void Update()
		{
            Player = GameObject.FindObjectOfType<PlayerController>().gameObject;
            // If the game hasn't started yet, nothing happens
            if ( gameStarted == false) return;
            

			// Delay the start of the game
			if ( startDelay > 0 )
			{
				startDelay -= Time.deltaTime;
            }

            //  if(Player.gameObject == null){
            //         ChangeScore(0);


            //  }

            if (score > highScore)
            {
                highScore = score;

                //Register the new high score
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "HighScore", highScore);
            }




        }

    void SetScoreMultiplier( int setValue )
		{
			// Set the score multiplier
			scoreMultiplier = setValue;
		}
///<param name="changeValue">Change value</param>
        public void  ChangeScore( int changeValue )
		{
            // Change the score value
            if(Player.gameObject!=null){
                score += changeValue;

            //Update the score text
            if (scoreText)
            {
                scoreText.GetComponent<Text>().text = score.ToString();

            }

            }
            else{
                gameOverCanvas.gameObject.SetActive(true);
                   gameOverCanvas.Find("Window/Content/Base/TextScore").GetComponent<Text>().text = "SCORE " + score.ToString();
            }
			
        }
    public void ScorePerSecond()
        {
            ChangeScore(scorePerSecond);
        }

        
        public void Pause(bool showMenu)
        {
            isPaused = true;

            //Set timescale to 0, preventing anything from moving
            Time.timeScale = 0;

            //Show the pause screen and hide the game screen
            if (showMenu == true)
            {
                if (pauseCanvas) pauseCanvas.gameObject.SetActive(true);
            }
            else
            {
                // If showMenu is false, still display the pause overlay
                if (pauseCanvas) pauseCanvas.gameObject.SetActive(true);
                // Additionally, set isPaused to false to enable the game to resume when the pause button is pressed again
                isPaused = false;
            }
        }

     public void Unpause()
        {
            isPaused = false;

            //Set timescale back to the current game speed
            Time.timeScale = 1;

            //Hide the pause screen and show the game screen
            if (pauseCanvas) pauseCanvas.gameObject.SetActive(false);
        }

          IEnumerator GameOver(float delay)
		{
			isGameOver = true;

			yield return new WaitForSeconds(delay);
			

            //Show the game over screen
            if ( gameOverCanvas )    
			{
				//Show the game over screen
				gameOverCanvas.gameObject.SetActive(true);
				
				//Write the score text
				gameOverCanvas.Find("Window/Content/Base/TextScore").GetComponent<Text>().text = "SCORE " + score.ToString();

                //Check if we got a high score
                if (score > highScore)
                {
                    highScore = score;

                    //Register the new high score
                    PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "HighScore", score);
                }




            }
		}

   
        

}
}
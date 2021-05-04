using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState{
    menu,inGame,gameOver
}
public class GameManager : MonoBehaviour{
    //
    public GameObject UIScreen,GameOverScreen,LogoScreen,MenuScreen,CronomeScreen,creditScreen;
    //
    public GameState currentGameState = GameState.menu;
    //
    public static GameManager instanciaCompartidaGameManager;
    //
    public Text pointsUserTXT,cronoTXT,pointUserTXTGameOver;
    //
    public GameObject playerPref;
    //
    public Transform playerPoint;
    //
    public PlayerModel player;
    //as
    public AudioSource backGroundMusic;
    void Awake(){
      instanciaCompartidaGameManager = this;
      player = new PlayerModel(1,0);
    }
    public PlayerModel GetPlayer(){
        return this.player;
    }
    public void desactiveAllScreen(){
        UIScreen.SetActive(false);
        GameOverScreen.SetActive(false);
        LogoScreen.SetActive(false);
        MenuScreen.SetActive(false);
        CronomeScreen.SetActive(false);
        creditScreen.SetActive(false);
    }
    public IEnumerator initGameScreen(){
        desactiveAllScreen();
        activateScreen(LogoScreen);        
        yield return new WaitForSeconds(3.0f);
        desactiveAllScreen();
        activateScreen(MenuScreen);
    }
    //
    public void activateScreen(GameObject screen){
        desactiveAllScreen();
        screen.SetActive(true);
    }
    //
    public IEnumerator starGame(){
        //
        Instantiate(playerPref,playerPoint.transform.position,playerPoint.rotation);
        desactiveAllScreen();
        activateScreen(UIScreen);
        CronomeScreen.SetActive(true);
        StartCoroutine(startCrono());
        yield return new WaitForSeconds(3);
        currentGameState = GameState.inGame;
        //metodo que muetra la pantalla
    }
    public IEnumerator startCrono(){
        cronoTXT.text ="3";
        yield return new WaitForSeconds(1);
        cronoTXT.text ="2";
        yield return new WaitForSeconds(1);
        cronoTXT.text ="1";
        yield return new WaitForSeconds(1);
        cronoTXT.text ="GOOO!!!";
        yield return new WaitForSeconds(1);
        CronomeScreen.SetActive(false);
    }
    //
    public void finalGame(){
        currentGameState = GameState.gameOver;
        desactiveAllScreen();
        activateScreen(GameOverScreen);
    }
    //
    public void initGame(){
        StartCoroutine(starGame());
    }
    //
    public void resetpoints(){
        player.setPoints(0);
        updatePoints(player.getPoints());
    }
    //
    public void showMenu(){
        resetpoints();
        desactiveAllScreen();
        activateScreen(MenuScreen);
    }
    public void showCredits(){
        resetpoints();
        desactiveAllScreen();
        activateScreen(creditScreen);
    }
    //
    void Start(){
        StartCoroutine(initGameScreen());
        // AudioSource.PlayClipAtPoint(backGroundMusic, new Vector3(5, 1, 2));
        backGroundMusic.Play();
    }
    public void updatePoints(int points){
        pointsUserTXT.text = points.ToString();
        pointUserTXTGameOver.text = "Score: "+points.ToString();
    }
}

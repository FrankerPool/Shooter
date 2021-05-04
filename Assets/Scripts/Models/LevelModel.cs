using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelModel: MonoBehaviour{
    [SerializeField]
    private Text _text;
    public Level Level{get; private set;}
    [SerializeField]
    public Level CurrentLevel{get; private set;}
    public void SetLevelInfo(Level level){
        Level = level;
        _text.text = level.levelNumber.ToString();
    }
    public void OnClick_Button(){
        generate(Level);
        BehaviourLevel.sharedLevelGenerator.setActualLevel(Level);
    }
    public void OnClick_Button_PlayAgain(){
        CurrentLevel = BehaviourLevel.sharedLevelGenerator.getCurrentLevel();
        GameManager.instanciaCompartidaGameManager.resetpoints();
        generate(CurrentLevel);
    }
    public void generate(Level level){
        GameManager.instanciaCompartidaGameManager.currentGameState = GameState.menu;
        BehaviourLevel.sharedLevelGenerator.generateLevel(level);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BehaviourLevel : MonoBehaviour{
    public static BehaviourLevel sharedLevelGenerator;
    public Level[] levels;
    //
    [SerializeField]
    private LevelModel _level;
    //
    public Transform _content;
    [SerializeField]
    private List<GameObject> enemyes = new List<GameObject>();
    public Transform levelStartPoint;
    [SerializeField]
    private Level currentLevel;
    //
    private void Awake(){
        sharedLevelGenerator = this;
    }
    //
    void Start(){
        showLevels();
    }
    void Update(){
        if(GameManager.instanciaCompartidaGameManager.currentGameState == GameState.inGame){
            fillEnemyes();
        }
    }

    public void fillEnemyes(){
        enemyes.Clear();
        int enemyesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if(enemyesCount > 0){
                if(enemyes.Count == 0){
                    enemyes.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
                }
            }
            if(enemyesCount == 0){
                if(enemyes.Count == 0){
                    print("fin");
                    GameManager.instanciaCompartidaGameManager.finalGame();
                }
            }
    }
    public void serchPlayers(){
        if(GameObject.FindGameObjectsWithTag("Enemy").Length > 0){
            enemyes.Clear();
            enemyes.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
            if(enemyes.Count == 0){
                print("fin");
                GameManager.instanciaCompartidaGameManager.finalGame();
            }
        }
    }
    public void setVelocEnemyes(float speedLevel){
        foreach (GameObject enemy in enemyes){
            enemy.gameObject.GetComponent<BehaviourEnemy>().getEnemyModel().setVelocity(speedLevel);
        }
    }
    public void showLevels(){
        foreach (Level item in levels){
            LevelModel level = Instantiate(_level,_content);
            level.SetLevelInfo(item);
            // Instantiate(item,_con);
        }
    }
    public void generateLevel(Level level){
        serchlevelStartPoint();
        Instantiate(level.spawnObject,levelStartPoint.transform.position,levelStartPoint.rotation);
        enemyes.Clear();
        fillEnemyes();
        setVelocEnemyes(level.velocity);
        GameManager.instanciaCompartidaGameManager.initGame();
    }

    public void serchlevelStartPoint(){
        levelStartPoint = GameObject.FindGameObjectWithTag("StartPoint").transform;
    }

    public void setActualLevel(Level level){
        currentLevel = level;
    }
    public Level getCurrentLevel(){
        return this.currentLevel;
    }
}
[System.Serializable]
public class Level{
    public int levelNumber;
    public GameObject spawnObject;
    public float velocity;

    public int getLevelNumber()
    {
        return this.levelNumber;
    }

    public void setLevelNumber(int levelNumber)
    {
        this.levelNumber = levelNumber;
    }

    public GameObject getSpawnObject()
    {
        return this.spawnObject;
    }

    public void setSpawnObject(GameObject spawnObject)
    {
        this.spawnObject = spawnObject;
    }

    public float getVelocity()
    {
        return this.velocity;
    }

    public void setVelocity(float velocity)
    {
        this.velocity = velocity;
    }


    public Level(){

    }
    public Level(int levelNumber,GameObject spawnObject,float velocity){
        this.levelNumber = levelNumber;
        this.spawnObject = spawnObject;
        this.velocity = velocity;
    }
}
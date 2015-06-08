using UnityEngine;

public class GameWatcher : MonoBehaviour
{
    public int ScoreMax;
    public Score ScoreDroite;
    public Score ScoreGauche;
    public Canvas MenuJeu;
    public UnityEngine.UI.Text Vainqueur;
    public BalleBehavior BallePrefab;

    private bool gamePaused;
    private BalleBehavior balleVirtuelle;

    // Use this for initialization
    void Start()
    {
        GamePaused();
    }

    // Update is called once per frame
    void Update()
    {
        if (gamePaused == false && HasWinner())
        {
            GamePaused();
            DisplayWinner();
        }
    }

    bool HasWinner()
    {
        return ScoreGauche.ScoreValue == ScoreMax || ScoreDroite.ScoreValue == ScoreMax;
    }

    public void GamePaused()
    {
        gamePaused = true;

        if (balleVirtuelle != null)
        {
            Destroy(balleVirtuelle.gameObject);
        }

        MenuJeu.enabled = true;
    }

    public void DisplayWinner()
    {
        string winner = ScoreGauche.ScoreValue > ScoreDroite.ScoreValue ? "Gauche" : "Droit";

        Vainqueur.text = "Victoire au Joueur " + winner;
    }

    public void StartGame()
    {
        gamePaused = false;
        MenuJeu.enabled = false;

        ScoreGauche.Reset();
        ScoreDroite.Reset();

        if (balleVirtuelle != null)
            GameObject.Destroy(balleVirtuelle);

        balleVirtuelle = Instantiate(BallePrefab) as BalleBehavior;
        balleVirtuelle.Throw();
    }

    public void BalleToucheDroite()
    {
        ScoreGauche.ScoreValue++;
    }

    public void BalleToucheGauche()
    {
        ScoreDroite.ScoreValue++;
    }
}

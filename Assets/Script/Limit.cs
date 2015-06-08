using UnityEngine;

public class Limit : MonoBehaviour
{

    public GameWatcher GameWatcher;
    public Sides Side;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        audio.Play();

        if (Side == Sides.Left)
            GameWatcher.BalleToucheGauche();
        else if (Side == Sides.Right)
            GameWatcher.BalleToucheDroite();
    }
}

public enum Sides
{
    None,
    Right,
    Left
}

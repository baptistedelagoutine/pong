using UnityEngine;

public class BalleBehavior : MonoBehaviour
{
    public float InitialForce = 100f;
    public int MaxNbrAugmentationSpeed;
    public float FactorAugmentationSpeed;
    public int BouncesBeforeSpeedAugmentation;

    private int NbrAugmentationSpeed;
    private int Bounces;

    // Use this for initialization
    void Start()
    {
        NbrAugmentationSpeed = 0;
        Bounces = 0;

        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        // detecter et debloquer le cas X bouge pas. (et le cas Y bouge pas ?)
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (Bounces == BouncesBeforeSpeedAugmentation)
        {
            if (NbrAugmentationSpeed < MaxNbrAugmentationSpeed)
            {
                Vector2 speed = rigidbody2D.velocity;
                rigidbody2D.AddForce(new Vector2(speed.x * FactorAugmentationSpeed, speed.y * FactorAugmentationSpeed), ForceMode2D.Impulse);

                NbrAugmentationSpeed++;
            }

            Bounces = 0;
        }
        else
            Bounces++;
    }

    void Reset()
    {
        this.transform.position = new Vector2(0, 0);
        rigidbody2D.velocity = new Vector2(0, 0);
    }

    public void Throw()
    {
        Reset();

        float factorX = Random.value > 0.5 ? 1f : -1f;
        float factorY = Random.value > 0.5 ? 1f : -1f;

        rigidbody2D.AddForce(new Vector2(factorX * InitialForce, factorY * InitialForce), ForceMode2D.Force);
    }
}

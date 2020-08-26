using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject headPrefab;

    [SerializeField] float minimalDistance = .25f;
    [SerializeField] float speed = 1f;
    [SerializeField] float rotationSpeed = 50;
    [SerializeField] int startingSize = 1;
    [SerializeField] GameObject bodyPrefab;
    [SerializeField] TextMeshProUGUI scoreText;


    private float distance;
    private Transform currentBodyPart;
    private Transform previousBodyPart;

    public const int invulnerabilityTime = 2;

    public List<BodyPart> BodyParts { get; set; } = new List<BodyPart>();
    public float TimeSinceStart { get; set; }
    public int Score { get; set; }
    private int partNumber = 1;
    
    void Start()
    {
        UpdateScore();
        BodyParts.Add(new BodyPart( headPrefab.transform, partNumber));

        for (int i = 0; i < startingSize - 1; i++)
        {

            AddBodyPart();

        }
    }

    // Update is called once per frame
    void Update()
    {

        TimeSinceStart += Time.deltaTime;
        //UpdateScore();

        Move();

        //For debuging purposes
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Score++;
            UpdateScore();
            AddBodyPart();
        }   
    }

    public void Move()
    {

        float curspeed = speed;

        if (Input.GetKey(KeyCode.W))
            curspeed *= 2;

        BodyParts[0].BodyTransform.Translate(BodyParts[0].BodyTransform.forward * curspeed * Time.smoothDeltaTime, Space.World);

        if (Input.GetAxis("Horizontal") != 0)
            BodyParts[0].BodyTransform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));

        for (int i = 1; i < BodyParts.Count; i++)
        {

            currentBodyPart = BodyParts[i].BodyTransform;
            previousBodyPart = BodyParts[i - 1].BodyTransform;

            distance = Vector3.Distance(previousBodyPart.position, currentBodyPart.position);

            Vector3 newPosition = previousBodyPart.position;

            newPosition.y = BodyParts[0].BodyTransform.position.y;

            float time = Time.deltaTime * distance / minimalDistance * curspeed;

            if (time > .5f)
                time = .5f;
            currentBodyPart.position = Vector3.Slerp(currentBodyPart.position, newPosition, time);
            currentBodyPart.rotation = Quaternion.Slerp(currentBodyPart.rotation, previousBodyPart.rotation, time);



        }
    }


    public void AddBodyPart()
    {
        partNumber++;
        Transform newPart = (Instantiate(bodyPrefab, BodyParts[BodyParts.Count - 1].BodyTransform.position, BodyParts[BodyParts.Count - 1].BodyTransform.rotation) as GameObject).transform;

        newPart.SetParent(transform);

        BodyParts.Add(new BodyPart(newPart, partNumber));
    }
    private void UpdateScore()
    {
        const string defaultScoreText = "Score ";
        scoreText.SetText(defaultScoreText + Score);

    }
    public void IncreaseScore(int ammount)
    {
        Score += ammount;
        UpdateScore();

    }

     public class BodyPart
    {
        public int PartNumber { get; set; }
        public Transform BodyTransform { get; set; }

        public BodyPart(Transform transform, int partNumber)
        {
            this.PartNumber = partNumber;
            this.BodyTransform = transform;
        }
    }
}

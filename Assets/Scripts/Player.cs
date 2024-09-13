using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 3;

    [SerializeField] AudioSource dropAudio;
    [SerializeField] AudioSource fusionAudio;

    [SerializeField] Transform spawnOffset;

    public GameObject[] ballPrefabs;
    private GameObject currentBall;

    private void Start()
    {
        GrabBall();
    }

    private void GrabBall()
    {
        int randomIndex = Random.Range(0, ballPrefabs.Length);
        var ballPrefab = ballPrefabs[randomIndex];
        currentBall = Instantiate(ballPrefab, spawnOffset.position, Quaternion.identity, spawnOffset);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = 0;// Input.GetAxis("Vertical");

        // Faire une copie de la position du joueur
        Vector3 nextPosition = transform.position;

        // Appliquer le déplacement à la copie
        nextPosition += new Vector3(x, y, 0) * Time.deltaTime * speed;

        // Ajuster la position pour rester entre un minimum et un maximum
        nextPosition.x = Mathf.Clamp(nextPosition.x, -5f, 5f);

        // Appliquer la nouvelle position
        transform.position = nextPosition;


        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            currentBall.transform.parent = null;
            currentBall.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            dropAudio.Play();
            Invoke("GrabBall", 0.5f);
        }
    }

    internal void SpawnBall(int index, Vector3 spawnPosition)
    {

        // Spawner une balle seulement si l'index est valide
        // index valide est 0, 1, 2..
        if (index >= ballPrefabs.Length)
        {
            return;
        }

        fusionAudio.Play();
        var fusionedBall = Instantiate(ballPrefabs[index], spawnPosition, Quaternion.identity);
        fusionedBall.GetComponent<Rigidbody2D>().bodyType= RigidbodyType2D.Dynamic;
    }
}

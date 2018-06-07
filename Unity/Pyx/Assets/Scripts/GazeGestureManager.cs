using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.XR.WSA.Input;

public class GazeGestureManager : MonoBehaviour
{
    public GameObject jokeCreatedBy;
    public GameObject jokeDescription;
    public GameObject jokeTitle;

    public static GazeGestureManager Instance { get; private set; }

    public GameObject FocusedObject { get; private set; }

    public GameObject sphere;

    int jokeIndex = 1;

    GestureRecognizer recognizer;

    public float waitTime = 1f;

    float timer;

    private Joke noJoke = new Joke {createdBy = "", title = "Waiting for next instruction", description = ""};

    void Awake()
    {
        Instance = this;

        recognizer = new GestureRecognizer();
        recognizer.Tapped += (args) =>
        {
            if (FocusedObject == sphere)
            {
                jokeIndex++;
                FetchJoke();
            }
        };

        recognizer.StartCapturingGestures();

        ShowJoke(noJoke);

        FetchJoke();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            FetchJoke();
            timer = 0f;
        }

        var oldFocusObject = FocusedObject;

        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        FocusedObject = Physics.Raycast(headPosition, gazeDirection, out hitInfo) ? hitInfo.collider.gameObject : null;

        // If the focused object changed this frame,
        // start detecting fresh gestures again.
        if (FocusedObject != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
    }

    void FetchJoke()
    {
        var webRequest = UnityWebRequest.Get("http://192.168.1.153:5002/api/instruction/" + jokeIndex);

        var getOperation = webRequest.SendWebRequest();

        getOperation.completed += operation =>
        {
            var joke = JsonConvert.DeserializeObject<Joke>(webRequest.downloadHandler.text) ?? noJoke;

            ShowJoke(joke);
        };
    }

    void ShowJoke(Joke joke)
    {
        jokeCreatedBy.GetComponent<TextMesh>().text = joke.createdBy;
        jokeDescription.GetComponent<TextMesh>().text = joke.description;
        jokeTitle.GetComponent<TextMesh>().text = joke.title;
    }

    class Joke
    {
        public string createdBy;
        public string description;
        public string title;
    }
}


using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIService : MonoGenericSingelton<UIService>
{

    public TextMeshProUGUI SimulationStatus;


    [SerializeField]
    private Button StartButton;

    [SerializeField]
    private Button StopButton;

    [SerializeField]
    private Button ResetButton;


    [SerializeField]
    private CurrentStatusDisplayer currentStatusDisplayer;
    protected override void Awake()
    {
        base.Awake();
        SimulationStatus.text = "Simulation not running";
    }

    private void Start()
    {
        StartButton.onClick.AddListener(StartSimulation);
        StopButton.onClick.AddListener(StopSimulation);
        ResetButton.onClick.AddListener(ResetConnection);
    }

    public void StartSimulation()
    {
        SimulationStatus.text = "Simulation Running";
        ICSpawner.Instance.gameObject.SetActive(false);
        currentStatusDisplayer.gameObject.SetActive(true);
        EventService.Instance.InvokeSimulationStarted();

    }
    public void StopSimulation()
    {
        SimulationStatus.text = "Simulation not running";
        ICSpawner.Instance.gameObject.SetActive(true);
        currentStatusDisplayer.gameObject.SetActive(false);
        EventService.Instance.InvokeSimulationStopped();
    }

    private void ResetConnection()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


using System.Collections.Generic;
using TMPro;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimulatorManager : MonoGenericSingelton<SimulatorManager>
{





    public List<ICModel> ICModels = new();

    public List<WireController> Wires;


    public bool SimulationRunning;

    public Sprite PinPostive;

    public Sprite PinNegative;
    
    public Sprite PinNull;



    public List<Color> colorList = new() { Color.red, Color.black, Color.blue };


    protected override void Awake()
    {
        base.Awake();
        SimulationRunning = false;
    }
    private void Start()
    {
        EventService.Instance.SimulationStarted += () => {
            SimulationRunning = true;
        };
        EventService.Instance.SimulationStopped += () =>
        {
            SimulationRunning = false;
        };
    }
    private void OnDestroy()
    {
        EventService.Instance.SimulationStarted -= () => {
            SimulationRunning = true;
        };
        EventService.Instance.SimulationStopped -= () =>
        {
            SimulationRunning = false;
        };
    }


}

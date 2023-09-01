
using System.Collections.Generic;
using TMPro;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimulatorManager : MonoGenericSingelton<SimulatorManager>
{

    public bool doingConnection = false;

    public GameObject Wire;

    public GameObject WiresGameObject;


    public List<ICBase> ICBases;

    public List<WireController> Wires;


    public bool SimulationRunning;

    public Sprite PinPostive;

    public Sprite PinNegative;
    
    public Sprite PinNull;


    private EventService eventService;

    public List<Color> colorList = new() { Color.red, Color.black, Color.blue };


    protected override void Awake()
    {
        base.Awake();
        SimulationRunning = false;
    }
    private void Start()
    {
        eventService = EventService.Instance;
        eventService.SimulationStarted += () => {
            SimulationRunning = true;
        };
        eventService.SimulationStopped += () =>
        {
            SimulationRunning = false;
        };
    }

    private void Update()
    {
        if (doingConnection)
        {
            SetWireEndToMousePointer();
            if (Input.GetMouseButtonDown(1))
            { 
                Destroy(Wire);
                Wire = null;
                doingConnection = false;
            }
        }
    }

    private void SetWireEndToMousePointer()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 endPosition = new(mousePosition.x, mousePosition.y, mousePosition.z);
        Wire.GetComponent<WireController>().SetWireEnd(endPosition);
    }
    
}

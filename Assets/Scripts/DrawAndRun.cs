using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using UnityEngine.UI;
using Dreamteck.Splines;

public class DrawAndRun : MonoBehaviour
{
    [SerializeField] private List<Runner> runners = new List<Runner>();
    [SerializeField] private Runner runner;
    [SerializeField] private Button PlayButton;
    [SerializeField] private Vector3 direction = new Vector3(0,0,2);
    [SerializeField] private Road _Road;
    private bool pause = false;
    private Vector3 StartPositionCamera;
    private Vector3 StartPosition;
    [SerializeField] private SplineComputer splineComputer;
    public bool Pause => pause;
    public void SetMenu(bool p)
    {
        pause = p;
    }
    public void Init()
    {
        //InvokeRepeating("Run", 0.1f, 0.1f);
    }
    private void Run()
    {
        if (runners.Count < 1|| runners[0]==null||transform.position.z> _Road._FinishPosition.z)
        {
            End();
        }
        if (pause == false)
        {
            transform.Translate(direction * Time.deltaTime);
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z - 8.6f);
        }
        PlayButton.gameObject.SetActive(pause);
    }
    // Use this for initialization
    void Start()
    {
        StartRun();
        Init();
    }
    public void Remove(Runner item)
    {
        runners.Remove(item);
    }
    public void Add(Runner item)
    {
        runners.Add(item);
        item.transform.position += Vector3.forward*0.1f;
    }
    void InstanceRunners()
    {
        for (int i = 0; i < 80; i++)
        {
            runners.Insert(i, new Runner());
            runners[i] = Instantiate(runner, transform);
            runners[i].transform.position = new Vector3(0,2.48f, -8);
            SplinePoint splinePoint = new SplinePoint();
            splinePoint.SetPosition(new Vector3(0, 2.48f, -8));
            splineComputer.SetPoint(i, splinePoint);
            splineComputer.Rebuild();
            runners[i].Init(UnitBattleIdentity.Runner, this);
        }
    }
    public void StartRun()
    {
        StartPositionCamera = Camera.main.transform.position;
        StartPosition = transform.position;
        pause = false;
        InstanceRunners();
    }
    void End()
    {
        runners.Clear();
        Camera.main.transform.position = StartPositionCamera;
        transform.position = StartPosition;
        pause = true;

    }

    public void WaypointsRunners(List<Vector3> waypoints)
    {
        Vector3 oldposition = Vector3.zero;
        for(int i = 0; i < runners.Count; i++)
        {
            if (i < waypoints.Count&& runners[i]!=null) { oldposition = waypoints[i]; runners[i].transform.position = waypoints[i]+Vector3.forward*4; }
            else { if(runners[i] != null)runners[i].transform.position = oldposition + Vector3.forward * 4; }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Run();
    }
}
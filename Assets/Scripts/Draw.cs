using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public GameObject brush;
    LineRenderer currentLineRenderer;
    Vector2 lastPosition;
    float brushSize = 0.1f;
    List<GameObject> points = new List<GameObject>();
    [SerializeField]List<Vector3> Waypoints = new List<Vector3>();
    [HideInInspector] private bool isDraw = false;
    [SerializeField]private DrawAndRun DrawRunners; 
    private float waitTime = 0.1f;
    private float timer = 0.0f;
    void Drawing()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isDraw = false;
            Waypoints.Clear();
            points.Clear();
        }
        if (Input.touchCount < 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit) && !Waypoints.Contains(raycastHit.point) && raycastHit.collider.name == "Plane")
            {
                isDraw = true;
                var go = Instantiate(brush, raycastHit.point + Vector3.up * 0.1f, brush.transform.rotation, transform);
                go.transform.localScale = Vector3.one * brushSize;
                points.Add(go);
                Waypoints.Add(raycastHit.point);
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (isDraw) DrawRunners.WaypointsRunners(Waypoints);
            foreach (var p in points)
            {
                Destroy(p.gameObject);
            }
            timer = 0.0f;
        }

    }
    private Vector3 GetWorldCoordinate(Vector3 mousePosition)
    {
        Vector3 mousePos = new Vector3(mousePosition.x, mousePosition.y, 1);
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Drawing", 0.01f, 0.01f);
    }
    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Drawing();
    }
    private void UpdateLine()
    {

    }

}

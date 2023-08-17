using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    private LineRenderer _lineRendererComponent;
    
    private void Start()
    {
        _lineRendererComponent = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 origin, Vector3 speed)
    {
        var points = new Vector3[100];
        _lineRendererComponent.positionCount = points.Length;

        for (var i = 0; i < points.Length; i++)
        {
            var time = i * 0.1f;

            points[i] = origin + speed * time + Physics.gravity * (time * time) / 2f;

            if (!(points[i].y < 0)) continue;
            _lineRendererComponent.positionCount = i + 1;
            break;
        }
        
        _lineRendererComponent.SetPositions(points);
        
        _lineRendererComponent.enabled = true;
    }

    public void HideTrajectory()
    {
        _lineRendererComponent.enabled = false;
    }
}

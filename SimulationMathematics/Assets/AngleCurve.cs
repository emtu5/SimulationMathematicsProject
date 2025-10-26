using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class AngleCurve : MonoBehaviour
{
    public float radius = 3f;
    public float startAngle = 0f;    // degrees
    public float endAngle = 90f;     // degrees
    public int segments = 50;
    public Color color = Color.red;

    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = color;
        line.endColor = color;

        DrawArc();
    }

    void Update()
    {
        DrawArc();
    }

    void DrawArc()
    {
        float angleStep = (endAngle - startAngle) / segments;

        for (int i = 0; i <= segments; i++)
        {
            float angle = Mathf.Deg2Rad * (startAngle + i * angleStep);
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            line.SetPosition(i, new Vector3(x, y, 0f));
        }
    }
}

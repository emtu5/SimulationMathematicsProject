using UnityEngine;

public class Axis : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float thickness = 0.1f;
    public Color cylinderColor = Color.white;

    private GameObject cylinder;
    private Material cylinderMaterial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Create a cylinder
        cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        // Create a new material instance
        cylinderMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        cylinderMaterial.color = cylinderColor;

        // Assign the material to the cylinder
        cylinder.GetComponent<Renderer>().material = cylinderMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (startPoint == null || endPoint == null) return;

         // Get the midpoint between start and end
        Vector3 startPos = startPoint.position;
        Vector3 endPos = endPoint.position;
        Vector3 direction = endPos - startPos;
        Vector3 midPoint = (startPos + endPos) / 2f;

        // Update cylinder position and scale
        cylinder.transform.position = midPoint;
        cylinder.transform.up = direction.normalized; // align along the line
        cylinder.transform.localScale = new Vector3(thickness, direction.magnitude / 2f, thickness);
    }
}

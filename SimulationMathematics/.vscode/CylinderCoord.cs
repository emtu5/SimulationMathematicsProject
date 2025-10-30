using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CylinderCoord : MonoBehaviour
{
    public TextMeshProUGUI rText = null;
    public TextMeshProUGUI thetaText = null;
    public TextMeshProUGUI hText = null;
    public TextMeshProUGUI XText = null;
    public TextMeshProUGUI YText = null;
    public TextMeshProUGUI ZText = null;
    public GameObject outerCylinder = null;
    public GameObject point = null;
    public GameObject pivotPoint = null;
    public AngleCurve thetaCurve = null;
    // public Transform endPointPhi = null;
    public Transform endPointTheta = null;
    public Transform endPointRZ = null;
    public Transform endPointRX = null;
    public Transform startPointH = null;
    public Transform endPointH = null;
    // public Transform pivotPhi = null;
    public Transform pivotTheta = null;
    public Slider xSlider = null;
    public Slider ySlider = null;
    public Slider zSlider = null;
    public Slider rSlider = null;
    public Slider thetaSlider = null;
    public Slider hSlider = null;

    [Range(-10.0f, 10.0f)]
    public float x = 0.0f;

    [Range(-10.0f, 10.0f)]
    public float y = 0.0f;

    [Range(-10.0f, 10.0f)]
    public float z = 0.0f;

    [Range(0.0f, 10.0f)]
    public float r = 0.0f;

    [Range(0.0f, 2 * Mathf.PI)]
    public float theta = 0.0f;

    [Range(-10.0f, 10.0f)]
    public float h = 0.0f;

    public float atanMath(float y, float x) {
        float theta = Mathf.Atan2(y, x);
        if (theta > Mathf.PI / 2)
            theta = (float)2.5 * Mathf.PI - theta;
        else
            theta = Mathf.PI / 2 - theta;
        return theta;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xSlider.onValueChanged.AddListener(delegate {CartesianToCylinder(); });
        ySlider.onValueChanged.AddListener(delegate {CartesianToCylinder(); });
        zSlider.onValueChanged.AddListener(delegate {CartesianToCylinder(); });
        rSlider.onValueChanged.AddListener(delegate {CylinderToCartesian(); });
        thetaSlider.onValueChanged.AddListener(delegate {CylinderToCartesian(); });
        hSlider.onValueChanged.AddListener(delegate {CylinderToCartesian(); });
    }

    public void CartesianToCylinder() {
            x = xSlider.value;
            y = ySlider.value;
            z = zSlider.value;
            r = Mathf.Sqrt(x * x + y * y);
            theta = atanMath(y, x);
            h = z;
            rSlider.SetValueWithoutNotify(r);
            thetaSlider.SetValueWithoutNotify(theta);
            hSlider.SetValueWithoutNotify(h);
    }

    public void CylinderToCartesian() {
            r = rSlider.value;
            theta = thetaSlider.value;
            h = hSlider.value;
            x = r * Mathf.Cos(theta);
            y = r * Mathf.Sin(theta);
            z = h;
            xSlider.SetValueWithoutNotify(x);
            ySlider.SetValueWithoutNotify(y);
            zSlider.SetValueWithoutNotify(z);
    }

    // Update is called once per frame
    void Update()
    {
        rText.text = "r = " + r;
        thetaText.text = "Theta = " + theta;
        hText.text = "h = " + h;
        XText.text = "x = " + x;
        YText.text = "y = " + y;
        ZText.text = "z = " + z;
        // XText.text = "x = " + point.transform.position.x;
        // YText.text = "y = " + point.transform.position.y;
        // ZText.text = "z = " + point.transform.position.z;

        endPointRX.transform.localPosition = new Vector3(r, 0, 0);
        endPointRZ.transform.localPosition = new Vector3(0, 0, h);

        endPointTheta.transform.localPosition = new Vector3(r, 0, 0);
        pivotTheta.transform.localRotation = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.forward);

        thetaCurve.radius = r;
        thetaCurve.endAngle = theta * Mathf.Rad2Deg;

        outerCylinder.transform.localScale = new Vector3(r * 2f, h, r * 2f);
        point.transform.localPosition = new Vector3(r, 0, h);
        pivotPoint.transform.localRotation = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.forward);

        startPointH.transform.localPosition = endPointTheta.transform.position;
        endPointH.transform.localPosition = point.transform.position;
    }
}

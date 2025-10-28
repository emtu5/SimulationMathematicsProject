using UnityEngine;
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

    [Range(0.0f, 10.0f)]
    public float r = 0.0f;

    [Range(0.0f, 2 * Mathf.PI)]
    public float theta = 0.0f;

    [Range(-10.0f, 10.0f)]
    public float h = 0.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rText.text = "r = " + r;
        thetaText.text = "Theta = " + theta;
        hText.text = "h = " + h;
        XText.text = "x = " + point.transform.position.x;
        YText.text = "y = " + point.transform.position.y;
        ZText.text = "z = " + point.transform.position.z;
        
        // outerSphere.transform.localScale = new Vector3(rho * 2f, rho * 2f, rho * 2f);

        endPointRX.transform.localPosition = new Vector3(r, 0, 0);
        endPointRZ.transform.localPosition = new Vector3(0, 0, h);

        endPointTheta.transform.localPosition = new Vector3(r, 0, 0);
        pivotTheta.transform.localRotation = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.forward);

        // endPointPhi.transform.localPosition = new Vector3(0, 0, rho);
        // pivotPhi.transform.localRotation = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.forward) * Quaternion.AngleAxis(phi * Mathf.Rad2Deg, Vector3.up);

        // //point.transform.localPosition = new Vector3(rho * Mathf.Sin(phi) * Mathf.Cos(theta), rho * Mathf.Sin(phi) * Mathf.Sin(theta), rho * Mathf.Cos(theta));
        // point.transform.localPosition = new Vector3(0, 0, rho);
        // pivotPoint.transform.localRotation = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.forward) * Quaternion.AngleAxis(phi * Mathf.Rad2Deg, Vector3.up);

        // Vector3 currentLocalRotation = phiCurve.transform.localEulerAngles;
        // currentLocalRotation.x = theta * Mathf.Rad2Deg - 90;
        // phiCurve.transform.localEulerAngles = currentLocalRotation;

        thetaCurve.radius = r;
        thetaCurve.endAngle = theta * Mathf.Rad2Deg;

        // phiCurve.radius = rho;
        // phiCurve.endAngle = phi * Mathf.Rad2Deg;

        outerCylinder.transform.localScale = new Vector3(r * 2f, h, r * 2f);
        point.transform.localPosition = new Vector3(r, 0, h);
        pivotPoint.transform.localRotation = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.forward);

        startPointH.transform.localPosition = endPointTheta.transform.position;
        endPointH.transform.localPosition = point.transform.position;
        // pivotPoint.transform.localRotation = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.forward) * Quaternion.AngleAxis(phi * Mathf.Rad2Deg, Vector3.up);
    }
}

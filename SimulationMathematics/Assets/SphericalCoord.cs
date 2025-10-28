using UnityEngine;
using TMPro;

public class SphericalCoord : MonoBehaviour
{
    public TextMeshProUGUI rhoText = null;
    public TextMeshProUGUI phiText = null;
    public TextMeshProUGUI thetaText = null;
    public TextMeshProUGUI XText = null;
    public TextMeshProUGUI YText = null;
    public TextMeshProUGUI ZText = null;
    public GameObject outerSphere = null;
    public GameObject point = null;
    public GameObject pivotPoint = null;
    public AngleCurve thetaCurve = null;
    public AngleCurve phiCurve = null;
    public Transform endPointPhi = null;
    public Transform endPointTheta = null;
    public Transform endPointRhoZ = null;
    public Transform endPointRhoX = null;
    public Transform pivotPhi = null;
    public Transform pivotTheta = null;

    [Range(0.0f, 10.0f)]
    public float rho = 0.0f;

    [Range(0.0f, Mathf.PI)]
    public float phi = 0.0f;

    [Range(-Mathf.PI, Mathf.PI)]
    public float theta = 0.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rhoText.text = "Rho = " + rho;
        phiText.text = "Phi = " + phi;
        thetaText.text = "Theta = " + theta;
        XText.text = "x = " + point.transform.position.x;
        YText.text = "y = " + point.transform.position.y;
        ZText.text = "z = " + point.transform.position.z;

        outerSphere.transform.localScale = new Vector3(rho * 2f, rho * 2f, rho * 2f);

        endPointRhoX.transform.localPosition = new Vector3(rho, 0, 0);
        endPointRhoZ.transform.localPosition = new Vector3(0, 0, rho);

        endPointTheta.transform.localPosition = new Vector3(rho, 0, 0);
        pivotTheta.transform.localRotation = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.forward);

        endPointPhi.transform.localPosition = new Vector3(0, 0, rho);
        pivotPhi.transform.localRotation = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.forward) * Quaternion.AngleAxis(phi * Mathf.Rad2Deg, Vector3.up);

        //point.transform.localPosition = new Vector3(rho * Mathf.Sin(phi) * Mathf.Cos(theta), rho * Mathf.Sin(phi) * Mathf.Sin(theta), rho * Mathf.Cos(theta));
        point.transform.localPosition = new Vector3(0, 0, rho);
        pivotPoint.transform.localRotation = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.forward) * Quaternion.AngleAxis(phi * Mathf.Rad2Deg, Vector3.up);

        Vector3 currentLocalRotation = phiCurve.transform.localEulerAngles;
        currentLocalRotation.x = theta * Mathf.Rad2Deg - 90;
        phiCurve.transform.localEulerAngles = currentLocalRotation;

        thetaCurve.radius = rho;
        thetaCurve.endAngle = theta * Mathf.Rad2Deg;

        phiCurve.radius = rho;
        phiCurve.endAngle = phi * Mathf.Rad2Deg;
    }
}

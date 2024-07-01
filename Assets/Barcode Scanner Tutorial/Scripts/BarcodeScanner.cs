using UnityEngine;
using UnityEngine.Events;

// Scanning logic for the barcode scanner.
public class BarcodeScanner : MonoBehaviour
{
    [SerializeField]
    private Transform rayTransform;

    [SerializeField]
    private float scanDistance = 0.1f;

    // Stores the last code scanned by the tool.
    public string LastCodeScanned { get; private set; }

    // Raised when a code is successfully scanned.
    public UnityEvent<string> CodeScanned;

    private Material emitterMaterial;

    private bool isScanSuccessful;
    private bool isScanning;


    private void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            emitterMaterial = GetComponent<MeshRenderer>().materials[1];
        }        

        UpdateEmitterColor();
    }

    public void FixedUpdate()
    {        
        if (isScanning && !isScanSuccessful) 
        {
            RaycastHit hit;
            Ray ray = new Ray(rayTransform.position, rayTransform.TransformDirection(Vector3.forward));
            if(Physics.Raycast(ray, out hit, scanDistance))
            {
                BarcodeLabel barcodeLabel = hit.collider.gameObject.GetComponent<BarcodeLabel>();

                if(barcodeLabel != null)
                {
                    isScanSuccessful = true;
                    LastCodeScanned = barcodeLabel.BarcodeValue;

                    CodeScanned.Invoke(LastCodeScanned);
                }
            }
        }
    }

    // Start scanning for labels.
    public void StartScanning()
    {
        isScanSuccessful = false;
        isScanning = true;

        UpdateEmitterColor();
    }

    // Stop scanning for labels.
    public void StopScanning()
    {
        isScanning = false;

        UpdateEmitterColor();
    }

    private void UpdateEmitterColor()
    {
        if(emitterMaterial != null)
        {
            emitterMaterial.color = isScanning ? Color.red : Color.black;
        }
    }
}

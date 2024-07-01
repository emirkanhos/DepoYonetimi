using UnityEngine;

// Prints a debug log when a code is scanned.
public class bolum6scanner : MonoBehaviour
{
    public Bolum6Manager Manager;

    private void Start()
    {
        BarcodeScanner scanner = GetComponent<BarcodeScanner>();
        if (scanner != null)
        {
            scanner.CodeScanned.AddListener(OnCodeScanned);
        }
    }

    public void OnCodeScanned(string scannedCode)
    {
        Debug.Log($"The following code has been scanned: {scannedCode}");
        if (scannedCode == "kutu1")
        {
            if (Manager != null)
            {
                Manager.KodOkundu1();
            }
        }
        if (scannedCode == "kutu2")
        {
            if (Manager != null)
            {
                Manager.KodOkundu2();
            }
        }
    }
}

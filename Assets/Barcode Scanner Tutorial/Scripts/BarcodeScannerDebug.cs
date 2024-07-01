using UnityEngine;

// Prints a debug log when a code is scanned.
public class BarcodeScannerDebug : MonoBehaviour
{
    public Bolum2Manager bolum2Manager;

    private void Start()
    {
        BarcodeScanner scanner = GetComponent<BarcodeScanner>();
        if(scanner != null)
        {
            scanner.CodeScanned.AddListener(OnCodeScanned);
        }
    }

    public void OnCodeScanned(string scannedCode)
    {
        Debug.Log($"The following code has been scanned: {scannedCode}");
        if (scannedCode == "1.kutu")
        {
            // "1.kutu" okunduðunda Bolum2Manager'ýn KodOkundu() metodunu çaðýr
            if (bolum2Manager != null)
            {
                bolum2Manager.KodOkundu();
            }
        }
        if (scannedCode == "2.kutu")
        {
            if (bolum2Manager != null)
            {
                bolum2Manager.KodOkundu2();
            }
        }
        if (scannedCode == "3.kutu")
        {
            if (bolum2Manager != null)
            {
                bolum2Manager.KodOkundu3();
            }
        }
    }
}

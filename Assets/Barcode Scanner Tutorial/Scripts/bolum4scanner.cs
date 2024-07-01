using UnityEngine;

// Prints a debug log when a code is scanned.
public class bolum4scanner : MonoBehaviour
{
    public Bolum4Manager bolum4Manager;

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
        if (scannedCode == "1.kutu")
        {
            // "1.kutu" okunduðunda Bolum2Manager'ýn KodOkundu() metodunu çaðýr
            if (bolum4Manager != null)
            {
                bolum4Manager.KodOkundu();
            }
        }
        if (scannedCode == "2.kutu")
        {
            if (bolum4Manager != null)
            {
                bolum4Manager.KodOkundu2();
            }
        }
        if (scannedCode == "3.kutu")
        {
            if (bolum4Manager != null)
            {
                bolum4Manager.KodOkundu3();
            }
        }
        if (scannedCode == "4.kutu")
        {
            if (bolum4Manager != null)
            {
                bolum4Manager.KodOkundu4();
            }
        }
    }
}

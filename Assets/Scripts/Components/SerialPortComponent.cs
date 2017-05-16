using UnityEngine; 
using System.IO.Ports;

[DisallowMultipleComponent]
public class SerialPortComponent : MonoBehaviour
{
    public SerialPort port;
}

//DO NOT ADD MONOBEHAVIOUR MESSAGES (Start, Update, etc.)

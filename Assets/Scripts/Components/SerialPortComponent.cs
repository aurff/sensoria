using UnityEngine; 
using System.IO.Ports;

[DisallowMultipleComponent]
public class SerialPortComponent : MonoBehaviour
{
    public SerialPort port;
    public int playerID;
}

//DO NOT ADD MONOBEHAVIOUR MESSAGES (Start, Update, etc.)

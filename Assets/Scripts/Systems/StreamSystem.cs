using UnityEngine;
using System.IO.Ports;

public class StreamSystem : EgoSystem<EgoConstraint<SerialPortComponent>>
{
	public override void Start()
	{
		constraint.ForEachGameObject ((egoComponent, serialPortComponent) => {

			if (serialPortComponent.playerID == 1)
			{
				serialPortComponent.port = new SerialPort("/dev/cu.usbmodem1411", 9600);
				serialPortComponent.port.Open();
				serialPortComponent.port.ReadTimeout = 1;
			}

			if (serialPortComponent.playerID == 2)
			{
				serialPortComponent.port = new SerialPort("/dev/cu.usbmodem1421", 9600);
				serialPortComponent.port.Open();
				serialPortComponent.port.ReadTimeout = 1;
			}
		});
	}

	public override void Update()
	{
		constraint.ForEachGameObject ((egoComponent, serialPortComponent) => {
			
			if (serialPortComponent.playerID == 1)
			{
				if (serialPortComponent.port.IsOpen)
				{
					try
					{
						//Debug.Log("Receive Data from Serialport 1");
						ReceiveAdruinoInput(serialPortComponent.port.ReadByte(), 1);
					}
					catch (System.TimeoutException)
					{
						//throw;
					}
				}
				serialPortComponent.port.BaseStream.Flush();
			}
			if (serialPortComponent.playerID == 2)
			{
				if (serialPortComponent.port.IsOpen)
				{
					try
					{
						//Debug.Log("Receive Data from Serialport 2");
						ReceiveAdruinoInput(serialPortComponent.port.ReadByte(), 2);
					}
					catch (System.TimeoutException)
					{
						//throw;
					}
				}
				serialPortComponent.port.BaseStream.Flush();
			}
		});
	}

	void ReceiveAdruinoInput(int data, int playerID)
	{
		if (data == 1)
		{
			//Debug.Log("Move right");
			var e = new InputDataReceivedEvent(data, playerID);
			EgoEvents<InputDataReceivedEvent>.AddEvent(e);
		}

		if (data == 2)
		{
			//Debug.Log("Stop move right");
			var e = new InputDataReceivedEvent(data, playerID);
			EgoEvents<InputDataReceivedEvent>.AddEvent(e);
		}

		if (data == 3)
		{
			//Debug.Log("Move left");
			var e = new InputDataReceivedEvent(data, playerID);
			EgoEvents<InputDataReceivedEvent>.AddEvent(e);
		}

		if (data == 4)
		{
			//Debug.Log("Stop move left");
			var e = new InputDataReceivedEvent(data, playerID);
			EgoEvents<InputDataReceivedEvent>.AddEvent(e);
		}

		if (data == 5)
		{
			//Debug.Log("GROUNDED");
			var e = new InputDataReceivedEvent(data, playerID);
			EgoEvents<InputDataReceivedEvent>.AddEvent(e);
		}

		if (data == 6)
		{
			//Debug.Log("JUMPING");
			var e = new InputDataReceivedEvent(data, playerID);
			EgoEvents<InputDataReceivedEvent>.AddEvent(e);
		}
	}
}
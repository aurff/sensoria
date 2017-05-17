using UnityEngine;
using System.IO.Ports;

public class StreamSystem : EgoSystem<EgoConstraint<SerialPortComponent>>
{
	public override void Start()
	{
		constraint.ForEachGameObject ((egoComponent, serialPortComponent) => {
			serialPortComponent.port = new SerialPort("/dev/cu.usbmodem1411", 9600);
			serialPortComponent.port.Open();
			serialPortComponent.port.ReadTimeout = 1;
		});
	}

	public override void Update()
	{
		constraint.ForEachGameObject ((egoComponent, serialPortComponent) => {

			if (serialPortComponent.port.IsOpen)
			{
				try
				{
					ReceiveAdruinoInput(serialPortComponent.port.ReadByte());
				}
				catch (System.TimeoutException)
				{

				}
			}
			serialPortComponent.port.BaseStream.Flush();
		});
	}

	void ReceiveAdruinoInput(int data)
	{
		if (data == 1)
		{
			Debug.Log("Move right");
			var e = new InputDataReceivedEvent(1);
			EgoEvents<InputDataReceivedEvent>.AddEvent(e);
		}

		if (data == 2)
		{
			Debug.Log("Stop move right");
			var e = new InputDataReceivedEvent(2);
			EgoEvents<InputDataReceivedEvent>.AddEvent(e);
		}

		if (data == 3)
		{
			Debug.Log("Move left");
			var e = new InputDataReceivedEvent(3);
			EgoEvents<InputDataReceivedEvent>.AddEvent(e);
		}

		if (data == 4)
		{
			Debug.Log("Stop move left");
			var e = new InputDataReceivedEvent(4);
			EgoEvents<InputDataReceivedEvent>.AddEvent(e);
		}

		if (data == 5)
		{
			Debug.Log("GROUNDED");
			var e = new InputDataReceivedEvent(5);
			EgoEvents<InputDataReceivedEvent>.AddEvent(e);
		}

		if (data == 6)
		{
			Debug.Log("JUMPING");
			var e = new InputDataReceivedEvent(6);
			EgoEvents<InputDataReceivedEvent>.AddEvent(e);
		}
	}
}
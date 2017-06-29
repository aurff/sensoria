using UnityEngine;
using UnityEngine.UI;

public class StartScreenUISystem : EgoSystem<EgoConstraint<StartScreenUIComponent>>
{
	public override void Start()
	{
		EgoEvents<PlayerReadyEvent>.AddHandler(Handle);	
		EgoEvents<PlayerNotReadyEvent>.AddHandler(Handle);
	}

	public override void Update()
	{
		
	}

	public override void FixedUpdate()
	{
		
	}

	void Handle(PlayerReadyEvent e)
	{		
		constraint.ForEachGameObject ((ego, startScreenUI) => {

			if (e.playerID == startScreenUI.playerID)
			{
				if (e.playerID == 1)
				{
					Sprite sprite1 = Resources.Load<Sprite>("P1_ready");
					Image image1 = ego.gameObject.GetComponent<Image>();
					image1.sprite = sprite1;
				}
				else if (e.playerID == 2)
				{
					Sprite sprite2 = Resources.Load<Sprite>("P2_ready");
					Image image2 = ego.gameObject.GetComponent<Image>();
					image2.sprite = sprite2;
				}
			}
		});
	}

	void Handle(PlayerNotReadyEvent e)
	{
		constraint.ForEachGameObject ((ego, startScreenUI) => {

			if (e.playerID == startScreenUI.playerID)
			{
				if (e.playerID == 1)
				{
					Sprite sprite1 = Resources.Load<Sprite>("P1_sitDown");
					Image image1 = ego.gameObject.GetComponent<Image>();
					image1.sprite = sprite1;
				}
				else if (e.playerID == 2)
				{
					Sprite sprite2 = Resources.Load<Sprite>("P2_sitDown");
					Image image2 = ego.gameObject.GetComponent<Image>();
					image2.sprite = sprite2;
				}
			}
		});	
	}
}
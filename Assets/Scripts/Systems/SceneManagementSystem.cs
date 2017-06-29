using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagementSystem : EgoSystem<EgoConstraint<SceneManagerComponent>>
{
	public override void Start()
	{
		EgoEvents<SwitchSceneEvent>.AddHandler(Handle);
	}

	public override void Update()
	{
		constraint.ForEachGameObject ((ego, sceneManagement) => { 

			if (sceneManagement.startTimer)
			{
				sceneManagement.timer -= Time.deltaTime;

				if (sceneManagement.timer < 0)
				{
					SceneManager.LoadScene("Level");
				}
			}
		});
	}

	public override void FixedUpdate()
	{
		
	}

	void Handle(SwitchSceneEvent e)
	{
		constraint.ForEachGameObject ((ego, sceneManagement) => { 
			sceneManagement.startTimer = true;
		});
	}
}
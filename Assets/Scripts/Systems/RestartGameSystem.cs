using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameSystem : EgoSystem<EgoConstraint<RestartGameComponent>>
{
	public override void Update()
	{
		constraint.ForEachGameObject ((egoComponent, restart) => {

			restart.timer -= Time.deltaTime;

			if (restart.timer < 0)
			{
				SceneManager.LoadScene("Level");
			}
		});
		
	}
}
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class WalkTowardsTargetTest  {
	private NavMeshAgent _agent;
	private WalkTowardsGoalAbility _ability;


	private void CreateSetup()
	{
		var go = new GameObject("TestAgent");
		_agent = go.AddComponent<NavMeshAgent>();
		_ability = go.AddComponent<WalkTowardsGoalAbility>();
	}

	[TearDown]
	public void RunAfterEveryTest()
	{
		if (_agent != null)
		{
			Object.DestroyImmediate(_agent.gameObject);
		}
	}

	[UnityTest]
	public IEnumerator SetTargetShouldMoveToTarget()
	{
		yield return SceneManager.LoadSceneAsync("TestingGround", LoadSceneMode.Additive);
		CreateSetup();
		_ability.Init(new NewWalkTargetSignal());
		_ability.SetSpeed(10);
		_agent.transform.position = new Vector3(0,0,0);
		_ability.SetTarget(new Vector3(2,0,2));
		while (!_agent.hasPath)
		{
			yield return null;
		}
		yield return new WaitForSeconds(1);
		Assert.IsTrue(_ability.transform.position.x > 1.9 && _ability.transform.position.x < 2.1,
			string.Format("Expected x>9.9 & <10.1 got:{0}", _ability.transform.position.x));
		Assert.IsTrue(_ability.transform.position.z > 1.9 && _ability.transform.position.z < 2.1,
			string.Format("Expected z>9.9 & <10.1 got:{0}", _ability.transform.position.z));
		yield return SceneManager.UnloadSceneAsync("TestingGround");
	}
}

using UnityEngine;
using System.Collections;

public class Striker : MonoBehaviour
{

	public float _Spin;
	public float _Power;
	public float _Throw = 20;

	public GameObject Endtarget;
	public GameObject EndtargetWrong;

	 Vector3 targetPosition;

	public bool IsCorrect=false;



	void Start()
	{

	}


	void Update()
	{
		




		if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > .1)
			return;


		/*
		
	if (Input.GetKey(KeyCode.LeftArrow))
		{
			Vector3 addition = Vector3.forward * Time.deltaTime;
			gameObject.transform.position -= addition;
		}
	if (Input.GetKey(KeyCode.RightArrow))
		{
			Vector3 addition = Vector3.forward * Time.deltaTime;
			gameObject.transform.position += addition;
		}
	

			




	if (Input.GetKey(KeyCode.Space))
		{
			_Power += _Throw * 1000 * Time.deltaTime;
		}		
	
	if (Input.GetKeyUp(KeyCode.Space))
	{
		StartCoroutine(Throw());
	}
	*/

	}
/*	public void ShootBallBT()
	{

		_Power = 10000; 
		StartCoroutine(Throw());
		print("Press Shoot");

	}
	*/

	public void Shoot()
	{
		if(IsCorrect){
			_Power = 10000; // Set base power value 

		}else{
			_Power = 1000; // Set base power value 

		}
		

		// Apply force directly without using a coroutine
		gameObject.GetComponent<ConstantForce>().force = new Vector3(_Power * -1, 0, 0);
		gameObject.GetComponent<ConstantForce>().relativeForce = gameObject.GetComponent<ConstantForce>().force * .1f;
		gameObject.GetComponent<ConstantForce>().torque = new Vector3(-100, _Spin, 0);


	StartCoroutine(ClearForcesAfterDelay(.1f));
		

		print("Press Shoot");
	}
	


	 private IEnumerator ClearForcesAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Clear applied forces after delay
        gameObject.GetComponent<ConstantForce>().force = Vector3.zero;
        gameObject.GetComponent<ConstantForce>().relativeForce = Vector3.zero;
        gameObject.GetComponent<ConstantForce>().torque = Vector3.zero;

		if(IsCorrect){
			 targetPosition = Endtarget.transform.position;
			 print("Correct Potition");
			  // Move to the target position
      

		}else{
			 targetPosition = EndtargetWrong.transform.position;
			  print("Wrong Potition");

		}
  StartCoroutine(MoveToTarget());
       
    }
 private IEnumerator MoveToTarget()
    {
		


       
        float speed = 1f; // Adjust 

        while (Vector3.Distance(transform.position, targetPosition) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
			Debug.Log("Object reached the target!");
            yield return null;
        }

        // Ensure object reaches target position
        transform.position = targetPosition;

        Debug.Log("Object reached the target End!");
    }

	



	public IEnumerator Throw()
	{
		gameObject.GetComponent<ConstantForce>().force = new Vector3(_Power * -1, 0, 0);
		gameObject.GetComponent<ConstantForce>().relativeForce = gameObject.GetComponent<ConstantForce>().force * .1f;
		gameObject.GetComponent<ConstantForce>().torque = new Vector3(-100, _Spin, 0);
		yield return 0;
		gameObject.GetComponent<ConstantForce>().force = Vector3.zero;
		gameObject.GetComponent<ConstantForce>().relativeForce = Vector3.zero;
		gameObject.GetComponent<ConstantForce>().torque = Vector3.zero;

		yield break;

	}

	public void Reset(object _ball)
	{

		_Power = 0;
		_Spin = Random.Range(-100, 100);
		gameObject.GetComponent<ConstantForce>().force = Vector3.zero;
		gameObject.GetComponent<ConstantForce>().relativeForce = Vector3.zero;
		gameObject.GetComponent<ConstantForce>().torque = Vector3.zero;
		gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
print("Reset");

	}


}



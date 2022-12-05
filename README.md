# BAE DOKO
<div>
    <h2> 게임 정보 </h2>
    <img src = "https://img.itch.zone/aW1nLzEwNjg5MTM2LnBuZw==/347x500/CDOy79.png"><br>
    <img src="https://img.shields.io/badge/Unity-yellow?style=flat-square&logo=Unity&logoColor=FFFFFF"/>
    <img src="https://img.shields.io/badge/Racing-blue"/>
    <h4> 개발 일자 : 2022.11 <br><br>
    
  </div>
    <div>
    <h2> 게임 플레이 영상 </h2>
  </div>
  <div>
    <h2> 배운 점 </h2>
      첫 3D 게임이라 여러 기능을 구현하는 데 어려움을 겪었다.<br><br>
      내 생각처럼 물리적으로 움직이지 않았다.<br><br>
      Mesh Collider를 가진 물체가 Rigidbody를 이용해서 움직일 수 없다는 걸 알았다.<br><br>
      3D 물체를 돌리는 과정에서 Quaternion에 대한 내용을 배웠다.<br><br>
      
  </div>
  <div>
    <h2> 수정할 점 </h2>
      좀 더 정확한 움직임.<br><br>
      다양한 물체 구현.<br><br>
  </div>
   <div>
       <h2> 주요 코드 </h2>
       <h4> PlayerMovement 함수 </h4>
    </div>
    
```csharp

//Ground Check
grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.01f, ground);
Debug.Log(grounded);
Debug.DrawRay(transform.position, Vector3.down * playerHeight * 0.7f, Color.yellow);

//키 값으로 움직임, 수정하면 키 매핑 가능
if (Input.GetKey("a")) horizontalInput = 1;
else if(Input.GetKey("d")) horizontalInput = -1;

if (Input.GetKey("w")) verticalnput = -1;
else if (Input.GetKey("s")) verticalnput = 1;

if (Input.GetKeyUp("a") || Input.GetKeyUp("d")) horizontalInput = 0;
if (Input.GetKeyUp("w") || Input.GetKeyUp("s")) verticalnput = 0;

        
//horizontalInput = Input.GetAxisRaw("Horizontal");
//verticalnput = Input.GetAxisRaw("Vertical");

moveDirection = orientation.forward * verticalnput + orientation.right * horizontalInput;

if (Input.GetKeyDown("left shift") && mainSM.coffeeAmount > 0)
{
    mainSM.CoffeeUse(1);
    rb.AddForce(moveDirection * 1000);
}

//속도가 일정 이상으로 증가하지 않도록
SpeedControl();

//점프
if(Input.GetKey(jumpkey) && readyToJump && grounded)
{
    readyToJump = false;
    Jump();

Invoke(nameof(ResetJump), jumpCooldown);
}

//공중에 있을 때
if(grounded)
    rb.AddForce(moveDirection.normalized * moveSpeed * 500 * Time.deltaTime);
else if(!grounded)
    rb.AddForce(moveDirection.normalized * moveSpeed * 500 * airMultiplier * Time.deltaTime);
```

<div>
    <h4> SpeedControl 함수 </h4>
</div>
```csharp
private void SpeedControl()
{
    Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
    if(flatVel.magnitude > moveSpeed)
    {
        Vector3 limitedVel = flatVel.normalized * moveSpeed;
        rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
    }
}
```

Credit

"Weekly - Dice" (https://skfb.ly/onrTu) by beewee is licensed under Creative Commons Attribution-NonCommercial (http://creativecommons.org/licenses/by-nc/4.0/).

"Gamepads" (https://skfb.ly/orJYC) by MORok001 is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

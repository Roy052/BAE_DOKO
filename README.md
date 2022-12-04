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
    https://youtu.be/P5pWeMf9Fr0
  </div>
  <div>
    <h2> 배운 점 </h2>
      첫 3D 게임이라 여러 기능을 구현하는 데 어려움을 겪었다.<br><br>
      내 생각처럼 물리적으로 움직이지 않았다.
      물체를 돌리는 과정에서 Quaternion에 대한 내용을 배웠다.
  </div>
  <div>
    <h2> 수정할 점 </h2>
      좀 더 정확한 움직임.<br><br>
      추가적인 컨텐츠
  </div>
   <div>
       <h2> 주요 코드 </h2>
       <h4> MainSM SetUp 함수 </h4>
    </div>
    
```csharp
situationNum = Random.Range(0, 4);

mainSprite = Resources.Load<Sprite>("Arts/MainImage/" + situationNum);
midSprite = Resources.Load<Sprite>("Arts/MiddleImage/" + situationNum);

screenImage.GetComponent<SpriteRenderer>().sprite = mainSprite;
```


Credit

"Weekly - Dice" (https://skfb.ly/onrTu) by beewee is licensed under Creative Commons Attribution-NonCommercial (http://creativecommons.org/licenses/by-nc/4.0/).

"Gamepads" (https://skfb.ly/orJYC) by MORok001 is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

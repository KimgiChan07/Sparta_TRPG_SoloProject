namespace Sparta_TRPG_SoloProject
{ 
    /*
            
            [필요한 클래스]

            <초기화 씬 클래스>
              Player
                ㄴ 정보씬호출
              Item
                ㄴ 아이템씬 호출
              Shop
                ㄴ 상점씬 호출
              Inventory
                ㄴ 인벤토리씬 호출
              Monster(도전)

            <인게임 클래스>
              Main(게임시작시 초기화)
                ㄴ되도록 -- 게임 시작만

              GaamManager(게임 내용을 다룸)
                                                              피드백) Init함수 제작 MainAction 후 subAction, Start씬을 정리해서 ->Main씬(while(true){  게임내용  })
                ㄴ player_state 초기화    
                ㄴ item 초기화
                ㄴ 게임 스타트
                ㄴ 행동 선택 씬 
                ㄴ 상점 씬
                ㄴ 정보 씬
                ㄴ 아이템창 씬
        
                ㄴ Monster_state 초기화(도전)
                ㄴ 공격씬(도전)

---------------------------------------------------------------------------------------
         
                    [흐름도]

            Main()->GameManager의 Start클래스 호출 
            
            Start() = 행동 선택씬

            행동 선택씬
                ㄴ 내 정보-> 내 정보씬
                ㄴ 상점-> 상점씬
                ㄴ 인벤토리-> 인벤토리씬
                
                         **GameManager를 통해 Action 메서드를 이용하여 관리**
                         
            */// 흐름도, 메서드 정리
    
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            gameManager.TRPG_Main();
        }
    }
}

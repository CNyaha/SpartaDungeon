using System.ComponentModel.Design;
using System.Net;
using System.Runtime.InteropServices;

namespace SpartaDungeon
{
    public interface IChracter
    {
        // 유저의 이름
        public string Name { get; }
        // 캐릭터의 체력
        public int Health { get;set; }
        // 캐릭터의 공격력
        public int Attack { get; set; }
        // 무기의 공격력
        public int WeaponAttack { get; set; }

        // 캐릭터의 방어력
        public int Defence { get; set; }
        // 방어구의 방어력
        public int ArmorDefence {  get; set; }

        // 캐릭터의 레벨
        public int Level { get; set; }
        // 캐릭터가 사망했는지
        public bool IsDead { get; }
        // 캐릭터의 직업(아직 구현안함)
        public string Job { get; set; }
        // 플레이어가 무기를 장착 했는지
        public bool isWeaponEquip {  get; set; }
        //플레이어가 방어구를 장착 했는지
        public bool isArmorEquip { get; set; }
        // 플레이어의 골드
        public int Gold { get; set; }
        // 플레이어의 경험치
        public int Exp { get; set; }


        public void LevelExp(int exp);

        // 무기를 장착시키는 메서드
        public void WeaponEquipment(IChracter player, IWeapon equipitem, IWeapon changeItem);
        public void WeaponEquipment(IChracter player, IWeapon equipitem);
        // 무기를 장착해제 시키는 메서드
        public void WeaponUnEquipment(IChracter player, IWeapon item);

        // 방어구를 장착시키는 메서드
        public void ArmorEquipment(IChracter player, IArmor equipitem, IArmor changeItem);
        public void ArmorEquipment(IChracter player, IArmor equipitem);
        // 방어구를 장착해제시키는 메서드
        public void ArmorUnEquipment(IChracter player, IArmor item);

        // 캐릭터가 데미지를 받았을 때
        public void TakeDamage(int damage);
        // 플레이어 캐릭터의 상태창
        public void PlayerStats(IChracter player);

    }

    public interface IWeapon
    {
        // 무기의 이름
        public string Name { get; set; }
        // 장착중인 무기의 이름
        public string EquipName { get; set; }
        // 무기를 장착 했는지
        public bool isEquip { get; set; }
        // 무기의 공격력
        public int Attack { get; set; }
        // 해당 무기를 얻었는지
        public bool isAcquire { get; set; }
        // 무기의 정보
        public string Info { get; set; }
        // 아이템의 숫자
        public int ItemNumber { get; set; }
        public int WeaponGold { get; set; }

        // 무기의 정보를 알려주는 메서드
        public void ItemState();
        public void StoreItemState();
    }

    public class Weapon : IWeapon
    {
        public string Name { get; set; }
        public string EquipName { get; set; }
        public bool isEquip { get; set; }

        public int Attack { get; set; }
        public bool isAcquire { get; set; } = false;
        public string Info { get; set; }
        public int WeaponGold { get; set; }
        public int ItemNumber { get; set; } = -1;

        public Weapon(string name, int attack, string itemInfo, int gold)
        {
            Name = name;
            Attack = attack;
            Info = itemInfo;
            WeaponGold = gold;
            EquipName = "[E] " + name;
        }

        public void ItemState()
        {
            if (isEquip)
            {
                Console.WriteLine($"{EquipName} |   공격력 +{Attack}   | {Info}");
            }
            else
            {
                Console.WriteLine($"{Name}  |   공격력 +{Attack}   | {Info}");
            }
        }
        public void StoreItemState()
        {
            if (isAcquire)
            {
                Console.WriteLine($"{Name}  |   공격력 +{Attack}   | {Info} | 구매완료");
            }
            else
            {
                Console.WriteLine($"{Name}  |   공격력 +{Attack}   | {Info} | {WeaponGold}");
            }
        }



    }

    public interface IArmor
    {
        // 방어구의 이름
        public string Name { get; set; }
        // 장착한 방어구의 이름
        public string EquipName { get; set; }
        // 방어구를 장착 했는지
        public bool isEquip { get; set; }
        // 방어구의 방어력
        public int Defence { get; set; }
        // 방어구의 설명
        public string Info { get; set; }
        // 방어구를 습득했는지
        public bool isAcquire { get; set; }
        // 방어구의 숫자(상점의 위치)
        public int ItemNumber { get; set; }

        public int ArmorGold {  get; set; }

        // 방어구의 상세설명
        public void ItemState();
        public void StoreItemState();
        
    }

    public class Armor : IArmor
    {
        public string Name { get; set; }
        public string EquipName { get; set; }
        public bool isEquip { get; set; }

        public bool isAcquire { get; set; } = false;
        public int Defence { get; set; }
        public string Info { get; set; }
        public int ItemNumber { get; set; } = -1;

        public int ArmorGold { get; set; }

        public Armor(string name, int defence, string itemInfo, int gold)
        {
            Name = name;
            Defence = defence;
            Info = itemInfo;
            ArmorGold = gold;
            EquipName = "[E] " + name;
        }

        public void ItemState()
        {
            if (isEquip)
            {
                Console.WriteLine($"{EquipName} |   방어력 +{Defence}   | {Info}");
            }
            else if(isEquip == false)
            {
                Console.WriteLine($"{Name}  |   방어력 +{Defence}   | {Info}");

            }
        }

        public void StoreItemState()
        {
            if (isAcquire)
            {
                Console.WriteLine($"{Name}  |   방어력 +{Defence}   | {Info} | 구매완료");
            }
            else
            {
                Console.WriteLine($"{Name}  |   방어력 +{Defence}   | {Info} | {ArmorGold}");
            }
        }


    }

    public class Warrior : IChracter
    {
        public string Name { get; }
        public int Health { get; set; }
        public int Level { get; set; } = 1;
        public int Attack { get; set; }
        public int WeaponAttack { get; set; } = 0;
        public int Defence { get; set; }
        public int ArmorDefence { get; set; } = 0;

        public string Job { get; set; }

        // 플레이어가 무기를 장착 했는지
        public bool isWeaponEquip { get; set; }
        //플레이어가 방어구를 장착 했는지
        public bool isArmorEquip { get; set; }

        public bool IsDead => Health <= 0;
        public int Gold { get; set; }

        public int Exp { get; set; } = 0;


        public void LevelExp(int exp)
        {
            Exp += exp;
            if (Exp == Level)
            {
                Level++;
                Exp = 0;
                Console.WriteLine("레벨업을 하셨습니다!.");
                Console.WriteLine($"현재 레벨 : {Level}");
            }
        }

        public Warrior(string name)
        {
            Name = name;
            Job = "전사";
            Level = 1;
            Health = 100;
            Defence = 5;
            Attack = 10;
            Gold = 1500;
        }

        // 플레이어가 damage만큼의 피해를 입는 메서드
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (IsDead)
            {
                Console.WriteLine("플레이어가 사망하였습니다.");
            }
            else
            {
                Console.WriteLine($"{Health}");
            }
        }

        // 장착되어있는 무기를 해제 후 다른 무기를 장착시킨다.
        public void WeaponEquipment(IChracter player, IWeapon equipItem, IWeapon changeItem)
        {
            if (equipItem.isEquip == false)
            {
                equipItem.isEquip = true;
                player.WeaponAttack += equipItem.Attack;
                player.isWeaponEquip = true;
            }
            else if (equipItem.isEquip == true)
            {
                equipItem.isEquip = false;
                player.WeaponAttack -= equipItem.Attack;

                changeItem.isEquip = true;
                player.WeaponAttack += changeItem.Attack;
            }
        }
        // 무기를 장착시킨다.
        public void WeaponEquipment(IChracter player, IWeapon equipItem)
        {

            equipItem.isEquip = true;
            player.WeaponAttack += equipItem.Attack;

            player.isWeaponEquip = true;
        }

        // 무기를 장착 해제시킨다.
        public void WeaponUnEquipment(IChracter player, IWeapon equipItem)
        {
            if (equipItem.isEquip == false)
            {
                Console.WriteLine("장착한 아이템이 아닙니다.");
            }
            else if (equipItem.isEquip == true)
            {
                equipItem.isEquip = false;
                player.WeaponAttack -= equipItem.Attack;

                player.isWeaponEquip = false;
            }
        }

        // 장착되어있는 방어구가 있다면 장착 해제 후 장착시킨다.
        public void ArmorEquipment(IChracter player, IArmor equipItem, IArmor changeItem)
        {
            if (equipItem.isEquip == false)
            {
                equipItem.isEquip = true;
                player.ArmorDefence += equipItem.Defence;

                player.isArmorEquip = true;
            }
            else if (equipItem.isEquip == true)
            {
                equipItem.isEquip = false;
                player.ArmorDefence -= equipItem.Defence;

                changeItem.isEquip = true;
                player.ArmorDefence += changeItem.Defence;
            }
        }
        // 방어구를 장착시킨다.
        public void ArmorEquipment(IChracter player, IArmor equipItem)
        {

            equipItem.isEquip = true;
            player.ArmorDefence += equipItem.Defence;

            player.isArmorEquip = true;
        }

        // 방어구를 장착 해제하는 메서드
        public void ArmorUnEquipment(IChracter player, IArmor equipItem)
        {
            if (equipItem.isEquip == false)
            {
                Console.WriteLine("장착한 아이템이 아닙니다.");
            }
            else if (equipItem.isEquip == true)
            {
                equipItem.isEquip = false;
                player.ArmorDefence -= equipItem.Defence;

                player.isArmorEquip = false;
            }
        }

        // 플레이어의 상태창을 알려주는 메서드
        public void PlayerStats(IChracter player)
        {
            bool isState = true;
            while (isState)
            {
                Thread.Sleep(300);
                Console.Clear();

                Console.WriteLine($"이름 : {Name}");
                Console.WriteLine($"Lv. {Level}");
                Console.WriteLine($"Chad ({Job})");

                if (player.isWeaponEquip)
                {
                    Console.WriteLine($"공격력 : {Attack + WeaponAttack} + ({WeaponAttack})");
                }
                else
                {
                    Console.WriteLine($"공격력 : {Attack}");
                }

                if (player.isArmorEquip)
                {
                    Console.WriteLine($"방어력 : {Defence + ArmorDefence} + ({ArmorDefence})");
                }
                else
                {
                    Console.WriteLine($"방어력 : {Defence}");

                }

                Console.WriteLine($"체 력 : {Health}");
                Console.WriteLine($"Gold : {Gold}");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                int nNumber;
                string s = Console.ReadLine();
                bool numberCheck = int.TryParse(s, out nNumber);

                if (!numberCheck)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else
                {
                    switch (nNumber)
                    {
                        case 0:
                            isState = false;
                            break;

                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;

                    }
                }


            }
        }

    }

    // 게임을 관리하는 클래스
    public class GameManager
    {
        private IChracter player;

        private string number;
        private bool isVliage = true;
        int time = 500;

        public GameManager(IChracter player)
        {
            this.player = player;
        }

        // 아이템의 번호를 초기화시켜주는 메서드
        public void ItemNumberReset(List<IWeapon> weapons, List<IArmor> armors)
        {
            foreach (IWeapon weapon in weapons)
            {
                weapon.ItemNumber = -1;
            }
            foreach (IArmor armor in armors)
            {
                armor.ItemNumber = -1;
            }
        }

        // 게임 시작
        public void GameStart(IChracter player, List<IWeapon> weapons, List<IArmor> armors)
        {
            
            while (isVliage)
            {
                Thread.Sleep(time);
                Console.Clear();

                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다. \n \n");
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 던전입장");
                Console.WriteLine("5. 휴식하기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                int number = -1;
                string s = Console.ReadLine();
                bool isNumberCheck = int.TryParse(s, out number);

                if (!isNumberCheck)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else
                {
                    switch (number)
                    {
                        case 1:
                            player.PlayerStats(player);
                            break;

                        case 2:
                            Inventory(player, weapons, armors);
                            break;

                        case 3:
                            Store(player, weapons, armors);
                            break;

                        case 4:
                            DungeonSelect(player);
                            break;

                        case 5:
                            Rest(player);
                            break;

                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }


            }


        }
        // 인벤토리
        public void Inventory(IChracter player, List<IWeapon> weapons, List<IArmor> armors)
        {
            // 인벤토리를 나가기 전까지 계속 반복시켜줄 변수
            bool isInventory = true;
            // 장착관리를 들어갔을 때 활성화 시켜줄 변수
            bool isEquipManage = false;

            while (isInventory)
            {

                Thread.Sleep(500);
                Console.Clear();
                ItemNumberReset(weapons, armors);

                

                int count = 1;

                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다. \n");
                Console.WriteLine("[아이템 목록]");

                //isAcquire이 true인 무기만 선택한다.
                foreach (IWeapon weapon in weapons.Where(wp => wp.isAcquire))
                {
                    if (!isEquipManage)
                    {
                        weapon.ItemState();
                    }
                    else
                    {
                        Console.Write($"{count}. ");
                        weapon.ItemState();
                        weapon.ItemNumber = count;
                        count++;
                    }
                }

                foreach (IArmor armor in armors.Where(am => am.isAcquire))
                {
                    if (!isEquipManage)
                    {
                        armor.ItemState();
                    }
                    else
                    {
                        Console.Write($"{count}. ");
                        armor.ItemState();
                        armor.ItemNumber = count;
                        count++;
                    }
                }

                if (!isEquipManage)
                {

                    Console.WriteLine("\n1. 장착 관리");
                    Console.WriteLine("0. 나가기 \n");
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">> ");

                    int number;
                    string s = Console.ReadLine();
                    bool numberCheck = int.TryParse(s, out number);

                    if (!numberCheck)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                    else
                    {
                        switch (number)
                        {
                            case 1:
                                isEquipManage = true;
                                break;

                            case 0:
                                isInventory = false;
                                break;

                            default:
                                Console.WriteLine("잘못된 입력입니다.");
                                break;

                        }
                    }
                }
                else if (isEquipManage)
                {
                    Console.WriteLine("\n0. 나가기\n");
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">> ");

                    int number;
                    string s = Console.ReadLine();
                    bool numberCheck = int.TryParse(s, out number);

                    if (!numberCheck)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                    else
                    {

                        if (number == 0)
                        {
                            // 장착관리 나가기
                            isEquipManage = false;
                        }
                        else if (count > number)
                        {
                            // 설정이 완료됐는지 확인하는 변수
                            bool isSuccess = false;

                            // weapon의 아이템 번호와 선택한 번호가 같다면
                            foreach (IWeapon weapon in weapons.Where(wp => wp.ItemNumber == number))
                            {
                                // 플레이어가 무기를 장착하고 있다면
                                if (player.isWeaponEquip)
                                {
                                    // equipWeapon중에 장착중인 아이템이 있다면
                                    foreach (IWeapon equipWeapon in weapons.Where(wp1 => wp1.isEquip))
                                    {
                                        // equipWeapon과 weapon이 같다면
                                        if (equipWeapon == weapon)
                                        {
                                            // 아이템 장착해제
                                            player.WeaponUnEquipment(player, weapon);
                                            isSuccess = true;
                                            break;
                                        }
                                        else
                                        {
                                            // 아니라면 equipWeapon을 해제하고 weapon을 장착
                                            player.WeaponEquipment(player, equipWeapon, weapon);
                                            isSuccess = true;
                                            break;
                                        }
                                    }
                                }
                                // 무기를 장착중이 아니라면
                                else if (player.isWeaponEquip == false)
                                {
                                    //  weapon 무기 장착
                                    player.WeaponEquipment(player, weapon);
                                    isSuccess = true;
                                    break;
                                }

                            }


                            if (!isSuccess)
                            {
                                //   armors에 ItemNumber가 number 랑 같다면
                                foreach (IArmor armor in armors.Where(ar => ar.ItemNumber == number))
                                {
                                    // 플레이어가 방어구를 장착했는지 확인
                                    if (player.isArmorEquip)
                                    {
                                        // 장착중인 방어구를 확인(isEquip이 true라면)
                                        foreach (IArmor equipArmor in armors.Where(ea => ea.isEquip))
                                        {
                                            // 장착중인 아이템 번호와 장찰할 아이템 번호가 같다면 방어구 해제
                                            if (armor == equipArmor)
                                            {
                                                player.ArmorUnEquipment(player, armor);
                                                break;
                                            }
                                            // 아니라면 방어구를 바꾼다.
                                            else
                                            {
                                                player.ArmorEquipment(player, equipArmor, armor);
                                                break;
                                            }

                                        }
                                    }
                                    // 장착을 안했다면 장착시켜주기
                                    else if (player.isArmorEquip == false)
                                    {
                                        player.ArmorEquipment(player, armor);
                                        break;
                                    }
                                }
                            }


                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                    }
                }
            }




        }

        // 상점
        public void Store(IChracter player, List<IWeapon> weapons, List<IArmor> armors)
        {
            // 상점
            bool isStore = true;
            // 상점 구매창을 열게 해줄 변수
            bool isShopBuy = false;
            // 상점 판매창을 열게 해줄 변수
            bool isShopSell = false;
            // 아이템을 장착 했는지
            bool isEquipManage = false;

            while (isStore)
            {
                // 아이템의 번호를 새길 변수
                int count = 1;
                Thread.Sleep(time);
                Console.Clear();
                ItemNumberReset(weapons, armors);

                if (!isShopSell)
                {
                    Console.Write("상점");
                    if (isShopBuy)
                        Console.WriteLine(" - 아이템 구매");

                    else
                        Console.WriteLine();
                    Console.WriteLine("필요한 아이템을 구매와 판매 할 수 있는 상점입니다.\n");
                    Console.WriteLine("[보유 골드]");
                    Console.WriteLine($"{player.Gold} G\n");

                    Console.WriteLine("[아이템 목록]");
                    foreach (IWeapon weapon in weapons)
                    {
                        weapon.ItemNumber = count;
                        count++;
                        Console.Write("- ");
                        if (isShopBuy)
                            Console.Write($"{weapon.ItemNumber}. ");
                        weapon.StoreItemState();
                    }
                    foreach (IArmor armor in armors)
                    {
                        armor.ItemNumber = count;
                        count++;
                        Console.Write("- ");
                        if (isShopBuy)
                            Console.Write($"{armor.ItemNumber}. ");
                        armor.StoreItemState();
                    }
                }

                if (!isShopBuy && !isShopSell)
                {
                    Console.WriteLine("\n1. 아이템 구매");
                    Console.WriteLine("2. 아이템 판매");
                    Console.WriteLine("0. 나가기\n");
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">> ");

                    int number;
                    string s = Console.ReadLine();
                    bool numberCheck = int.TryParse(s, out number);

                    if (!numberCheck)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                    else
                    {

                        switch (number)
                        {
                            case 1:
                                isShopBuy = true;
                                break;

                            case 2:
                                isShopSell = true;
                                break;

                            case 0:
                                isStore = false;
                                break;

                            default:
                                Console.WriteLine("잘못된 입력입니다.");
                                break;
                        }
                    }
                }
                else if(isShopBuy)
                {
                    Console.WriteLine("\n0. 나가기\n");
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">> ");

                    int number;
                    string s = Console.ReadLine();
                    bool numberCheck = int.TryParse(s, out number);

                    if (!numberCheck)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                    else
                    {
                        if (count <= number)
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                        else if (number == 0)
                        {
                            isShopBuy = false;
                        }
                        else if (count > number)
                        {
                            bool isSuccess = false;

                            foreach (IWeapon weapon in weapons.Where(wp => wp.ItemNumber == number))
                            {
                                if (weapon.isAcquire)
                                {
                                    Console.WriteLine("이미 구매한 아이템입니다.");
                                    isSuccess = true;
                                    break;
                                }
                                else if (player.Gold < weapon.WeaponGold)
                                {
                                    Console.WriteLine("Gold 가 부족합니다.");
                                    isSuccess = true;
                                    break;
                                }
                                else if (player.Gold >= weapon.WeaponGold)
                                {
                                    player.Gold -= weapon.WeaponGold;
                                    weapon.isAcquire = true;
                                    Console.WriteLine("구매를 완료했습니다.");
                                    isSuccess = true;
                                    break;
                                }

                            }
                            if (!isSuccess)
                            {
                                foreach (IArmor armor in armors.Where(ar => ar.ItemNumber == number))
                                {
                                    if (armor.isAcquire)
                                    {
                                        Console.WriteLine("이미 구매한 아이템입니다.");
                                        isSuccess = true;
                                        break;
                                    }
                                    else if (player.Gold < armor.ArmorGold)
                                    {
                                        Console.WriteLine("Gold 가 부족합니다.");
                                        isSuccess = true;
                                        break;
                                    }
                                    else if (player.Gold >= armor.ArmorGold)
                                    {
                                        player.Gold -= armor.ArmorGold;
                                        armor.isAcquire = true;
                                        Console.WriteLine("구매를 완료했습니다.");
                                        isSuccess = true;
                                        break;
                                    }

                                }
                                Thread.Sleep(time);
                            }
                        }
                    }

                }
                else if (isShopSell)
                {
                    while (isShopSell)
                    {
                        ItemNumberReset(weapons, armors);

                        // 아이템 번호를 1로 초기화
                        count = 1;

                        Console.WriteLine("상점 - 아이템 판매");

                        Console.WriteLine("필요한 아이템을 구매와 판매 할 수 있는 상점입니다.\n");
                        Console.WriteLine("[보유 골드]");
                        Console.WriteLine($"{player.Gold} G\n");

                        Console.WriteLine("[아이템 목록]");

                        // 수집한 무기가 있다면 표시
                        foreach (IWeapon weapon in weapons.Where(wp => wp.isAcquire))
                        {
                            weapon.ItemNumber = count;
                            count++;
                            Console.Write("- ");
                            if (isShopBuy)
                                Console.Write($"{weapon.ItemNumber}. ");
                            weapon.StoreItemState();
                        }
                        // 수집한 방어구가 있다면 표시
                        foreach (IArmor armor in armors.Where(am => am.isAcquire))
                        {
                            armor.ItemNumber = count;
                            count++;
                            Console.Write("- ");
                            if (isShopBuy)
                                Console.Write($"{armor.ItemNumber}. ");
                            armor.StoreItemState();
                        }

                        Console.WriteLine("\n0. 나가기\n");
                        Console.WriteLine("원하시는 행동을 입력해주세요.");
                        Console.Write(">> ");

                        int number;
                        string s = Console.ReadLine();
                        bool numberCheck = int.TryParse(s, out number);

                        if (!numberCheck)
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                        else
                        {

                            if (number >= count)
                            {
                                Console.WriteLine("잘못된 입력입니다.");
                            }
                            else if (number == 0)
                            {
                                isShopSell = false;
                            }
                            else if (number < count)
                            {
                                foreach (IWeapon weapon in weapons.Where(wp => wp.ItemNumber == number))
                                {
                                    if (weapon.isEquip)
                                    {
                                        player.WeaponUnEquipment(player, weapon);
                                        Console.WriteLine($"{weapon.Name}를(을) {weapon.WeaponGold * 0.85f}에 판매하셨습니다.");
                                        player.Gold += (int)(weapon.WeaponGold * 0.85f);
                                        isEquipManage = true;
                                        weapon.isAcquire = false;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{weapon.Name}를(을) {weapon.WeaponGold * 0.85f}에 판매하셨습니다.");
                                        player.Gold += (int)(weapon.WeaponGold * 0.85f);
                                        isEquipManage = true;
                                        weapon.isAcquire = false;
                                        break;
                                    }
                                }
                                foreach (IArmor armor in armors.Where(ar => ar.ItemNumber == number))
                                {
                                    if (armor.isEquip)
                                    {
                                        player.ArmorUnEquipment(player, armor);
                                        Console.WriteLine($"{armor.Name}를(을) {armor.ArmorGold * 0.85f}에 판매하셨습니다.");
                                        player.Gold += (int)(armor.ArmorGold * 0.85f);
                                        armor.isAcquire = false;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{armor.Name}를(을) {armor.ArmorGold * 0.85f}에 판매하셨습니다.");
                                        player.Gold += (int)(armor.ArmorGold * 0.85f);
                                        armor.isAcquire = false;
                                        break;
                                    }
                                }
                                Thread.Sleep(time * 2);
                                Console.Clear();
                            }
                        }

                    }
                }
            }
        }

        // 휴식
        public void Rest(IChracter player)
        {


            bool isRest = true;

            while (isRest)
            {
                Random random = new Random();
                int restHeal = random.Next(50, 80);

                Thread.Sleep(time);
                Console.Clear();

                Console.WriteLine("휴식을 하시면 500G를 소모하고 체력을 회복합니다.\n0");
                Console.WriteLine($"현재 체력 : {player.Health} , 보유 골드 : {player.Gold}");
                Console.WriteLine("1. 휴식하기");
                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                int number;
                string s = Console.ReadLine();
                bool numberCheck = int.TryParse(s, out number);

                if (!numberCheck)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else
                {

                    switch (number)
                    {
                        case 1:
                            if (player.Gold < 500)
                            {
                                Console.WriteLine("Gold 가 부족합니다!");
                            }
                            else
                            {
                                Console.WriteLine("휴식을 시작합니다.");
                                Console.WriteLine($"체력 {restHeal}을 회복하셨습니다.");
                                player.Health += restHeal;
                                player.Gold -= 500;
                                Thread.Sleep(time);
                            }
                            break;

                        case 0:
                            isRest = false;
                            break;

                        default:
                            Console.WriteLine("잘못 입력하셨습니다.");
                            break;

                    }
                }
            }
        }

        // 던전
        public void Dungeon(string dungeonName, int recommendDefence,int rewardGold, IChracter player)
        {
            Thread.Sleep(time);
            Console.Clear();
            Random rand = new Random();
            int num;
            bool isFail = false;
            if (player.Defence < recommendDefence)
            {
                num = rand.Next(1, 11);
                // num의 값이 1 ~ 4 라면
                if (0 < num && num < 5)
                {
                    isFail = true;
                }
            }

            if (!isFail)
            {
                Console.WriteLine("던전 클리어");
                Console.WriteLine("축하합니다!!");
                Console.WriteLine($"{dungeonName}을 클리어 하셨습니다!\n");
                Console.WriteLine("[탐험 결과]");
                Console.Write($"체력 : {player.Health} => ");
                num = rand.Next(20 - (player.Defence - recommendDefence), 36 - (player.Defence - recommendDefence));
                player.TakeDamage(num);
                num = rand.Next(rewardGold * (player.Attack/100), rewardGold * ((player.Attack * 2) / 100));
                Console.WriteLine($"클리어 보상 {rewardGold} + 추가 보상 : {num} 만큼을 더 받으셨습니다!");
                Console.Write($"Gold : {player.Gold} => ");
                player.Gold += rewardGold + num;
                Console.Write($"{player.Gold}");

                Thread.Sleep(time * 5);
            }
            else
            {
                Console.WriteLine("던전탐험에 실패하셨습니다....\n\n");
                Console.WriteLine("체력을 절반 잃어버리셨습니다");
                Console.Write("남은 체력 : ");
                player.TakeDamage(player.Health / 50);
                

                Thread.Sleep(time * 5);
            }
        }

        public void DungeonSelect(IChracter player)
        {
            bool isDungoen = true;
            Random random = new Random();

            while (isDungoen)
            {
                Thread.Sleep(time);
                Console.Clear();

                Console.WriteLine("던전입장");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");

                Console.WriteLine("1. 쉬운 던전     | 방어력 5 이상 권장");
                Console.WriteLine("2. 일반 던전     | 방어력 11 이상 권장");
                Console.WriteLine("3. 어려운 던전    | 방어력 17 이상 권장");

                Console.WriteLine("\n0. 나가기");
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                int number;
                string s = Console.ReadLine();
                bool isNumberCheck = int.TryParse(s, out number);

                if (!isNumberCheck)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else
                {
                    switch (number)
                    {
                        case 1:
                            Dungeon("쉬운 던전", 5, 1000, player);
                            break;

                        case 2:
                            Dungeon("중간 던전", 11, 17000, player);
                            break;

                        case 3:
                            Dungeon("어려운 던전", 15, 2500, player);
                            break;

                        case 0:
                            isDungoen = false;
                            break;

                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
            }
        }

    }





    internal class Program
    {
        static public string NameSetting()
        {
            Console.WriteLine("스파르타 던전에 오신것을 환영합니다!");
            Console.WriteLine("원하시는 이름을 설정해주세요.");
            string name = Console.ReadLine();

            return name;
        }

        

        


        static void Main(string[] args)
        {
            List<IWeapon> weapons = new List<IWeapon> 
            {
                new Weapon("낡은 검", 2, "쉽게 볼 수 있는 낡은 검 입니다.", 600),
                new Weapon("청동 도끼", 5, "어디선가 사용됐던거 같은 도끼입니다.", 1500),
                new Weapon("스파르타의 창", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2500)
            };

            List<IArmor> armors = new List<IArmor>
            {
                new Armor("수련자의 갑옷", 5, "수련에 도음을 주는 갑옷입니다.", 1000),
                new Armor("무쇠 갑옷", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000),
                new Armor("스파르타의 갑옷", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3000)
            };


            string name = NameSetting();

            Console.WriteLine($"입력하신 이름은 {name} 입니다.");


            Warrior player = new Warrior(name);



            GameManager gManager = new GameManager(player);

            gManager.GameStart(player, weapons, armors);


            


        }
    }
}

namespace TextRPG
{
    internal class Program
    {
        enum Place { town, home, training, forest, name, choice }
        enum Job { warrior = 1, archer, mage, rogue, pirate }
        enum FightChoice { basicAttack = 1, skillAttack, runAway }
        enum Training { strength = 1, mental, cardio, find }
        struct Character
        {
            public string name;
            public int hp;
            public int mp;
            public int str;
            public int dex;
            public int intel;
            public int luk;
        }

        struct Monster
        {
            public string name;
            public int hp;
            public int def;
            public int atk;
        }

        struct GameData
        {
            public bool run;

            public Place place;
            public Job job;
            public FightChoice fightChoice;
            public Training training;
            public Character character;
            public Monster Monster;

            public int maxhp;
            public int maxmp;
            public bool fight;
            public int monsterspawn;
        }

        static GameData data;

        static void MonSlime()
        {
            data.Monster = new Monster();
            data.Monster.name = "슬라임";
            data.Monster.hp = 30;
            data.Monster.atk = 10;
            data.Monster.def = 5;
        }

        static void SlimeSpwan()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("         -----");
            Console.WriteLine("       ＾     O");
            Console.WriteLine("     ／  ＼ ");
            Console.WriteLine("   ／      ＼");
            Console.WriteLine("   ＼      ／");
            Console.WriteLine("    ＼____／");
            Console.ResetColor();
        }
        static void MonGolem()
        {
            data.Monster = new Monster();
            data.Monster.name = "골렘";
            data.Monster.hp = 200;
            data.Monster.atk = 40;
            data.Monster.def = 20;
        }
        static void GolemSpwan()
        {
            Console.WriteLine("\n\n\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("       ======");
            Console.WriteLine("       |    | ");
            Console.WriteLine("       |____|");
            Console.WriteLine("   ／            ＼");
            Console.WriteLine("  |   |       |   |");
            Console.WriteLine("  |   |       |   |");
            Console.WriteLine("  |___|       |___|");
            Console.WriteLine("     |__________|");
            Console.WriteLine("     |          |");
            Console.WriteLine("     |     |    |");
            Console.WriteLine("     |     |    |");
            Console.WriteLine("     |     |    |");
            Console.WriteLine("     |     |    |");
            Console.WriteLine("    |______|_____|");
            Console.ResetColor();
        }
        //Main==================================================================================================
        static void Main(string[] args)
        {
            Start();
            while (data.run == true)
            {
                Run();
            }
        }
        //Main==================================================================================================
        static void Start()
        {
            data.run = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===============================================");
            Console.WriteLine("=                                             =");
            Console.WriteLine("=                  Text RPG                   =");
            Console.WriteLine("=                                             =");
            Console.WriteLine("===============================================");
            Console.ResetColor();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("          Press the Any Key to Start");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n\n\n        전체화면으로 진행 부탁드립니다");
            Console.ResetColor();
            Console.ReadKey();

            data.place = Place.name;
        }
        // 시작화면
        static void Die()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("체력이 부족하여 플레이어가 사망하였습니다");
            Console.WriteLine("===============================================");
            Console.WriteLine("=                                             =");
            Console.WriteLine("=                  YOU DIED                   =");
            Console.WriteLine("=                                             =");
            Console.WriteLine("===============================================");

            Environment.Exit(0);
        }
        // 사망화면

        static void Wait(int n)
        {
            Thread.Sleep(n * 1000);
        }
        // 콘솔 딜레이

        static void Run()
        {
            Console.Clear();

            switch (data.place)
            {
                case Place.name:
                    Name();
                    break;
                case Place.choice:
                    Choice();
                    break;
                case Place.town:
                    Town();
                    break;
                case Place.home:
                    Home();
                    break;
                case Place.training:
                    TrainingRoom();
                    break;
                case Place.forest:
                    Forest();
                    break;
            }
        }
        // 진행함수

        static void Name()
        {
            Console.Clear();
            Console.Write("이름을 입력하세요 : ");
            data.character.name = Console.ReadLine();

            Console.WriteLine($"당신의 이름은 {data.character.name}입니다");
            Console.WriteLine("확정 하시겠습니까? : (y or n)");
            string confirmName = Console.ReadLine();

            if (confirmName == "y")
            { data.place = Place.choice; }
            else if (confirmName == "n")
            { return; }
            else
            {
                Console.WriteLine("잘못된 값을 입력하였습니다. 다시 입력해주세요.");
                Wait(1);
                return;
            }
        }
        // 이름 작성 화면

        static void Choice()
        {
            Console.Clear();
            Console.WriteLine("당신의 직업을 선택하세요");
            Console.WriteLine("1. 전사(Warrior) \\ 2. 궁수(Archer) \\ 3. 마법사(Mage) \\ 4. 도적(Rogue) \\ 5. 해적(Pirate)");
            Enum.TryParse(Console.ReadLine(), out data.job);
            bool jobCheck = Enum.IsDefined(data.job);

            if (jobCheck == true)
            {

                switch (data.job)
                {
                    #region 직업 설정 
                    case Job.warrior:
                        data.job = Job.warrior;
                        data.maxhp = 200;
                        data.maxmp = 50;
                        data.character.hp = 200;
                        data.character.mp = 50;
                        data.character.str = 15;
                        data.character.dex = 10;
                        data.character.intel = 0;
                        data.character.luk = 5;
                        break;
                    case Job.archer:
                        data.job = Job.archer;
                        data.maxhp = 100;
                        data.maxmp = 80;
                        data.character.hp = 100;
                        data.character.mp = 80;
                        data.character.str = 8;
                        data.character.dex = 15;
                        data.character.intel = 5;
                        data.character.luk = 10;
                        break;
                    case Job.mage:
                        data.job = Job.mage;
                        data.maxhp = 80;
                        data.maxmp = 150;
                        data.character.hp = 80;
                        data.character.mp = 150;
                        data.character.str = 0;
                        data.character.dex = 5;
                        data.character.intel = 15;
                        data.character.luk = 10;
                        break;
                    case Job.rogue:
                        data.job = Job.rogue;
                        data.maxhp = 120;
                        data.maxmp = 100;
                        data.character.hp = 120;
                        data.character.mp = 100;
                        data.character.str = 8;
                        data.character.dex = 10;
                        data.character.intel = 5;
                        data.character.luk = 15;
                        break;
                    case Job.pirate:
                        data.job = Job.pirate;
                        data.maxhp = 150;
                        data.maxmp = 80;
                        data.character.hp = 150;
                        data.character.mp = 80;
                        data.character.str = 10;
                        data.character.dex = 10;
                        data.character.intel = 8;
                        data.character.luk = 10;
                        break;
                        #endregion
                        // 직업 기본 능력치 설정
                }
            }
            else if (jobCheck == false)
            {
                Console.WriteLine("잘못된 값을 입력하였습니다. 다시 입력해주세요");
                Wait(1);
                return;
            }

            Console.Clear();
            Console.WriteLine($"당신의 직업은 {data.job}입니다\n");
            Stat();
            Console.WriteLine("\n확정 하시겠습니까? : (y or n)");
            string confirmJob = Console.ReadLine();
            if (confirmJob == "y")
            {
                data.place = Place.town;
            }
            else if (confirmJob == "n")
            {
                Console.WriteLine("다시 선택해주세요");
                Wait(1);
                return;
            }
            else
            {
                Console.WriteLine("잘못된 값을 입력하였습니다. 다시 입력해주세요");
                Wait(1);
                return;
            }
        }
        // 직업 선택 화면

        static void Stat()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("======================================================================");
            Console.ResetColor();
            Console.WriteLine($"직업 : {data.job}");
            Console.WriteLine($"체력/최대체력 : {data.character.hp}/{data.maxhp}");
            Console.WriteLine($"마나/최대마나 : {data.character.mp}/{data.maxmp}");
            Console.WriteLine($"힘(STR) : {data.character.str}   민첩(DEX){data.character.dex}");
            Console.WriteLine($"지력(INT) : {data.character.intel}   행운(LUK){data.character.luk}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("======================================================================");
            Console.ResetColor();
        }
        //플레이어 능력치 표시 함수
        static void GetPlace()
        {
            Enum.TryParse(Console.ReadLine(), out data.place);
        }
        //이동할 장소 선택 명령어

        static void Town()
        {
            Stat();
            Console.WriteLine("마을 광장으로 향합니다");
            Wait(1);
            Console.WriteLine("어디로 가시겠습니까?");
            Wait(1);
            Console.WriteLine("1. 집(home) \\ 2. 훈련장(trainingroom) \\ 3. 숲(forest)");
            GetPlace();
        }
        // 마을

        static void Home()
        {
            Console.Clear();
            Console.WriteLine("집에 왔습니다.");
            Wait(1);
            if (data.character.hp == data.maxhp)
            {
                Console.Write("휴식을 취");
                Wait(1);
                Console.WriteLine("...하려고 했으나 어머니가 엄살 좀 피우지 말라며 등짝을 때리고 쫓아냅니다");
                Wait(1);
                Console.WriteLine("체력이 감소합니다");
                data.character.hp -= 5;
                Console.WriteLine($"현재체력 : {data.character.hp}");
                Wait(2);
                data.place = Place.town;
            }
            else
            {
                Console.WriteLine("휴식을 취합니다");
                Wait(1);
                Console.Write("z");
                Wait(1);
                Console.Write("z");
                Wait(1);
                Console.WriteLine("Z");
                Wait(2);

                Console.WriteLine("체력과 마나를 모두 회복했습니다!");
                data.character.hp = data.maxhp;
                data.character.mp = data.maxmp;
                Console.WriteLine($"현재체력 : {data.character.hp}");
                Wait(2);
                data.place = Place.town;
            }
        }
        // 회복할 수 있는 장소 '집'
        // 될 수 있다면 확률에 따라 회복되는 양이 다르게 설정하고 싶음.
        // 이스터에그 적인 요소로 엄마에게 데미지를 입는 장난스러운 장면을 넣고 싶었음.
        // 등짝을 맞아 죽게 될 시 기존의 사망 화면과 다른 화면을 비추고 싶음.

        static void TrainingRoom()
        {
            Console.Clear();
            Console.WriteLine("훈련장에 도착했습니다. 진행할 훈련을 선택해주세요");
            Console.WriteLine("====================================================================");
            Console.WriteLine("1. 근력운동 \\ 2. 정신수양 \\ 3. 유산소운동 \\ 4. 네잎클로버 찾기");
            Console.WriteLine("====================================================================");

            Enum.TryParse(Console.ReadLine(), out Training training);
            if (data.character.hp > 20)
            {
                switch (training)
                {
                    case Training.strength:
                        Console.WriteLine("근력운동을 시작합니다");
                        Wait(1);
                        Console.WriteLine("힘이 1 증가합니다");
                        Wait(1);
                        data.character.str += 1;
                        Console.WriteLine($"str : {data.character.str}");
                        Wait(1);
                        Console.WriteLine("힘들어 죽을 것 같습니다");
                        Wait(1);
                        Console.WriteLine("체력이 20 감소합니다");
                        data.character.hp -= 20;
                        Wait(1);
                        Console.WriteLine($"hp : {data.character.hp}");
                        Wait(1);
                        break;
                    case Training.mental:
                        Console.WriteLine("정신수양을 시작합니다");
                        Wait(1);
                        Console.WriteLine("지력이 1 증가합니다");
                        Wait(1);
                        data.character.intel += 1;
                        Console.WriteLine($"int : {data.character.intel}");
                        Wait(1);
                        Console.WriteLine("지루해 죽을 것 같습니다");
                        Wait(1);
                        Console.WriteLine("체력이 20 감소합니다");
                        data.character.hp -= 20;
                        Wait(1);
                        Console.WriteLine($"hp : {data.character.hp}");
                        Wait(1);
                        break;
                    case Training.cardio:
                        Console.WriteLine("유산소운동을 시작합니다");
                        Wait(1);
                        Console.WriteLine("민첩이 1 증가합니다");
                        Wait(1);
                        data.character.dex += 1;
                        Console.WriteLine($"dex : {data.character.dex}");
                        Wait(1);
                        Console.WriteLine("힘들어 죽을 것 같습니다");
                        Wait(1);
                        Console.WriteLine("체력이 20 감소합니다");
                        data.character.hp -= 20;
                        Wait(1);
                        Console.WriteLine($"hp : {data.character.hp}");
                        Wait(1);
                        break;
                    case Training.find:
                        Console.WriteLine("네잎클로버 찾기를 시작합니다");
                        Wait(1);
                        Console.WriteLine("행운이 1 증가합니다");
                        Wait(1);
                        data.character.luk += 1;
                        Console.WriteLine($"luk : {data.character.luk}");
                        Wait(1);
                        Console.WriteLine("찾느라 허리를 숙였더니 허리가 아파 죽을 것 같습니다");
                        Wait(1);
                        Console.WriteLine("체력이 20 감소합니다");
                        data.character.hp -= 20;
                        Wait(1);
                        Console.WriteLine($"hp : {data.character.hp}");
                        Wait(1);
                        break;
                }
            }
            else
            {
                Console.WriteLine("체력이 부족합니다(최소 21이상 필요)");
                Wait(1);
            }
            data.place = Place.town;
            return;
        }
        // 훈련

        static void Forest()
        {
            data.fight = true;
            Random random = new Random();
            data.monsterspawn = random.Next(1, 3);

            if (data.monsterspawn == 1)
            {
                MonSlime();
            }
            else if (data.monsterspawn == 2)
            {
                MonGolem();
            }

            Console.WriteLine("숲으로 향합니다.");
            Wait(1);
            Console.WriteLine($"{data.Monster.name}이 나타났습니다!");

            while (data.fight == true)
            {
                Fight();
                Console.Clear();
            }
            data.place = Place.town;
        }
        // 전투가 일어나는 장소 '숲'
        static void Fight()
        {
            int dmg; // 기본공격
            int skill; // 스킬공격
            Random plusd = new Random(); // 추가 데미지 난수
            int plusdmg = plusd.Next(1, 10);

            Stat();
            if (data.monsterspawn == 1)
            {
                SlimeSpwan();
            }
            else if (data.monsterspawn == 2)
            {
                GolemSpwan();
            }
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"몬스터 체력 : {data.Monster.hp}");
            Console.WriteLine($"몬스터 공격력 : {data.Monster.atk}");
            Console.WriteLine($"몬스터 방어력 : {data.Monster.def}");
            Console.WriteLine("----------------------------------------------------------------------\n");
            Console.WriteLine("어떻게 할까?");
            Console.WriteLine("=================================================================");
            Console.WriteLine("1. 기본 공격한다 \\ 2. 스킬을 사용한다(마나 20 사용) \\ 3. 도망친다");
            Console.WriteLine("=================================================================");

            int.TryParse(Console.ReadLine(), out int behavior);
            switch (behavior)
            {
                case 1:
                    Console.WriteLine($"{data.character.name}은 기본공격을 했다!");
                    Wait(1);

                    if (data.job == Job.warrior)
                    {
                        if(data.character.str <= data.Monster.def)
                        {
                            Console.WriteLine("효과가 없었다!");
                            Wait(1);
                            break;
                        }
                        else 
                        {
                            dmg = data.character.str - data.Monster.def;
                            Console.WriteLine($"{dmg}의 데미지를 입혔다!");
                            Wait(1);
                            data.Monster.hp -= dmg;
                            break;
                        }
                        
                    }
                    else if (data.job == Job.archer)
                    {
                        if (data.character.dex <= data.Monster.def)
                        {
                            Console.WriteLine("효과가 없었다!");
                            Wait(1);
                            break;
                        }
                        else
                        {
                            dmg = data.character.dex - data.Monster.def;
                            Console.WriteLine($"{dmg}의 데미지를 입혔다!");
                            Wait(1);
                            data.Monster.hp -= dmg;
                            break;
                        }
                    }
                    else if (data.job == Job.mage)
                    {
                        if (data.character.str <= data.Monster.def)
                        {
                            Console.WriteLine("효과가 없었다!");
                            Wait(1);
                            break;
                        }
                        else
                        {
                            dmg = data.character.str - data.Monster.def;
                            Console.WriteLine($"{dmg}의 데미지를 입혔다!");
                            Wait(1);
                            data.Monster.hp -= dmg;
                            break;
                        }
                    }
                    else if (data.job == Job.rogue)
                    {
                        if (data.character.luk <= data.Monster.def)
                        {
                            Console.WriteLine("효과가 없었다!");
                            Wait(1);
                            break;
                        }
                        else
                        {
                            dmg = data.character.luk - data.Monster.def;
                            Console.WriteLine($"{dmg}의 데미지를 입혔다!");
                            Wait(1);
                            data.Monster.hp -= dmg;
                            break;
                        }
                    }
                    else if (data.job == Job.pirate)
                    {
                        if (data.character.str <= data.Monster.def)
                        {
                            Console.WriteLine("효과가 없었다!");
                            Wait(1);
                            break;
                        }
                        else
                        {
                            dmg = data.character.str - data.Monster.def;
                            Console.WriteLine($"{dmg}의 데미지를 입혔다!");
                            Wait(1);
                            data.Monster.hp -= dmg;
                            break;
                        }
                    }
                    Wait(2);
                    break;
                // 기본공격 사용
                case 2:
                    Console.WriteLine($"{data.character.name}은 스킬을 사용했다!");
                    Wait(1);
                    data.character.mp -= 20;

                    if (data.job == Job.warrior)
                    {
                        skill = data.character.dex + plusdmg;
                        Console.WriteLine("도깨비 참수!");
                        Console.WriteLine($"{skill}의 데미지를 입혔다!");
                        data.Monster.hp -= skill;
                    }
                    else if (data.job == Job.archer)
                    {
                        skill = data.character.luk + plusdmg;
                        Console.WriteLine("갈래 화살!");
                        Console.WriteLine($"{skill}의 데미지를 입혔다!");
                        data.Monster.hp -= skill;
                    }
                    else if (data.job == Job.mage)
                    {
                        skill = data.character.intel + plusdmg;
                        Console.WriteLine("아브라카다브라!");
                        Console.WriteLine($"{skill}의 데미지를 입혔다!");
                        data.Monster.hp -= skill;
                    }
                    else if (data.job == Job.rogue)
                    {
                        skill = data.character.dex + plusdmg;
                        Console.WriteLine("럭키세븐!");
                        Console.WriteLine($"{skill}의 데미지를 입혔다!");
                        data.Monster.hp -= skill;
                    }
                    else if (data.job == Job.pirate)
                    {
                        skill = data.character.str + plusdmg;
                        Console.WriteLine("기어세컨드!");
                        Console.WriteLine($"{skill}의 데미지를 입혔다!");
                        data.Monster.hp -= skill;
                    }
                    else if (data.character.mp <= 0)
                    {
                        Console.WriteLine("마나가 부족하여 사용할 수 없다");
                        break;
                    }
                    Wait(2);
                    break;
                // 스킬사용 선택
                case 3:
                    Random run = new Random();
                    int runpercent = run.Next(1, 3);

                    if (runpercent == 1)
                    {
                        Console.WriteLine("무사히 도망쳤다!");
                        Wait(1);
                        data.place = Place.town;
                        data.fight = false;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("도망치지 못했다!");
                        Wait(1);
                        break;
                    }
                    // 도망
            }
            // 플레이어 입력값에 따른 결과 도출
            if (data.Monster.hp <= 0)
            {
                Console.WriteLine($"{data.Monster.name}가 쓰러졌다");
                Wait(2);
                data.fight = false;
                return;
            }
            // 몬스터 사망
            Console.WriteLine($"\n{data.Monster.name}이 공격했다!");
            Wait(1);
            Console.WriteLine($"{data.Monster.atk}의 데미지를 받았다!");
            Wait(1);
            data.character.hp -= data.Monster.atk;

            if (data.character.hp <= 0)
            {
                Die();
            }
            // 플레이어 사망
        }
    }
}


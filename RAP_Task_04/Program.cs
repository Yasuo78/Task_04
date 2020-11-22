using System;

namespace RAP_Task_04
{
    class Program
    {
        static Random rand = new Random();
        static int MonHP = rand.Next(250, 501);
        static int PlayHP = rand.Next(80, 101);
        static int mhp = MonHP;
        static int pHP = PlayHP;
        static string LastMG;
        static int fire = 1;
        static int Atack = 1;
        static int tox = 0;
        static int heal = 1;
        static int hod = 0;
        static int Burn = 0;
        static int earth = 0;

        static void monsterOut()
        {
            Console.WriteLine(@"                                     <`--._<`--.____________________________ 
                                     ) ,..-) ,..------------------------,-' 
                                   ,','  >','  \\                  ,        
                                 ,','  ,','     \\            ,             
                               ,','  ,','        \\       ,                 
                             ,' /  ,' /           \\  ,                     
                            /  /  /  /             \`<                      
                           /  /,-/  /,--------------\/                      
                          /__'--/  (/--.                                    
          .-.     ____, '<.  / '   '   '----.                               
         ( . `. ,'    \  '     .-------.  ` '--,                            Ваши заклинания:
          \_) ,'  (_.  \      /         `-----<\                            'Огонь'
          \'   ,'', `.  \   ,'   ,  '          `\                           'Вода'
         _/ _/',O)>   )  )_            ,'        >                          'Воздух'
     \  (o /o) \` )  /  /'\`   `------<___   ,   )                          'Земля'
      \`-)| (/`,)\`-'  /   `.          /   >-'    \                         'Яд'
       `-VvvV ,/( `---'\     `       ,'   /`.      )                        
           / ,/\    \   `.    `          ' ,'`.   '\                        
         (^^(/`      \    `--<, ` --------' ,' `.   )                       
          ``` ________>  ,'   `-')  `      /     \  |                       
     ,-------'        `  )   .--'     ,   /       \  |_                     
   ,'/ _,--,--,,,-,______>   )     \,    (_.-.     \   ),---.               
  / ,\ )                   ,'     ,'          \ .--.\,  .__, \-.            
 /_/ /\)                  /      /             / )-.    /--`--) \           
( )\ ) `                 .      /             (-'   `--'      `--)          
 \' \'                  ,      .                 )                          
                        ,     ,                ,'                           
                         `.  .               ,'`.                           
                        ,',` |              /-.  `.                         
                       ( (   |              \  \   `._                      
                        \ \  /             \    \     \.                    
                         \ \  /          ,\`-.   \  ,'  )                   
                          \ \  /`--,--,-')   /    \'   /                    
                           \ `---------,'   /-.    \\,'                     
                            `--------,'    /-. \                            
                                    /     /   ) )             
                                   (      > ,/ (_                           
                                  /`-,---'\ |, ,'                           
                                  `-^-----' |,'");

        }

        static void monsterAtack()
        {
            int a = rand.Next(1, 11);
            int Dem;
            Console.WriteLine("=======================================================================================================================");
            if (hod < 0)
            {
                hod++;
                Console.WriteLine("Дракон заморожен!");
            }
            else
            {
                if (a == 1)
                {
                    Dem = rand.Next(10, 16);
                    Console.WriteLine($"Дракон дышет огнём: -{Dem * fire}HP");
                    PlayHP = PlayHP - Dem * fire;
                    fire = 1;
                }
                else if ((a > 1) && (a < 5))
                {
                    Dem = rand.Next(10, 16);
                    Console.WriteLine($"Дракон вылизывает свои раны: +{Dem * heal}HP");
                    MonHP = MonHP + Dem * heal;
                    heal = 1;
                }
                else
                {
                    Dem = rand.Next(5, 16);
                    Console.WriteLine($"Дракон атакует когтями: -{Dem * Atack}HP");
                    PlayHP = PlayHP - Dem * Atack;
                    Atack = 1;
                }
            }

            if (tox > 0)
            {
                Dem = rand.Next(5, 11);
                Console.WriteLine($"Дракон получает урон от яда: -{Dem}HP");
                MonHP = MonHP - Dem;
                tox = tox - 1;
            }
            if (Burn > 0)
            {
                Dem = rand.Next(5, 11);
                Console.WriteLine($"Дракон получает урон от огня: -{Dem}HP");
                MonHP = MonHP - Dem;
                Burn = Burn - 1;
            }

            Console.WriteLine("=======================================================================================================================");


        }

        static void HP()
        {
            Console.Write($"Игрок: {PlayHP}/{pHP}HP\tДракон: {MonHP}/{mhp}\n");
        }

        static void Magic()
        {
            string mag;

            Console.Write("Выбирите стихию вашего заклинания: ");
            mag = Console.ReadLine();
            int Dem;

            Console.WriteLine("=======================================================================================================================");
            if (mag == "Огонь")
            {
                if (LastMG == "Яд")
                {
                    Dem = rand.Next(40, 61);
                    Console.WriteLine($"Яд в жилах дракона взрывается: -{Dem}HP");
                    MonHP = MonHP - Dem;
                    tox = 0;
                    mag = "";
                }
                else if (LastMG == "Вода")
                {
                    Dem = rand.Next(10, 16);
                    Console.WriteLine($"Вода на чишуе дракона вскипает и испаряется: -{Dem}HP");
                    Console.WriteLine($"Дракон не может атаковать");
                    MonHP = MonHP - Dem;
                    mag = "";
                    Atack = 0;
                    Burn = 0;
                    fire = 0;
                }
                else
                {
                    Burn = Burn + 3;
                    tox = 0;
                    Dem = rand.Next(20, 31);
                    Console.WriteLine($"Вы поджигаете дракона, иронично... -{Dem}HP");
                    MonHP = MonHP - Dem;
                }
            }
            else if (mag == "Вода")
            {
                if (LastMG == "Яд")
                {
                    Dem = rand.Next(15, 21);
                    Console.WriteLine($"Яд в жилах дракона взрывается: -{Dem}HP");
                    MonHP = MonHP - Dem;
                    mag = "";
                    fire = 0;
                    tox = 0;
                }
                else if (LastMG == "Огонь")
                {
                    Dem = rand.Next(10, 16);
                    Console.WriteLine($"Вода на чишуе дракона вскипает и испаряется: -{Dem}HP");
                    Console.WriteLine($"Дракон не может атаковать");
                    MonHP = MonHP - Dem;
                    mag = "";
                    Atack = 0;
                    fire = 0;
                    Burn = 0;
                }
                else
                {
                    Dem = rand.Next(15, 21);
                    Burn = 0;
                    fire = 0;
                    Console.WriteLine($"Вы заливаете дракона водой:-{ Dem}");
                    MonHP = MonHP - Dem;
                }
            }
            else if (mag == "Воздух")
            {
                if ((LastMG == "Вода") && (hod == 0))
                {
                    Dem = rand.Next(25, 36);
                    Console.WriteLine($"Вода на чешуе дракона замерзает: -{Dem}HP");
                    MonHP = MonHP - Dem;
                    mag = "";
                    Burn = 0;
                    if (hod == 0) hod = -4;
                }
                else if (LastMG == "Огонь")
                {
                    Dem = rand.Next(40, 51);
                    Console.WriteLine($"Огонь на чишуе дракона раздувается: -{Dem}HP");
                    MonHP = MonHP - Dem;
                    mag = "";
                    Burn = Burn + 2;
                }
                else
                {
                    Dem = rand.Next(15, 21);
                    Console.WriteLine($"Вы сносите дракона потоком ветра: -{Dem}");
                    MonHP = MonHP - Dem;
                }
            }
            else if (mag == "Земля")
            {
                if (earth == 0)
                {
                    Dem = rand.Next(20, 31);
                    Console.WriteLine($"Вы залечиваете свои раны силой земли: +{Dem}HP");
                    PlayHP = PlayHP + Dem;
                    earth = 3;
                }
                else Console.WriteLine("Заклинание недоступно!");
            }
            else if (mag == "Яд")
            {
                if (LastMG == "Огонь")
                {
                    Dem = rand.Next(40, 61);
                    Console.WriteLine($"Яд в жилах дракона взрывается: -{Dem}HP");
                    MonHP = MonHP - Dem;
                    tox = 0;
                    mag = "";
                }
                else
                {
                    tox = 3;
                    Dem = rand.Next(20, 31);
                    Console.WriteLine($"Вы отравляете дракона: -{Dem}");
                    MonHP = MonHP - Dem;
                }
            }
            else Console.WriteLine("Вы пропускаете ход");

            LastMG = mag;
            if (earth > 0) earth = earth - 1;
            Console.WriteLine("=======================================================================================================================");

        }

        static void Main(string[] args)
        {
            Console.WindowWidth = 120;
            Console.WindowHeight = 40;
        Start:
                   Console.WriteLine(@"  ____    ___  ____   _____ __ __  ____  ____       ____  ___ ___  ____   ____    __ ______ 
 /    |  /  _]|    \ / ___/|  |  ||    ||    \     |    ||   |   ||    \ /    |  /  ]      |
|   __| /  [_ |  _  (   \_ |  |  | |  | |  _  |     |  | | _   _ ||  o  )  o  | /  /|      |
|  |  ||    _]|  |  |\__  ||  _  | |  | |  |  |     |  | |  \_/  ||   _/|     |/  / |_|  |_|
|  |_ ||   [_ |  |  |/  \ ||  |  | |  | |  |  |     |  | |   |   ||  |  |  _  /   \_  |  |  
|     ||     ||  |  |\    ||  |  | |  | |  |  |     |  | |   |   ||  |  |  |  \     | |  |  
|___,_||_____||__|__| \___||__|__||____||__|__|    |____||___|___||__|  |__|__|\____| |__|  
                                                                                            ");
            Console.WriteLine('\n');
            Console.WriteLine("Нажмите Enter чтобы начать");
            ConsoleKeyInfo K;
            K = Console.ReadKey(true);

            if (K.Key != ConsoleKey.Enter) goto Start;

            do
            {
                Console.Clear();
                HP();
                monsterOut();
                Magic();
                monsterAtack();
                Console.ReadKey();

            } while ((MonHP > 0) && (PlayHP > 0));

            Console.Clear();

            if (PlayHP < 0)
            {
                Console.WriteLine(@"  ██████╗ ███████╗███████╗██╗████████╗
██╔══██╗██╔════╝██╔════╝██║╚══██╔══╝
██║  ██║█████╗  █████╗  ██║   ██║   
██║  ██║██╔══╝  ██╔══╝  ██║   ██║   
██████╔╝███████╗██║     ██║   ██║   
╚═════╝ ╚══════╝╚═╝     ╚═╝   ╚═╝   
                                  ");

            }
            else Console.WriteLine(@"  ██╗   ██╗██╗ ██████╗████████╗ ██████╗ ██████╗ ██╗   ██╗
██║   ██║██║██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗╚██╗ ██╔╝
██║   ██║██║██║        ██║   ██║   ██║██████╔╝ ╚████╔╝ 
╚██╗ ██╔╝██║██║        ██║   ██║   ██║██╔══██╗  ╚██╔╝  
 ╚████╔╝ ██║╚██████╗   ██║   ╚██████╔╝██║  ██║   ██║   
  ╚═══╝  ╚═╝ ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝   
                                                       ");
        }
    }
}
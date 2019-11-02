using System;

namespace csharp_trial {
    class Character
    {
        public static int number;
        public string firstName;
        public string lastName;
        public int age;

        static Character() { Console.WriteLine("<キャラクター一覧>"); }

        public Character() : this("firstName", "lastName", 0) { }

        public Character(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public void ShowProfile()
        {
            Console.WriteLine($"No{++number}: {this.firstName} {this.lastName} ({this.age})");
        }

        public int AfterAnyYears(int year)
        {
            return this.age += year;
        }

        public void Chat(string greeting = "こんにちは", string talking = "調子はどう？")
        {
            Console.WriteLine($"\n{greeting}{this.firstName} {talking}");
        }

        public static void AddList(List<Character> list, params Character[] charaList)
        {
            foreach (var chara in charaList)
            {
                list.Add(chara);
            }
        }
    }

    class Trial3
    {
        static void Main(string[] args)
        {
            var characterList = new List<Character> { };

            var noNmae = new Character();

            var porco = new Character();
            porco.firstName = "Porco";
            porco.lastName = "Rosso";
            porco.age = 36;

            var umi = new Character() { firstName = "海", lastName = "小松崎 ", age = 16 };

            var Sophie = new Character("Sophie", "Hatter", 18);
            Sophie.age = Sophie.AfterAnyYears(80);
            Sophie.AfterAnyYears(-78);

            Character.AddList(characterList, noNmae, porco, umi, Sophie);

            foreach (var chara in characterList)
            {
                chara.ShowProfile();
            }

            umi.Chat();
            porco.Chat("おはよう", "今月の稼ぎはいくら？");
            porco.Chat(talking: "君はいつまで飛び続けるんだい？", greeting: "");

        }
    }
}


using System;

namespace csharp_trial {
    class Character
    {
        public static int number;
        public string title;
        public string firstName;
        public string lastName;
        public int age;

        // 静的コンストラクター
        static Character() { Console.WriteLine("<キャラクター一覧>"); }

        // コンストラクター(thisで規定値を設定)
        public Character() : this("title", "firstName", "lastName", -1) { }

        // コンストラクターのオーバーロード
        public Character(string title, string firstName, string lastName, int age)
        {
            this.title = title;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public void ShowProfile(Character chara)
        {
            if (chara.age == -1)
            {
                Console.WriteLine($"No{++number}: {this.title}\n{this.firstName} {this.lastName}");
            }
            else
            {
                Console.WriteLine($"No{++number}: {this.title}\n{this.firstName} {this.lastName} ({this.age})");
            }

        }

        // 戻り値がint型
        public int AfterAnyYears(int year)
        {
            return this.age += year;
        }

        // 規定値の存在するメソッド
        public void Chat(string greeting = "こんにちは", string talking = "調子はどう？")
        {
            Console.WriteLine($"\n{greeting}{this.firstName} {talking}");
        }

        // 戻り値の参照渡し
        public ref string EditTitleRef(Character chara)
        {
            return ref chara.title;
        }

        // 出力引数
        public void ChangeName(String newFirstName, string newLastName,
            out string oldFirstName, out string oldLastName)
        {
            oldFirstName = newFirstName;
            oldLastName = newLastName;
        }

        // タプル
        public (string name, int age) GetAge(Character chara)
        {
            return (chara.firstName + " " + chara.lastName, chara.age);
        }

        // staticメソッド
        public static void AddList(List<Character> list, params Character[] charaList)
        {
            foreach (var chara in charaList)
            {
                list.Add(chara);
            }
        }

        public IEnumerable<string> GetTitleList(List<Character> list)
        {
            foreach (var chara in list)
            {
                yield return chara.title;
            }
        }
    }

    class Trial3
    {
        static void Main(string[] args)
        {
            var characterList = new List<Character> { };
            string[] title = new string[22];
            title[7] = "紅の豚";
            title[9] = "耳をすませば";
            title[12] = "千と千尋の神隠し";
            title[13] = "猫の恩返し";
            title[14] = "ハウルの動く城";
            title[18] = "コクリコ坂から";

            var noName = new Character();
            ref string noNmaesTitle = ref noName.EditTitleRef(noName);
            noNmaesTitle = "タイトル";

            var porco = new Character();
            porco.title = title[7];
            porco.firstName = "Porco";
            porco.lastName = "Rosso";

            var umi = new Character() { title = title[18], firstName = "海", lastName = "小松崎" };

            var sophie = new Character(title[14], "Sophie", "Hatter", 18);
            sophie.age = sophie.AfterAnyYears(80);
            sophie.AfterAnyYears(-78);
            var sophiesAge = sophie.GetAge(sophie);

            var chihiro = new Character(title[12], "千尋", "荻野", 12);
            chihiro.ChangeName("千", "", out chihiro.firstName, out chihiro.lastName);

            // 匿名型
            var kaonashi = new { chihiro.title, name = "かおなし" };

            Character.AddList(characterList, noName, porco, umi, chihiro);

            foreach (var chara in characterList)
            {
                chara.ShowProfile(chara);
            }

            Character.number++;
            Console.WriteLine("No" + Character.number.ToString() + ":" + kaonashi.title + "\n" + kaonashi.name);

            Character.number++;
            Console.WriteLine("No" + Character.number.ToString() + ":" + sophie.title + "\n" + sophiesAge.name + " (" + sophiesAge.age + ")");

            foreach (var chara in noName.GetTitleList(characterList))
            {
                Console.Write(chara + " ");
            }
            Console.WriteLine();

            umi.Chat();
            porco.Chat("おはよう", "今月の稼ぎはいくら？");
            porco.Chat(talking: "君はいつまで飛び続けるんだい？", greeting: "");

        }
    }
}


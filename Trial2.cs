using System;
using System.IO;

namespace csharp_trial
{
    public class Trial2
    {
        public Trial2()
        {
            Console.Write("ファイル名を入力してください");
            String inputPath = Console.ReadLine();
            String fullPath = System.IO.Path.GetFullPath(inputPath);


            // StreamWriterクラス
            // ファイル書き込み
            using(var writer = new StreamWriter(@fullPath)){
                writer.WriteLine("Test")
            }
            
            // ファイル上書き
            using(var editWriter = new StreamWriter(@fullPath, append: true)){
                editWriter.Write("\r\n" + "Test")
            }

            // ファイルを読み込み
            using(var reader = new StreamReader(@fullPath)){
                // まとめて読み込む
                Console.WriteLine(reader.ReadToEnd)

                // 1行ずつ読み込む
                while (!reader.EndOfStream){
                    Console.WriteLine(reader.ReadLine)
                }
            }
            /*---------------
            
            FinleInfoクラス
            
            --------------- */
            
            var file = new FileInfo(@inputPath);

            // ファイルが存在するか
            Console.WiterLine(file.Exits);

            // ファイル名を取得
            Console.WriteLine(finle.Name);

            // フォルダー名を取得
            Console.WriteLine(file.DirectoryName);

            // ファイルをコピー(既に同名ファイルが存在する場合上書き)
            var copyFile = file.copyTo(@fullPath, true);
            
            // ファイルを移動・変更
            copyFile.MoveTo(fullPath);
            
            // ファイルを削除
            copyFile.Delete();

            /*---------------
            
            dilectoryInfoクラス
            
            --------------- */
            // なんか、フォルダ名だけ切り取る処理
            String currenrDilectory = subString(fullPath);
            var dilectory = new dilectoryInfo(@currenrDilectory);

            // フォルダーが存在するか
            Console.WiterLine(dilectory.Exits);

            // フォルダーの親フォルダー名を取得
            Console.WriteLine(dilectory.Parent);

            // フォルダーのルートを取得
            Console.WriteLine(dilectory.Root);

            // サブフォルダーの一覧を取得
            var subDilectory = dilectory.GetDilectorys();
            foreach (var dir in subDilectory){
                Console.WiterLine(dir.FullName);
            }
            
            // フォルダー作成
            var madeDilectory = new dilectoryInfo(@currenrDilectory);
            madeDilectory.Create();

            // サブフォルダーの作成
            madeDilectory.CreateSubdilectory("サブフォルダー");

            // ファイルを移動・変更
            madeDilectory.MoveTo(@currenrDilectory);
            
            // ファイルを削除
            madeDilectory.Delete();
        }
    }
}
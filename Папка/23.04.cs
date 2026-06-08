namespace Lab10
{
    public class Program
    {
        public static void Main()
        {
            string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //Console.Write(folderpath);

            string filename = "Normal.txt";
            string filePath = Path.Combine(folderpath, filename);

            //Console.WriteLine(filePath);

            File.Create(filePath).Close();
            File.WriteAllText(filePath, "wasup" + Environment.NewLine);

            File.AppendAllText(filePath, "7 minuets is all i can spare to play with you");


            string[] words = new[] { "hello", "hi", "sddyy" };
            File.WriteAllLines(filePath, words);

            string contaiment = File.ReadAllText(filePath);
            //Console.WriteLine(contaiment);

            string[] lines = File.ReadAllLines(filePath);

            foreach(string line in lines )
            {
                //Console.WriteLine(line);
            }

            string folderPath2 = Path.Combine(folderpath, "ExampleFolder");
            string filePath3 = Path.Combine(folderPath2, "NewExampleFolder");

            if (Directory.Exists(folderPath2))
            {
                Directory.CreateDirectory(folderPath2);
            }
            if (!File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                File.WriteAllText(filePath, "");
            }
        }
    }
}

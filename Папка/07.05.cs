using System.Xml.Serialization;

namespace _07._05.practic
{
    public class Program
    {
        public class Human
        {
            private string _name;
            private int _age;
            private int[] _review;
            public int[] Review => _review.ToArray();
            public string Name => _name;
            public int Age => _age;
            public Human(string name, int age)
            {
                _review = new int[0];
                _name = name;
                _age = age;
            }

            public void AddReview(int stars)
            {
                Array.Resize(ref _review, _review.Length + 1);
                _review[_review.Length - 1] = stars;
            }
        }
        
        public class HumanDTO
        {
            //Свойства с публичными сетерами
            public string HumanType {  get; set; }
            public string Name {  get; set; }
            public int[] Reviw {  get; set; }
            public int Age { get; set; }

            //Конструктор без параметров
            public HumanDTO() 
            { 
            
            }
            // Human -> HumanDTO
            public HumanDTO(string name, int age, int[] review)
            {
                HumanType = nameof(Human);
                Name = name;
                Age = age;
                Reviw = review;
            }

            public HumanDTO(Human human)
            {
                HumanType = human.GetType().Name;
                Name = human.Name;
                Age = human.Age;
                Reviw = human.Review;
            }
        }
        static void Main(string[] args)
        {


            Human human = new Human("nikita", 67);
            human.AddReview(5);
            human.AddReview(3);
            HumanDTO humanDTO = new HumanDTO(human);
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(folderPath, "human.xml");

            var serializer = new XmlSerializer(typeof(HumanDTO));
            //Сериализатор
            using(var otherH = new StreamWriter(filePath))
            {
                serializer.Serialize(otherH, humanDTO);
            }
            //Десериализатор
            HumanDTO humanDTO2;
            using(var reader = new StreamReader(filePath))
            {
                humanDTO2 = (HumanDTO)serializer.Deserialize(reader);
            }

            //Получение изначального объекта
            Human human2 = new Human(humanDTO2.Name, humanDTO2.Age);

            foreach (int star in humanDTO2.Reviw)
            {
                human2.AddReview(star);
            }

            if (CompareHumans(human, human2))
            {
                Console.WriteLine("Sucсess");
            }
            else
            {
                Console.WriteLine("Unsuссess");
            }
        }
        public static bool CompareHumans(Human h1, Human h2)
        {
            if (h1.Name == h2.Name && h1.Age == h2.Age )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


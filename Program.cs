// Написать программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых меньше, 
// либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. 
// При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.
using System.Text.RegularExpressions;
Console.Clear();

System.Console.Write($"Хотите рандомный массив? (y/n) ");
string answer = System.Console.ReadLine();
string[] random_array;

switch (answer) 
{
    case "y":
        System.Console.Write($"Введите длину массива: ");
        int arr_size = int.Parse(System.Console.ReadLine());

        random_array = RandomStringArray(array_size: arr_size);
        BeautifullyPrintArray(random_array);
        break;

    case "n":
        System.Console.Write($"Введите массив через пробел: ");
        random_array =  GetArrayFromString(System.Console.ReadLine());
        BeautifullyPrintArray(random_array);
        break;

    default:
        System.Console.WriteLine("Вы ввели не \"y\", и не \"n\", когда вас спрашивали про рандомность массива, поэтому был создан рандомный массив случайной длины в качестве утешительного приза.");
        random_array = RandomStringArray(array_size: new Random().Next(1, 20));
        BeautifullyPrintArray(random_array);
        break;
}

string[] resultArray = GetNewStringArray(array: random_array, max_item_size: 3);
BeautifullyPrintArray(resultArray, prefix: "Ваш новый массив:");

string[] RandomStringArray(int array_size = 5, int max_item_size = 10) {
    // сгенерировать массив случайных строк длиной до max_item_size
    string[] result = new string[array_size];
    var random = new Random();

    for (int i = 0; i < array_size; i++) {
        result[i] = GetRandomString(random.Next(1, max_item_size + 1));
    }
    return result;
}

string GetRandomString(int size = 10) {
    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-";
    string result = "";
    var random = new Random();

    for (int i = 0; i < size; i++) {
        result += chars[random.Next(chars.Length)];
    }    
    return result;
}


string[] GetArrayFromString(string text) {
    return Regex.Replace(text.Trim(), "  +", " ").Split();
}


void BeautifullyPrintArray(string[] array, string prefix = "Ваш массив:") {
    // красиво вывести массив
    System.Console.WriteLine($"{prefix} [{String.Join(", ", array)}]");
}


string[] GetNewStringArray(string[] array, int max_item_size = 3) {
    // получить массив строк, где каждый элемент массива будет длиной не более max_item_size
    string result = "";
    foreach (string item in array)
    {
        if (item.Length <= max_item_size) result += item + " ";
    }
    return result.Trim().Split();
}

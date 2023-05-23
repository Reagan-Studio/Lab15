using Lab15;

//номер2---------------------------------------------------------------------------------------------------
LinearProbingHashTable hashTable = new LinearProbingHashTable(10);

string input = "EASYQUTION";
foreach (char c in input)
{
    int asciiCode = (int)c;
    hashTable.Add(asciiCode, c.ToString());
}

hashTable.Display();




////номер1--------------------------------------------------------------------------------------------------
//Map<char, string> map = new Map<char, string>(5);

//string input = "EASYQUTION";
//foreach (char c in input)
//{
//    int asciiCode = (int)c;
//    int hashCode = 11 * asciiCode % M;
//    map.Add(c, c.ToString());
//}

//map.Display();

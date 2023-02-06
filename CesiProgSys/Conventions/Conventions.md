```csharp
var variableTest = 12;
bool boolTest = True;
```

```csharp
public class ClasseTest
{
....
}
```
```csharp
public struct StructureTest
{
....
}
```
````csharp
public record RecordTest(
string TestUn,
string TestDeux,
....);
````
````csharp
public interface IInterfaceTest
{
....
}
````
```csharp
public class ClasseTest
{
public bool BoolTest;
public int IntTest;
```

````csharp
public void MethodTest()
{
....
}
}
````

````csharp
public class ClasseTest
{
internal bool _boolTest;
private int _intTest;

private void _methodTest()
{
....
}
`````

````csharp
public class ClasseTest
{
private static int s_intTest;

[ThreadStatic]
private static bool t_boolTest;
}
````


````csharp
public class ClasseTest
{
public int MethodeTest<int>(int intTest, bool boolTest)
{
....
}
}
````

````csharp
string displayName = $"{nameList[n].LastName}, {nameList[n].FirstName}";
````

````csharp
var phrase = "lalalalalalalalalalalalalalalalalalalalalalalalalalalalalala";
var manyPhrases = new StringBuilder();
for (var i = 0; i < 10000; i++)
{
manyPhrases.Append(phrase);
}
````
````csharp
var var1 = "This is clearly a string.";
var var2 = 27;
````
````csharp
int var3 = Convert.ToInt32(Console.ReadLine());
int var4 = ExampleClass.ResultSoFar();
````

````csharp
string[] vowels1 = { "a", "e", "i", "o", "u" };
var vowels2 = new string[] { "a", "e", "i", "o", "u" };
````




````csharp
var instance1 = new ExampleClass();
ExampleClass instance2 = new();
ExampleClass instance2 = new ExampleClass();
````


````csharp
var instance3 = new ExampleClass { Name = "Desktop", ID = 37414, Location = "Redmond", Age = 2.3 };
````


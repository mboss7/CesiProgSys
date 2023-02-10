Naming Convention:

Variables:

```csharp
var variableTest = 12;
bool boolTest = True;
```
Classes:
```csharp
public class ClasseTest
{
....
}
```
Structures:
```csharp
public struct StructureTest
{
....
}
```
Records:
````csharp
public record RecordTest(
string TestUn,
string TestDeux,
....);
````
Interfaces:
````csharp
public interface IInterfaceTest
{
....
}
````
Public attributes:
```csharp
public class ClasseTest
{
public bool BoolTest;
public int IntTest;

public void MethodTest()
{
....
}
}
````
Private or internal attributes:
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
Static attributes:
````csharp
public class ClasseTest
{
private static int s_intTest;

[ThreadStatic]
private static bool t_boolTest;
}
````
Methods:

````csharp
public class ClasseTest
{
public int MethodeTest<int>(int intTest, bool boolTest)
{
....
}
}
````
Comment conventions:
Place the comment on a separate line, not at the end of a code line.
Start the comment with a capital letter.
End the comment text with a period.
Insert a space between the comment delimiter (//) and the comment text.
Do not create formatted asterisk blocks around comments.
Typing conventions:
Use string interpolation to concatenate short strings.
````csharp
string displayName = $"{nameList[n].LastName}, {nameList[n].FirstName}";
````
For adding strings in loops, particularly when using large amounts of text, use a StringBuilder object.

````csharp
var phrase = "lalalalalalalalalalalalalalalalalalalalalalalalalalalalalala";
var manyPhrases = new StringBuilder();
for (var i = 0; i < 10000; i++)
{
manyPhrases.Append(phrase);
}
````
Use implicit typing for local variables when the type of the variable is obvious from the right side of the assignment or when the precise type doesn't matter.
````csharp
var var1 = "This is clearly a string.";
var var2 = 27;
````
Do not use var when the type is not obvious from the right side of the assignment. Do not assume the type is clear from a method name. A variable type is considered clear if it is an explicit cast or a new operator.
````csharp
int var3 = Convert.ToInt32(Console.ReadLine());
int var4 = ExampleClass.ResultSoFar();
````
Do not rely on the variable name to specify the type of the variable.
In general, use int instead of unsigned types. Using int is common in C# and it's easier to interact with other libraries when using int.
Use concise syntax when initializing arrays on the declaration line.
````csharp
string[] vowels1 = { "a", "e", "i", "o", "u" };
var vowels2 = new string[] { "a", "e", "i", "o", "u" };
````
Miscellaneous conventions:
Use the default code editor parameters.
Write one statement per line.
Write one declaration per line.
Add at least one blank line between method definitions and property definitions.
Use parentheses to make the clauses of an expression more apparent if ((val1 > val2) && (val1 > val3)) { .... }
Use a try-catch statement for most exception handling.
Use one of the concise forms of object instantiation.


````csharp
var instance1 = new ExampleClass();
ExampleClass instance2 = new();
ExampleClass instance2 = new ExampleClass();
````
Use object initializers to simplify object creation.

````csharp
var instance3 = new ExampleClass { Name = "Desktop", ID = 37414, Location = "Redmond", Age = 2.3 };
````
Call static members using the class name: Class_name.Static_member.

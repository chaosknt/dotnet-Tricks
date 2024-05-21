Public class Program 
{

  var method = ReflexionHelper.PrivateMember<Test>("Saludar").Invoke(new Test(), new object[] { "Hola", new Test2() });


  //GENERICS
  var method2 = ReflexionHelper.PrivateMember<Test3>("Saludar");
  var genericMethod = method2.MakeGenericMethod(typeof(int));
  genericMethod.Invoke(new Test3(), new object[] { 44 });
  
}

public static class ReflexionHelper
{
    public static MethodInfo PrivateMember<T>(string name) where T : class
       => typeof(T).GetMethod(name, BindingFlags.NonPublic | BindingFlags.Instance);
}

public class Test
{
    private void Saludar(string s, Test2 t) 
    {

        Console.WriteLine(s);
        t.Saludar(s);
    }
}

public class Test2
{
    public void Saludar(string s)
    {

        Console.WriteLine(s);
    }
}

public class Test3
{
    private void Saludar<T>(T e)
    {
        Console.WriteLine(e);
    }
}

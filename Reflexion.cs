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

/************************************

Cambiar el valor de una propiedad por reflexion

 private CustomerProfile CreateCustomerProfileWithInconsistentState(StateCustomerType? val = StateCustomerType.Inconsistent)
 {
     var customer = _fixture.Create<CustomerProfile>();

     typeof(CustomerProfile).GetProperty(nameof(CustomerProfile.StateCustomerType)).SetValue(customer, val);

     return customer;
 }

 private static void SetValueUsingReflection(object obj, string propertyName, object value)
{
    Type type = obj.GetType();

    PropertyInfo prop = type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

    if (prop != null && prop.CanWrite)
    {
        prop.SetValue(obj, value);
    }
}

Cambiar el valor de una propiedad por reflexion pasando el nombre de la propiedad por parametro


private static void SetPropertyValueNull(object obj, string propertyName, object propVal = null)
{
    PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);

    if (propertyInfo != null)
    {
        propertyInfo.SetValue(obj, propVal);
    }
}

//Obtener el valor de una propiedad cuando el objeto es de tipo Dynamic

private static object GetPropertyValue(object obj, string propertyName)
{
    if (obj is ExpandoObject expandoObj)
    {
        IDictionary<string, object> dictionary = expandoObj;
        if (dictionary.ContainsKey(propertyName))
        {
            return dictionary[propertyName];
        }
        else
        {
            throw new ArgumentException($"La propiedad '{propertyName}' no existe en el objeto ExpandoObject.");
        }
    }

    throw new NotImplementedException();
}

//Obtener el valor de una propiedad cuando el objeto es de tipo Object
 private static object GetPropertyValue(object obj, string propertyName)
 {
     return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
 }

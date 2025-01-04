using System.Reflection;
using Terra.Animais;

var Assembly = typeof (Humano).Assembly;

Console.WriteLine("Assembly: " + Assembly);

Type humanoType = typeof(Humano);

Console.WriteLine("Type: " + humanoType);

var animaisType = Type.GetType("Terra.Animais");

Console.WriteLine("Class: " + animaisType);

object newHuman = Activator.CreateInstance(humanoType)!;

Console.WriteLine("New Human: " + newHuman);

// PropertyInfo[] properties = humanoType.GetProperties();
// foreach (var propertyInfo in properties)
// {
//     Console.WriteLine(propertyInfo.Name);
// }

PropertyInfo propertySet = humanoType.GetProperty("Idade")!;
propertySet!.SetValue(newHuman, 23, null);
// var properties = humanoType.GetProperties();
// foreach (var propertyInfo in properties)
// {
//     Console.WriteLine(propertyInfo.Name + " : " + propertyInfo.GetValue(newHuman));
// }

humanoType.InvokeMember("Respirar", 
            BindingFlags.InvokeMethod | 
            BindingFlags.Public | 
            BindingFlags.Instance, null, newHuman, null);
humanoType.InvokeMember("Piscar", 
            BindingFlags.InvokeMethod | 
            BindingFlags.Public | 
            BindingFlags.Instance, null, newHuman, null);
humanoType.InvokeMember("SentirFome", 
            BindingFlags.InvokeMethod | 
            BindingFlags.Public | 
            BindingFlags.Instance, null, newHuman, null);

humanoType.InvokeMember("CantarNoBanheiro", 
            BindingFlags.InvokeMethod | 
            BindingFlags.Instance | 
            BindingFlags.NonPublic, null, newHuman, null);

humanoType.InvokeMember("PensarAlgo", 
            BindingFlags.InvokeMethod | 
            BindingFlags.Instance | 
            BindingFlags.Public, null, newHuman, ["em viajar", DateTime.Now]);

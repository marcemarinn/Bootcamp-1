**Reglas generales:**
 * Utilice sólo letras, no utilice números.
 * Todo debe ser en inglés.
 * El nombre de la clase, variable o método debe ser descriptivo/a y acorde a lo que está guardando/procesando.
 * Prefiera claridad por sobre brevedad. Evite usar abreviaciones o acrónimos.
 * No ponga el tipo de dato en el nombre de la variable.
```csharp
//Incorrectos
int sum1 = 1 + 1;
var algo = calcularAlgo();
var x = new PersonService();
string nameString = "Fernando";

//Correctos
int sumResult = 1 + 1;
var calculationResult = CalculateSalary();
var personService = new PersonService();
string name = "Fernando";
```

**Use _PascalCase_ para:**
 * Nombres de clases, interfaces, enumeradores, structs, delegados.
 * Propiedades públicas.
 * Métodos.
```csharp
public class UserProfile { }

public interface ICommonService { }

public enum EClientTypes {}

public string UserName { get; set; }

public int CalculateAge(int year){ ... };
```
**Use _camelCase_ para:**
 * Parámetros de métodos.
 * Variables con ámbito de función.
```csharp
public void AddToAccount(string account, decimal amount){ ... }

public List<Branch> GetBranches(){
   var allBranches = _context.Branches.ToList();
   return allBranches;
}
```

**Use _camelCase precedido de guión_ bajo para:**
 * Propiedades privadas.
```csharp
public class UserService {
  private readonly ApplicationDbContext _context;
  private readonly IMapper _mapper;
}
```

**Las interfaces siempre deben empezar con una "i" mayúscula.**
```csharp
public interface ICaseRepository{ }
public interface ICountryService{ }
```

**Los enums siempre deben empezar con una "e" mayúscula.**
```csharp
public enum EClientType{ }
public enum EOperationType{ }
```

**Evite en lo posible utilizar namespaces, prefiera el using.**
```csharp
//Ejemplo
public class Ejemplo {
  public List<Core.Entities.Country> Countries { set; get; }
}

//Mejor
using Core.Entities;

public class Ejemplo {
  public List<Country> Countries { set; get; }
}
```
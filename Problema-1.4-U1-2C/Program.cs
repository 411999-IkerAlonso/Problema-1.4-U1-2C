using Problema_1._4_U1_2C.Implementaciones.Services;
using Problema_1._4_U1_2C.Presentacion.Dominio;

CarreraRepositoryService service = new CarreraRepositoryService();
List<Carrera> carreras = service.GetCarreras();
Carrera carreraId = service.GetCarreraById(4);
Carrera carreraName = service.GetCarreraByName("humanidades");

if (carreras.Count > 0)
{
    foreach (var c in carreras)
    {
        Console.WriteLine(c);
    }
}
else
{
    Console.WriteLine("NO HAY PRODUCTOS");
}

if(carreraId != null)
{
   Console.WriteLine($"Carrera con Id 2: {carreraId}");
}
else
{
    Console.WriteLine("No hay carrera con ese ID"); 
}

if (carreraName != null)
{
    Console.WriteLine(carreraName);
}
else
{
    Console.WriteLine("No hay carrera con ese Nombre");
}

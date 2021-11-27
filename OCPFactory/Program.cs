// See https://aka.ms/new-console-template for more information

using OCPFactory;

Console.WriteLine("OCP DataBse Factory");
Console.WriteLine();

var dbFactory = new DbFactory();

var db = dbFactory.Crea(DbTipo.Sql);
Console.WriteLine($"DbType: {db.TellType()}");

db = dbFactory.Crea(DbTipo.MySql);
Console.WriteLine($"DbType: {db.TellType()}");

try{
  db = dbFactory.Crea(DbTipo.Oracle);
  Console.WriteLine($"DbType: {db.TellType()}");
}
catch (Exception e){
  Console.WriteLine(e.Message);
}

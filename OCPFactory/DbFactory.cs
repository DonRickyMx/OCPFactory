namespace OCPFactory {
  public class DbFactory {
    Dictionary<DbTipo, IDb> _dataBases = new();

    public DbFactory() => SetUp();

    // Es el único lugar donde se modifica para agregar o quitar opciones
    void SetUp() {
      _dataBases.Add(DbTipo.Sql, new SqlDb("Sql_ConnectionString"));
      _dataBases.Add(DbTipo.MySql, new MySqlDb("MySql_ConnectionString"));
    }

    // Factory Abierto y Cerrado.
    public IDb Crea(DbTipo tipo) { 
      if (!ExisteDb(tipo)) throw new InvalidOperationException($"DbTipo invalido {tipo}");
      return _dataBases[tipo];
    }

    bool ExisteDb(DbTipo tipo) => _dataBases.Any(db => db.Key == tipo);
  }

  public enum DbTipo {
    Sql,
    MySql,
    Oracle
  }

  public interface IDb {
    string TellType();
  }

  public class SqlDb : IDb {
    string _connectionString;
    public SqlDb(string connectionString) => _connectionString = connectionString;
    public string TellType() => $"SqlDb, {_connectionString}";
  }

  public class MySqlDb : IDb {
    string _connectionString;
    public MySqlDb(string connectionString) => _connectionString = connectionString;
    public string TellType() => $"MySqlDb, {_connectionString}";
  }
}
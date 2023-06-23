using System;

public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        try
        {
            database.BeginTransaction();
            database.Write(data);
            database.EndTransaction();
        }
        catch (Exception)
        {
            database.Dispose();
            throw;
        }

    }

    public bool WriteSafely(string data)
    {
        try
        {
            Write(data);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

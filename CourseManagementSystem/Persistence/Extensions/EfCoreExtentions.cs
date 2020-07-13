using Microsoft.EntityFrameworkCore;

namespace Persistence.Extensions
{
    public static class EfCoreExtentions
    {
        public static int? Execute_SingleValue_SP_ReturnInt(this DataContext context, string SpName)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = SpName;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        result.Read();
                        var x = result.GetInt32(0); 
                        return x;
                    }
                    return null;
                }
            }
        }
    }
}

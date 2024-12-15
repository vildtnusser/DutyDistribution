using System.Data;

namespace DutyDistribution.Components.Pages
{

    using System.Collections.Generic;
    using Npgsql;
    using System.Linq;



    public class Duty
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public static List<Duty> GetAllDuties()
        {
            var connection = Shared.DataBase.GetConnection();

            using NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM public.duty", connection);

            using NpgsqlDataReader reader = cmd.ExecuteReader();

               
            var result = new List<Duty>();
            while (reader.Read())
            {
                Duty duty = new Duty(){Id = (int)reader["id"], Name = (string)reader["name"]};
                result.Add(duty);
            }
            return result;
        }

        public static int AddDuty(string nameTextField)
        {
            var connection = Shared.DataBase.GetConnection();
            List<Duty> duties = GetAllDuties();
            var newDuty = new Duty() { Name = nameTextField };
            
            IEnumerable<Duty> nameMatch = from duty in duties
                where duty.Name == nameTextField
                select duty;

            if (nameMatch.Count() == 0)
            {
                
                using NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.duty (name) VALUES (@nameOfDuty)", connection);
                cmd.Parameters.AddWithValue("@nameOfDuty", newDuty.Name);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }

            return -1;

        }

        public static int RemoveDuty(int idToBeDeleted)
        {
            var connection = Shared.DataBase.GetConnection();
            List<Duty> duties = GetAllDuties();
            int rowsAffected = -1;
            foreach (Duty duty in duties)
            { 
                if (duty.Id == idToBeDeleted)
                {
                    using NpgsqlCommand cmd = new NpgsqlCommand($"DELETE FROM public.duty WHERE id = {idToBeDeleted}", connection);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;


        }
    }
}
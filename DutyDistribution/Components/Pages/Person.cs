﻿using System.Data;

namespace DutyDistribution.Components.Pages
{
    using System;
    using System.Collections.Generic;
    using Npgsql;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public static List<Person> getAllPersons()
        {
            var connection = DutyDistribution.Components.Shared.DataBase.getConnection();

            using NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM public.person", connection);

            using NpgsqlDataReader reader = cmd.ExecuteReader();

               
            var result = new List<Person>();
            while (reader.Read())
            {
                Person person = new Person(){Id = (int)reader["id"], Name = (string)reader["name"]};
                result.Add(person);
            }
            return result;
        }

        public static int addPerson(string nameTextField)
        {
            var connection = DutyDistribution.Components.Shared.DataBase.getConnection();
            List<Person> persons = getAllPersons();
            var newPerson = new Person() { Name = nameTextField };
            
            IEnumerable<Person> nameMatch = from person in persons
                where person.Name == nameTextField
                select person;

            if (nameMatch.Count() == 0)
            {
                
                using NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.person (name) VALUES (@nameOfPerson)", connection);
                cmd.Parameters.AddWithValue("@nameOfPerson", newPerson.Name);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }

            return -1;

        }

        public static int removePerson(int idToBeDeleted)
        {
            var connection = DutyDistribution.Components.Shared.DataBase.getConnection();
            List<Person> persons = getAllPersons();
            int rowsAffected = -1;
            foreach (Person person in persons)
            { 
                if (person.Id == idToBeDeleted)
                {
                    using NpgsqlCommand cmd = new NpgsqlCommand($"DELETE FROM public.person WHERE id = {idToBeDeleted}", connection);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;


        }
    }
}
﻿using LibraryManagementApplication.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LibraryManagementApplication.Database
{
    public class DatabaseHelper
    {

        public static DataBase LoadDataFromJson(string path)
        {

            string allDataFromJson = File.ReadAllText(path);
            return JsonSerializer.Deserialize<DataBase>(allDataFromJson);
        }
        public static void SaveDataToJson(List<LibraryBook> allBooks, List<Arthur> allArthurs, string dataJSONfilPath)
        {
            DataBase updatedDataBase = new DataBase
            {
                BooksFromDataBase = allBooks,
                ArthursFromDataBase = allArthurs
            };

            string updatedJSON = JsonSerializer.Serialize(updatedDataBase, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(dataJSONfilPath, updatedJSON);
        }
    }
}

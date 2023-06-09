﻿using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces
{
    public interface ISqlDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parametrs);
        Task SaveData<T>(string sql, T parametrs);
        Task<T> LoadOne<T,U>(string sql, U parametrs);
    }
}
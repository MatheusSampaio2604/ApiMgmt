﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Interfaces
{
    public interface InterRequestApi
    {
        Task<TResponse> GetAsync<TResponse>(string url);
        Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest data);
        Task<TResponse> PutAsync<TRequest, TResponse>(string url, TRequest data);
        Task DeleteAsync(string url);
    }
}
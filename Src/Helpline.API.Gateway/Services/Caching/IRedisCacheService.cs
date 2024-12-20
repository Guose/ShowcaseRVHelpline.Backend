﻿namespace Helpline.API.Gateway.Services.Caching
{
    public interface IRedisCacheService
    {
        T? GetData<T>(string key);
        void SetData<T>(string key, T value);
    }
}

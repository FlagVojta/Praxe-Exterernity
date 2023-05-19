﻿using Microsoft.JSInterop;

namespace BlazorApp1.Data
{
    public static class FileUtil
    {
        public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data)
            => js.InvokeAsync<object>("saveFile", filename, Convert.ToBase64String(data));
    }
}
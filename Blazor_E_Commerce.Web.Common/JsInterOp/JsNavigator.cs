﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_E_Commerce.Web.Common.JsInterOp
{
    public class JsNavigator
    {
        private IJSRuntime JSRuntime;
        public JsNavigator(IJSRuntime jSRuntime)
        {
            this.JSRuntime = jSRuntime;
        }

        public async Task NavigateToAsync(string url)
        {
            await JSRuntime.InvokeVoidAsync("navigateTo", url);
        }
    }
}

﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5HomeWork0418.Startup))]
namespace MVC5HomeWork0418
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

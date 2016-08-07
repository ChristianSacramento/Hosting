﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.TestHost.Tests.Internal
{
    public class MyContainer : IServiceProvider
    {
        private IServiceProvider _inner;
        private IServiceCollection _services;

        public bool FancyMethodCalled { get; set; }

        public object GetService(Type serviceType)
        {
            return _inner.GetService(serviceType);
        }

        public void Populate(IServiceCollection services)
        {
            _services = services;
        }

        public void Build()
        {
            _inner = _services.BuildServiceProvider();
        }

        public void MyFancyContainerMethod()
        {
            FancyMethodCalled = true;
        }
    }
}

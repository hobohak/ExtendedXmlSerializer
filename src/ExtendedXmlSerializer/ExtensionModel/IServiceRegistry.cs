// MIT License
// 
// Copyright (c) 2016 Wojciech Nag�rski
//                    Michael DeMond
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.Reflection;
using LightInject;

namespace ExtendedXmlSerialization.ExtensionModel
{
	// ATTRIBUTION: https://github.com/seesharper/LightInject/blob/master/src/LightInject/LightInject.cs#L88
	// Basically using this as a decorated contract for now.
	public interface IServiceRegistry : IServiceProvider
	{
		IEnumerable<ServiceRegistration> AvailableServices { get; }

		IServiceRegistry Register(Type serviceType, Type implementingType);

		IServiceRegistry Register(Type serviceType, Type implementingType, ILifetime lifetime);

		IServiceRegistry Register(Type serviceType, Type implementingType, string serviceName);

		IServiceRegistry Register(Type serviceType, Type implementingType, string serviceName, ILifetime lifetime);

		IServiceRegistry Register<TService, TImplementation>() where TImplementation : TService;

		IServiceRegistry Register<TService, TImplementation>(string serviceName) where TImplementation : TService;

		IServiceRegistry Register<TService>();

		IServiceRegistry RegisterInstance<TService>(TService instance);
		IServiceRegistry RegisterInstance<TService>(TService instance, string serviceName);
		IServiceRegistry RegisterInstance(Type serviceType, object instance);

		IServiceRegistry RegisterInstance(Type serviceType, object instance, string serviceName);


		IServiceRegistry Register(Type serviceType);

		IServiceRegistry Register<TService>(Func<IServiceFactory, TService> factory);
		IServiceRegistry Register<T, TService>(Func<IServiceFactory, T, TService> factory);
		IServiceRegistry Register<T, TService>(Func<IServiceFactory, T, TService> factory, string serviceName);
		IServiceRegistry Register<T1, T2, TService>(Func<IServiceFactory, T1, T2, TService> factory);
		IServiceRegistry Register<T1, T2, TService>(Func<IServiceFactory, T1, T2, TService> factory, string serviceName);
		IServiceRegistry Register<T1, T2, T3, TService>(Func<IServiceFactory, T1, T2, T3, TService> factory);

		IServiceRegistry Register<T1, T2, T3, TService>(Func<IServiceFactory, T1, T2, T3, TService> factory,
		                                                string serviceName);

		IServiceRegistry Register<T1, T2, T3, T4, TService>(Func<IServiceFactory, T1, T2, T3, T4, TService> factory);

		IServiceRegistry Register<T1, T2, T3, T4, TService>(Func<IServiceFactory, T1, T2, T3, T4, TService> factory,
		                                                    string serviceName);

		IServiceRegistry Register<TService>(Func<IServiceFactory, TService> factory, string serviceName);
		IServiceRegistry RegisterFallback(Func<Type, bool> predicate, Func<Type, object> factory);


		/*IServiceRegistry Register<TService, TImplementation>(ILifetime lifetime) where TImplementation : TService;
		IServiceRegistry Register<TService, TImplementation>(string serviceName, ILifetime lifetime) where TImplementation : TService;
		IServiceRegistry Register<TService>(ILifetime lifetime);
		IServiceRegistry Register(Type serviceType, ILifetime lifetime);
		IServiceRegistry Register<TService>(Func<IServiceFactory, TService> factory, ILifetime lifetime);
		IServiceRegistry Register<TService>(Func<IServiceFactory, TService> factory, string serviceName, ILifetime lifetime);	 
		IServiceRegistry RegisterFallback(Func<Type, string, bool> predicate, Func<ServiceRequest, object> factory, ILifetime lifetime);

					IServiceRegistry Decorate(Type serviceType, Type decoratorType, Func<ServiceRegistration, bool> predicate);
					IServiceRegistry Decorate(DecoratorRegistration decoratorRegistration);
					IServiceRegistry Override(Func<ServiceRegistration, bool> serviceSelector, Func<IServiceFactory, ServiceRegistration, ServiceRegistration> serviceRegistrationFactory);
			 */

		IServiceRegistry RegisterConstructorDependency<TDependency>(Func<IServiceFactory, ParameterInfo, TDependency> factory);

		IServiceRegistry RegisterConstructorDependency<TDependency>(
			Func<IServiceFactory, ParameterInfo, object[], TDependency> factory);


		IServiceRegistry Decorate(Type serviceType, Type decoratorType);

		IServiceRegistry Decorate<TService, TDecorator>() where TDecorator : TService;
		IServiceRegistry Decorate<TService>(Func<IServiceFactory, TService, TService> factory);
	}
}